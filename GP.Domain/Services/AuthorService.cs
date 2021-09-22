using GP.Domain.Assemblers;
using GP.Domain.Contracts.DataAccess.Authors;
using GP.Domain.Contracts.Services;
using GP.Shared.Dto.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain.Services
{
    public class AuthorService: IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<AuthorDto>> Get()
        {
            var model = new List<AuthorDto>();
            var result = await _authorRepository.Query.ToListAsync();
            model = result.Select(AuthorAssembler.Assembly).ToList();
            return model;
        }

        public async Task<List<AuthorDto>> GetActive()
        {
            var model = new List<AuthorDto>();
            var result = await _authorRepository.Query.ToListAsync();
            model = result.Select(AuthorAssembler.Assembly).ToList();
            return model;
        }
    }
}
