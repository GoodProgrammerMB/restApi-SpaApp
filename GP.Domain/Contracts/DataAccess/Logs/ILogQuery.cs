using GP.Domain.Models.Core.Logs;
using GP.Shared.Enums;
using System;

namespace GP.Domain.Contracts.DataAccess.Logs
{
    public interface ILogQuery : IQuery<Log>
    {
        ILogQuery ById(int id);
        ILogQuery BetweenDates(DateTime from, DateTime to);
        ILogQuery ByType(LogType type);
        ILogQuery GetProjection();
    }
}
