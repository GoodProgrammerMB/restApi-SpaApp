using GP.Infrastructure.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API.Bootstrap.DataInitialization
{
    public interface IDataSeeder
    {
        void Seed(DatabaseContext context);
    }
}
