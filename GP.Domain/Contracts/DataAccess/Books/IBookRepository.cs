using GP.Domain.Models.Core.Books;

namespace GP.Domain.Contracts.DataAccess.Books
{
    public interface IBookRepository : IRepository<Book>
    {
        IBookQuery Query { get; }
    }
}
