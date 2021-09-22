using GP.Domain.Contracts.DataAccess.Books;
using GP.Domain.Models.Core.Books;

namespace GP.Infrastructure.Ef.DataAccess.Books
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public IBookQuery Query => new BookQuery(base.Context.Set<Domain.Models.Core.Books.Book>().AsQueryable());
        public BookRepository(DatabaseContext context)
            : base(context)
        {

        }
    }
}
