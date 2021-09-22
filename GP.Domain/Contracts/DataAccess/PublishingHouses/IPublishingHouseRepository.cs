using GP.Domain.Models.Core.PublishingHouses;

namespace GP.Domain.Contracts.DataAccess.PublishingHouses
{
    public interface IPublishingHouseRepository : IRepository<PublishingHouse>
    {
        IPublishingHouseQuery Query { get; }
    }
}
