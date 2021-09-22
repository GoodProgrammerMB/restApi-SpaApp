using GP.Domain.Models.Core.PublishingHouses;

namespace GP.Domain.Contracts.DataAccess.PublishingHouses
{
    public interface IPublishingHouseQuery : IQuery<PublishingHouse>
    {
        IPublishingHouseQuery ById(int id);
        IPublishingHouseQuery ByName(string name);
        IPublishingHouseQuery ByNameContains(string name);
    }
}
