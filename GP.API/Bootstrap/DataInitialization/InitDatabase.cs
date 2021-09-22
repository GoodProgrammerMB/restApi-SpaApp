using GP.Infrastructure.Ef;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API.Bootstrap.DataInitialization
{
    public static class InitDatabase
    {
        public static void AddData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<DatabaseContext>())
                {
                    if (!context.Author.Any())
                    {
                        context.Author.AddRange(
                            new Domain.Models.Core.Authors.Author() { Name = "Julian", LastName="Tuwim"},
                            new Domain.Models.Core.Authors.Author() { Name = "Robert C.", LastName = "Martin" },
                            new Domain.Models.Core.Authors.Author() { Name = "Dmitri", LastName = "Nesteruk" },
                            new Domain.Models.Core.Authors.Author() { Name = "Jan", LastName = "Griffiths" }
                        );

                        context.SaveChanges();
                    }

                    if (!context.PublishingHouse.Any())
                    {
                        context.PublishingHouse.AddRange(
                            new Domain.Models.Core.PublishingHouses.PublishingHouse("Helion"),
                            new Domain.Models.Core.PublishingHouses.PublishingHouse("Edgard"),
                            new Domain.Models.Core.PublishingHouses.PublishingHouse("Muza"),
                            new Domain.Models.Core.PublishingHouses.PublishingHouse("Papierowy Księżyc"),
                            new Domain.Models.Core.PublishingHouses.PublishingHouse("Prószyński i S-ka"),
                            new Domain.Models.Core.PublishingHouses.PublishingHouse("PWN"),
                            new Domain.Models.Core.PublishingHouses.PublishingHouse("Znak")
                        );

                        context.SaveChanges();
                    }
                }
            }
        }
    }
}

