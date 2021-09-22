using GP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain.Contracts.DataAccess
{
    public interface IRepository<TDomainObject>
        where TDomainObject : IDomainObject
    {
        Task AddAsync(TDomainObject @object);
        Task RemoveAsync(TDomainObject @object);
        Task AddRangeAsync(List<TDomainObject> objects);
        Task RemoveRangeAsync(List<TDomainObject> objects);
        Task UpdateAsync(TDomainObject @object);
        Task UpdateRangeAsync(List<TDomainObject> objects);
        Task SaveChangesAsync();
    }
}
