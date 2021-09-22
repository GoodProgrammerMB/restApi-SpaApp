using GP.Domain.Contracts.DataAccess.Authors;
using GP.Domain.Models.Core.Authors;
using System.Linq;

namespace GP.Infrastructure.Ef.DataAccess.Authors
{
    public class AuthorQuery : Query<Author>, IAuthorQuery
    {
        public AuthorQuery(IQueryable<Author> query) : base(query)
        {
            Queryable = Queryable.OrderBy(x => x.LastName);
        }

        public IAuthorQuery ById(int id)
        {
            Queryable = Queryable.Where(x => x.Id == id);
            return this;
        }
    }
}
