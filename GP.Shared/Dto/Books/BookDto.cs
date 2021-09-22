using System;
using GP.Shared.Dto.Authors;

namespace GP.Shared.Dto.Books
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ISBN { get; set; }
        public AuthorDto Author { get; set; }
        public string PublishingHouse { get; set; }

    }
}
