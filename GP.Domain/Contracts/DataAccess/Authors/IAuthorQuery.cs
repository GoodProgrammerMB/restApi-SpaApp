using GP.Domain.Models.Core.Authors;

namespace GP.Domain.Contracts.DataAccess.Authors
{
    public interface IAuthorQuery : IQuery<Author>
    {
        IAuthorQuery ById(int id);
    }
}
