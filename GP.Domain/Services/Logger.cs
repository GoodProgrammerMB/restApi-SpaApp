using GP.Domain.Contracts.DataAccess.Logs;
using GP.Domain.Models.Core.Logs;
using GP.Shared.Enums;
using System;
using System.Threading.Tasks;

namespace GP.Domain.Services
{
    public class Logger
    {
        private readonly ILogRepository _logRepository;

        public Logger(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task LogAsync(LogType type, string message)
        {
            var log = new Log(DateTime.UtcNow, type, message: message);

            await _logRepository.AddAsync(log);
            await _logRepository.SaveChangesAsync();
        }
    }
}
