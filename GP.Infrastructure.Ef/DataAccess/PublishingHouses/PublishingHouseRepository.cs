using GP.Domain.Contracts.DataAccess.PublishingHouses;

namespace GP.Infrastructure.Ef.DataAccess.PublishingHouses
{
    public class PublishingHouseRepository : Repository<Domain.Models.Core.PublishingHouses.PublishingHouse>, IPublishingHouseRepository
    {
        public IPublishingHouseQuery Query => new PublishingHouseQuery(base.Context.Set<Domain.Models.Core.PublishingHouses.PublishingHouse>().AsQueryable());
        public PublishingHouseRepository(DatabaseContext context)
            : base(context)
        {

        }
    }
}
