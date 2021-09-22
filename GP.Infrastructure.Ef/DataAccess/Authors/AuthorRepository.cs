using GP.Domain.Contracts.DataAccess.Authors;
using System;
using System.Collections.Generic;
using System.Text;

namespace GP.Infrastructure.Ef.DataAccess.Authors
{
    public class AuthorRepository : Repository<Domain.Models.Core.Authors.Author>, IAuthorRepository
    {
        public IAuthorQuery Query => new AuthorQuery(base.Context.Set<Domain.Models.Core.Authors.Author>().AsQueryable());
        public AuthorRepository(DatabaseContext context)
            : base(context)
        {

        }
    }
}
