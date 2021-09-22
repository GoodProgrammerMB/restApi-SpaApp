using GP.Shared.Dto.Authors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain.Contracts.Services
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> Get();
        Task<List<AuthorDto>> GetActive();
    }
}
