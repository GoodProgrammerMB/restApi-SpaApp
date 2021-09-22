using GP.Shared.Enums;
using System;

namespace GP.Domain.Models.Core.Logs
{
    public class Log : DomainObject
    {
        public DateTime Date { get; set; }
        public LogType Type { get; set; }
        public string RequestUrl { get; set; }
        public string RequestBody { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string RemoteIpAddress { get; set; }
        public string RemotePort { get; set; }

        public Log(DateTime date, LogType type, string message)
        {
            Date = date;
            Type = type;
            Message = message;
        }
    }
}
