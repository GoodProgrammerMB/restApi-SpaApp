using GP.Domain.Contracts.DataAccess.PublishingHouses;
using GP.Domain.Models.Core.PublishingHouses;
using System.Linq;

namespace GP.Infrastructure.Ef.DataAccess.PublishingHouses
{
    public class PublishingHouseQuery : Query<PublishingHouse>, IPublishingHouseQuery
    {
        public PublishingHouseQuery(IQueryable<PublishingHouse> query) : base(query)
        {
            Queryable = Queryable.OrderBy(x => x.Name);
        }

        public IPublishingHouseQuery ById(int id)
        {
            Queryable = Queryable.Where(x => x.Id == id);
            return this;
        }

        public IPublishingHouseQuery ByName(string name)
        {
            Queryable = Queryable.Where(x => x.Name.Contains(name));
            return this;
        }
        public IPublishingHouseQuery ByNameContains(string name)
        {
            Queryable = Queryable.Where(x => x.Name.Contains(name));
            return this;
        }
    }
}
