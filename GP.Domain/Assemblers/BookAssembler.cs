using GP.Domain.Models.Core.Authors;
using GP.Domain.Models.Core.Books;
using GP.Domain.Models.Core.PublishingHouses;
using GP.Shared.Dto.Books;

namespace GP.Domain.Assemblers
{
    public static class BookAssembler
    {
        public static Book Assembly(BookDto model, Author author, PublishingHouse publishingHouse)
        {
            if (model == null)
            {
                return null;
            }
                
            var result = new Book(model.Title, model.Description, model.PublicationDate, model.ISBN, author, publishingHouse);

            return result;
        }

        public static BookDto Assembly(Book model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new BookDto();
            result.Title = model.Title;
            result.ISBN = model.ISBN;
            result.PublicationDate = model.PublicationDate;
            result.PublishingHouse = model.PublishingHouse.Name;
            result.Id = model.Id;
            result.Description = model.Description;
            result.Author = AuthorAssembler.Assembly(model.Author);

            return result;
        }
    }
}
