using GP.Domain.Contracts.DataAccess;
using GP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GP.Infrastructure.Ef
{
    public abstract class Repository<TDomainObject> : IRepository<TDomainObject>
        where TDomainObject : class, IDomainObject
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TDomainObject> DbSet;

        protected Repository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TDomainObject>();
        }

        public async Task AddAsync(TDomainObject @object)
        {
            await Context.AddAsync(@object);
        }

        public Task RemoveAsync(TDomainObject @object)
        {
            Context.Remove(@object);

            return Task.CompletedTask;
        }

        public async Task AddRangeAsync(List<TDomainObject> objects)
        {
            await Context.AddRangeAsync(objects);
        }

        public Task RemoveRangeAsync(List<TDomainObject> objects)
        {
            Context.RemoveRange(objects);

            return Task.CompletedTask;
        }

        public Task UpdateAsync(TDomainObject @object)
        {
            Context.Update(@object);

            return Task.CompletedTask;
        }

        public Task UpdateRangeAsync(List<TDomainObject> objects)
        {
            Context.UpdateRange(@objects);

            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
