using GP.Domain.Contracts.DataAccess.Books;
using GP.Domain.Models.Core.Books;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GP.Infrastructure.Ef.DataAccess.Books
{
    public class BookQuery : Query<Book>, IBookQuery
    {
        public BookQuery(IQueryable<Book> query) : base(query)
        {
        }

        public IBookQuery ById(int id)
        {
            Queryable = Queryable.Where(x => x.Id == id);
            return this;
        }

        public IBookQuery ByTitle(string title)
        {
            Queryable = Queryable.Where(x => x.Title == title);
            return this;
        }

        public IBookQuery IncludeAuthor()
        {
            Queryable = Queryable.Include(x => x.Author);
            return this;
        }

        public IBookQuery IncludePublishingHouses()
        {
            Queryable = Queryable.Include(x => x.PublishingHouse);
            return this;
        }
    }
}
