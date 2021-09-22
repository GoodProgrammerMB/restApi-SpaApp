using GP.Domain.Contracts.Services;
using GP.Shared.Dto.Books;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public async Task<BookDto> GetByIdAsync(int id)
        {
            return await _bookService.Get(id);
        }

        [HttpGet("{title}")]
        public async Task<BookDto> GetByTitleAsync(string title)
        {
            return await _bookService.Get(title);
        }

        [HttpGet("all")]
        public async Task<List<BookDto>> GetAllAsync()
        {
            return await _bookService.Get();
        }

        [HttpPut("change")]
        public async Task<int> PayAndClose([FromBody] BookDto book)
        {
            return await _bookService.Edit(book);
        }

        [HttpPost("submit")]
        public async Task<BookDto> Submit([FromBody] BookDto model)
        {
            var result = await _bookService.Create(model);
            return model;
        }

        [HttpDelete]
        public async Task<bool> Delete( int id)
        {
            return await _bookService.Delete(id);
        }
    }
}
