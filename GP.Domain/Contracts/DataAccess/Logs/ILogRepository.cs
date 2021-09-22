using GP.Domain.Models.Core.Logs;

namespace GP.Domain.Contracts.DataAccess.Logs
{
    public interface ILogRepository : IRepository<Log>
    {
        ILogQuery Query { get; }
    }
}
