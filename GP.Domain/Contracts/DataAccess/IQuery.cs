using GP.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GP.Domain.Contracts.DataAccess
{
    public interface IQuery<TDomainObject>
         where TDomainObject : IDomainObject
    {
        IQuery<TDomainObject> AsNoTracking();
        IQuery<TDomainObject> Take(int quantity);
        Task<List<TDomainObject>> ToListAsync();
        Task<TDomainObject> SingleOrDefaultAsync();
        Task<TDomainObject> SingleAsync();
        Task<TDomainObject> FirstAsync();
        Task<TDomainObject> FirstOrDefaultAsync();
        Task<TDomainObject> LastAsync();
        Task<TDomainObject> LastOrDefaultAsync();
        Task<bool> AnyAsync();
    }
}
