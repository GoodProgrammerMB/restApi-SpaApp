using GP.Domain.Contracts.DataAccess.Logs;
using GP.Domain.Models.Core.Logs;
using GP.Shared.Enums;
using System;
using System.Linq;

namespace GP.Infrastructure.Ef.DataAccess.Logs
{
    public class LogQuery : Query<Log>, ILogQuery
    {
        public LogQuery(IQueryable<Log> query) : base(query)
        {
        }

        public ILogQuery BeforeDate(DateTime date)
        {
            Queryable = Queryable.Where(x => x.Date.Date <= date.Date);
            return this;
        }

        public ILogQuery AfterDate(DateTime date)
        {
            Queryable = Queryable.Where(x => x.Date.Date >= date.Date);
            return this;
        }

        public ILogQuery ById(int id)
        {
            Queryable = Queryable.Where(x => x.Id == id);
            return this;
        }

        public ILogQuery BetweenDates(DateTime @from, DateTime to)
        {
            AfterDate(from);
            BeforeDate(to);

            return this;
        }

        public ILogQuery ByType(LogType type)
        {
            Queryable = Queryable.Where(x => x.Type == type);
            return this;
        }

        public ILogQuery GetProjection()
        {
            Queryable = Queryable.Select(x => new Log(x.Date, x.Type, x.Message.Substring(0, 100))
            {
                Id = x.Id,
                RequestUrl = x.RequestUrl
            });
            return this;
        }
    }
}
