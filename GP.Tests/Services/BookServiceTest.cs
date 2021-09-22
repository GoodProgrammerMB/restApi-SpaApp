using FluentAssertions;
using GP.Domain.Models.Core.Authors;
using GP.Domain.Models.Core.Books;
using GP.Domain.Models.Core.PublishingHouses;
using GP.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GP.Tests.Services
{
    public class BookServiceTest: TestBase
    {
        public BookServiceTest()
        {
            var author = (new Author() {LastName = "Nowak", Name = "Jan" }).AddToInMemory(AssertRepositoryContext);
            var publishingHouse = (new PublishingHouse() {Name="PWN"}).AddToInMemory(AssertRepositoryContext);
            var book = new Book("title", "Description", DateTime.Now, "23456789kmn", author, publishingHouse).AddToInMemory(ArrangeRepositoryContext);
            //var product = Product.Create("Zupa", 22, 1).AddToInMemory(ArrangeRepositoryContext);
            //var orderItem = new OrderItem(product, 2).AddToInMemory(ArrangeRepositoryContext);
            //var orderItems = new List<OrderItem>();
            //orderItems.Add(orderItem);
            //order = new Order(table, Clock, orderItems.ToArray()).AddToInMemory(AssertRepositoryContext);
        }

        [Fact]
        public async Task Get_acive_books()
        {
            // arrange
           

            // act
            var book = await BookService.Get("title");

            // assert
            book.Should().NotBeNull();
            book.Description.Should().Be("Description");
        }
    }
}
