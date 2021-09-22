using GP.Domain.Contracts.DataAccess;
using GP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.Infrastructure.Ef
{
    public class Query<TDomainObject> : IQuery<TDomainObject>
        where TDomainObject : class, IDomainObject
    {
        protected IQueryable<TDomainObject> Queryable;

        public Query(IQueryable<TDomainObject> query)
        {
            Queryable = query;
        }

        public IQuery<TDomainObject> AsNoTracking()
        {
            Queryable = Queryable.AsNoTracking();

            return this;
        }

        public IQuery<TDomainObject> Take(int quantity)
        {
            Queryable = Queryable.Take(quantity);

            return this;
        }

        public virtual Task<List<TDomainObject>> ToListAsync()
        {
            return Queryable.ToListAsync();
        }

        public virtual Task<TDomainObject> SingleOrDefaultAsync()
        {
            return Queryable.SingleOrDefaultAsync();
        }

        public virtual Task<TDomainObject> SingleAsync()
        {
            return Queryable.SingleAsync();
        }

        public virtual Task<TDomainObject> FirstAsync()
        {
            return Queryable.FirstAsync();
        }

        public virtual Task<TDomainObject> FirstOrDefaultAsync()
        {
            return Queryable.FirstOrDefaultAsync();
        }

        public virtual Task<TDomainObject> LastAsync()
        {
            return Queryable.LastAsync();
        }

        public virtual Task<TDomainObject> LastOrDefaultAsync()
        {
            return Queryable.LastOrDefaultAsync();
        }

        public virtual Task<bool> AnyAsync()
        {
            return Queryable.AnyAsync();
        }

    }
}
