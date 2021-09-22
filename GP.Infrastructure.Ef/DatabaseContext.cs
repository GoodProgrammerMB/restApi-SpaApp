using GP.Domain.Models.Core.Authors;
using GP.Domain.Models.Core.Books;
using GP.Domain.Models.Core.PublishingHouses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace GP.Infrastructure.Ef
{
    public class DatabaseContext : DbContext
    {
        #region - DbSets -
        public DbSet<Author> Author{ get; set; }
        public DbSet<PublishingHouse> PublishingHouse { get; set; }
        public DbSet<Book> Book { get; set; }
        #endregion
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
    }
}
