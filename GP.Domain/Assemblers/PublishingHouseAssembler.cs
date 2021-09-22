using GP.Shared.Dto.PublishingHouses;

namespace GP.Domain.Assemblers
{
    public static class PublishingHouseAssembler
    {
        public static PublishingHouseDto Assembly(Models.Core.PublishingHouses.PublishingHouse publishingHouse)
        {
            if (publishingHouse == null)
                return null;
            var result = new PublishingHouseDto()
            {
                Name = publishingHouse.Name,
                Id = publishingHouse.Id
            };

            return result;
        }
    }
}
