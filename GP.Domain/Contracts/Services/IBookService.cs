using GP.Shared.Dto.Books;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain.Contracts.Services
{
    public interface IBookService
    {
        Task<List<BookDto>> Get();
        Task<BookDto> Get(int id);
        Task<BookDto> Get(string title);
        Task<BookDto> Create(BookDto model);
        Task<int> Edit(BookDto model);
        Task<bool> Delete(int id);
    }
}
