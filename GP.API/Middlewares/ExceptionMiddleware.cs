using GP.Domain.Contracts.DataAccess.Logs;
using GP.Domain.Models.Core.Logs;
using GP.Shared;
using GP.Shared.Enums;
using GP.Shared.Exceptions;
using GP.Shared.Extensions;
using GP.Shared.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GP.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private static string UnhandledErrorMessage => ErrorMessage.ServerError;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogRepository logRepository, IClock clock)
        {
            context.Request.EnableBuffering();
            try
            {
                await _next(context);
            }
            catch (CustomException e)
            {
                var logId = await WriteLogAsync(context, e.ToString(), e.StackTrace, logRepository, clock);
                await WriteResponseAsync(context, $"({e.Message}, {e.TranslationParams}", e.HttpStatusCode, logId);
            }
            catch (DbUpdateException e)
            {
                var eid = await WriteLogAsync(context, ReadDetailedMessage(e), e.StackTrace, logRepository, clock);
                await WriteResponseAsync(context, UnhandledErrorMessage, HttpStatusCode.InternalServerError, eid);
            }
            catch (Exception e)
            {
                var eid = await WriteLogAsync(context, e.ToString(), e.ToLogString(false), logRepository, clock);
                await WriteResponseAsync(context, UnhandledErrorMessage, HttpStatusCode.InternalServerError, eid);
            }
        }

        private async Task WriteResponseAsync(HttpContext context, string message, HttpStatusCode statusCode, long? logId = null)
        {
            var responseModel = new
            {
                statusCode,
                message,
                logId
            };

            context.Response.StatusCode = (int)statusCode;

            await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(responseModel, Formatting.Indented)));
        }

        private async Task<long?> WriteLogAsync(HttpContext context, string message, string stackTrace, ILogRepository logRepository, IClock clock)
        {
            try
            {
                var log = new Log(clock.UtcNow, LogType.ApiException, message)
                {
                    RequestUrl = context.Request.Path + context.Request.QueryString,
                    RequestBody = await GetRequestString(context),
                    StackTrace = stackTrace.TakeChars(2000),
                    RemotePort = context.Connection.RemotePort.ToString()
                };

                if (log.RequestUrl.StartsWith("/auth/"))
                {
                    log.RequestBody = "CLEARED FOR SECURITY REASONS";
                }

                await logRepository.AddAsync(log);

                await logRepository.SaveChangesAsync();

                return log.Id;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static async Task<string> GetRequestString(HttpContext context)
        {
            string body;

            context.Request.Body.Position = 0;
            using (var reader = new StreamReader(context.Request.Body))
            {
                body = await reader.ReadToEndAsync();

                // Rewind, so the core is not lost when it looks the body for the request
                context.Request.Body.Position = 0;
            }

            return body;
        }


        private string ReadDetailedMessage(DbUpdateException @this)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(@this.Message);

            foreach (var entry in @this.Entries)
            {
                stringBuilder.AppendLine($"Issue with {entry.Entity} with state {entry.State}");
                stringBuilder.AppendLine("The values: ");

                foreach (var entityValue in entry.Collections)
                    stringBuilder.AppendLine($"{entityValue.Metadata.Name} : {entityValue.CurrentValue}");

                stringBuilder.AppendLine(string.Empty);
            }

            return stringBuilder.ToString();
        }
    }
}
