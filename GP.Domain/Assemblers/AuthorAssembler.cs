using GP.Shared.Dto.Authors;

namespace GP.Domain.Assemblers
{
    public static class AuthorAssembler
    {
        public static AuthorDto Assembly(Models.Core.Authors.Author author)
        {
            if (author == null)
                return null;
            var result = new AuthorDto()
            {
                Id = author.Id,
                Name = author.Name,
                LastName = author.LastName
            };

            return result;
        }
    }
}
