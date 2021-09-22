using GP.Domain.Models.Core.Books;

namespace GP.Domain.Contracts.DataAccess.Books
{
    public interface IBookQuery : IQuery<Book>
    {
        IBookQuery ById(int id);
        IBookQuery ByTitle(string title);
        IBookQuery IncludeAuthor();
        IBookQuery IncludePublishingHouses();
    }
}
