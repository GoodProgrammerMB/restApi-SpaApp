using GP.Shared.Dto.PublishingHouses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GP.Domain.Contracts.Services
{
    public interface IPublishingHouseService
    {
        Task<PublishingHouseDto> Get(int id);
        Task<List<PublishingHouseDto>> Get();
        Task<PublishingHouseDto> Create(PublishingHouseDto model);
    }
}
