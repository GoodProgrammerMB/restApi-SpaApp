using GP.Domain.Contracts.DataAccess.Logs;
using GP.Domain.Models.Core.Logs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GP.Infrastructure.Ef.DataAccess.Logs
{
    public class LogRepository : Repository<Log>, ILogRepository
    {
        public ILogQuery Query => new LogQuery(base.Context.Set<Log>().AsQueryable());

        public LogRepository(EventLogContext context)
            : base(context)
        {

        }
    }
}
