using GP.Domain.Models.Core.Authors;

namespace GP.Domain.Contracts.DataAccess.Authors
{
    public interface IAuthorRepository : IRepository<Author>
    {
        IAuthorQuery Query { get; }
    }
}
