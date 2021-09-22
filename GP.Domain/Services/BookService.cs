using GP.Domain.Assemblers;
using GP.Domain.Contracts.DataAccess.Books;
using GP.Domain.Contracts.DataAccess.Authors;
using GP.Domain.Contracts.DataAccess.PublishingHouses;
using GP.Domain.Contracts.Services;
using GP.Domain.Models.Core.Books;
using GP.Shared.Dto.Books;
using GP.Shared.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.Domain.Services
{
    public class BookService: IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IPublishingHouseRepository _publishingHouseRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IClock _clock;

        public BookService(IBookRepository bookRepository, IPublishingHouseRepository publishingHouseRepository, IAuthorRepository authorRepository, IClock clock)
        {
            _bookRepository = bookRepository;
            _publishingHouseRepository = publishingHouseRepository;
            _authorRepository = authorRepository;
            _clock = clock;
        }


        public async Task<BookDto> Create(BookDto model)
        {
            var publishingHouse = await _publishingHouseRepository.Query.ByName(model.PublishingHouse).SingleAsync();
            
            var author = await _authorRepository.Query.ById(model.Author.Id).SingleAsync();
            
            var modelDb = BookAssembler.Assembly(model, author, publishingHouse);
            
            await _bookRepository.AddAsync(modelDb);
            await _bookRepository.SaveChangesAsync();
            return model;
        }

        public async Task<int> Edit(BookDto model)
        {
            var publishingHouse = await _publishingHouseRepository.Query.ByName(model.PublishingHouse).SingleAsync();

            var author = await _authorRepository.Query.ById(model.Author.Id).SingleAsync();
            var oldBook = await _bookRepository.Query.ById(model.Id).FirstAsync();
            if(oldBook != null)
            {
                var modelDb = BookAssembler.Assembly(model, author, publishingHouse);
                //przepisać dane
                await _bookRepository.UpdateAsync(modelDb);
                await _bookRepository.SaveChangesAsync();
                return modelDb.Id;
            }

            return 0;      
        }
        public async Task<bool> Delete(int id)
        {
            var book = await _bookRepository.Query.ById(id).FirstAsync();
            if(book != null)
            {
                await _bookRepository.RemoveAsync(book);
                await _bookRepository.SaveChangesAsync();
                return true;

                //poprawić czy sukces czy nie
            }
            return false;
        }

        public async Task<List<BookDto>> Get()
        {
            var books = await _bookRepository.Query.ToListAsync();
            return books.Select(BookAssembler.Assembly).ToList();
        }

        public async Task<BookDto> Get(int id)
        {
            var book = await _bookRepository.Query.ById(id).FirstAsync();
            return BookAssembler.Assembly(book);
        }

        public async Task<BookDto> Get(string title)
        {
            var book = await _bookRepository.Query.ByTitle(title).FirstAsync();
            return BookAssembler.Assembly(book);
        }

    }
}
