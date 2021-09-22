using GP.Domain.Models.Core.Authors;
using GP.Domain.Models.Core.PublishingHouses;
using System;

namespace GP.Domain.Models.Core.Books
{
    public class Book : DomainObject
    {
        public Book()
        {

        }
        public Book(string title, string description, DateTime publicationDate, string iSBN, Author author, PublishingHouse publishingHouse) : this()
        {
            Title = title;
            Description = description;
            PublicationDate = publicationDate;
            ISBN = iSBN;
            Author = author;
            PublishingHouse = publishingHouse;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ISBN { get; set; }
        public virtual Author Author { get; set; }
        public virtual PublishingHouse PublishingHouse { get; set; }
    }
}
