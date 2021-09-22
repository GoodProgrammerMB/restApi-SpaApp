using GP.API.Bootstrap.DataInitialization;
using GP.Domain.Contracts.DataAccess.Logs;
using GP.Domain.Contracts.DataAccess.Authors;
using GP.Domain.Contracts.DataAccess.Books;
using GP.Domain.Contracts.DataAccess.PublishingHouses;
using GP.Domain.Contracts.Services;
using GP.Domain.Services;
using GP.Infrastructure.Ef;
using GP.Infrastructure.Ef.DataAccess.Logs;
using GP.Infrastructure.Ef.DataAccess.Authors;
using GP.Infrastructure.Ef.DataAccess.Books;
using GP.Infrastructure.Ef.DataAccess.PublishingHouses;
using GP.Shared.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace GP.API.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection @this)
        {
            @this.AddScoped<ILogRepository, LogRepository>();
            @this.AddScoped<IBookRepository, BookRepository>();
            @this.AddScoped<IAuthorRepository, AuthorRepository>();
            @this.AddScoped<IPublishingHouseRepository, PublishingHouseRepository>();
            //@this.AddScoped<ITableRepository, LogRepository>();
            

            return @this;
        }
        public static IServiceCollection RegisterDomainServices(this IServiceCollection @this, IConfiguration configuration)
        {
            @this.AddScoped<Logger, Logger>();
            @this.AddScoped<IAuthorService, AuthorService>();
            @this.AddScoped<IPublishingHouseService, PublishingHouseService>();
            @this.AddScoped<IBookService, BookService>();
            @this.AddScoped<IClock, Clock>();

            return @this;
        }
        /*
        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SmartShopingConstants.LOCAL_ACCESS_TOKEN_SECRET)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.Anyone, builder =>
                {
                    builder.RequireAuthenticatedUser();
                    builder.AuthenticationSchemes = new List<string> { "Bearer" };
                });
                options.AddPolicy(Policies.ShopAssistant, builder =>
                {
                    builder.RequireAuthenticatedUser();
                    builder.AuthenticationSchemes = new List<string> { "Bearer" };
                    builder.AddRequirements(new RolesAuthorizationRequirement(new[] { UserRole.ShopAssistant.ToString() }));
                });
                options.AddPolicy(Policies.Customer, builder =>
                {
                    builder.RequireAuthenticatedUser();
                    builder.AuthenticationSchemes = new List<string> { "Bearer" };
                    builder.AddRequirements(new RolesAuthorizationRequirement(new[] { UserRole.Customer.ToString() }));
                });

                options.DefaultPolicy = options.GetPolicy(Policies.Anyone);
            });

            return services;
        }
        */
        public static IServiceCollection RegisterDatabase(this IServiceCollection @this, string connectionString)
        {
            @this.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(connectionString));

            @this.AddDbContext<EventLogContext>(options =>
               options.UseSqlServer(connectionString));

            return @this;
        }

        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder @this)
        {
            using (var serviceScope = @this.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
                context.Database.Migrate();

                var logsContext = serviceScope.ServiceProvider.GetRequiredService<EventLogContext>();
                logsContext.Database.Migrate();

                return @this;
            }
        }

        public static IApplicationBuilder SeedDefaultData(this IApplicationBuilder @this)
        {
            using (var serviceScope = @this.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();

                var seeders = new List<IDataSeeder>
                {
                };

                foreach (var dataSeeder in seeders)
                {
                    dataSeeder.Seed(context);
                }

                return @this;
            }
        }
    }
}
