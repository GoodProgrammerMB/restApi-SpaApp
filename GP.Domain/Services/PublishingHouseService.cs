using GP.Domain.Assemblers;
using GP.Domain.Contracts.DataAccess.PublishingHouses;
using GP.Domain.Contracts.Services;
using GP.Shared.Dto.PublishingHouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain.Services
{
    public class PublishingHouseService: IPublishingHouseService
    {
        private readonly IPublishingHouseRepository _tableRepository;

        public PublishingHouseService(IPublishingHouseRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public async Task<List<PublishingHouseDto>> Get()
        {
            var result = await _tableRepository.Query.ToListAsync();
            return result.Select(PublishingHouseAssembler.Assembly).ToList();
        }

        public async Task<PublishingHouseDto> Get(int id)
        { 
            var result = await _tableRepository.Query.ById(id).FirstOrDefaultAsync();
            return PublishingHouseAssembler.Assembly(result);
        }

        public Task<PublishingHouseDto> Create(PublishingHouseDto model)
        {
            throw new NotImplementedException();
        }
    }
}
