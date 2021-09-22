using GP.Domain.Models.Core.Logs;
using Microsoft.EntityFrameworkCore;

namespace GP.Infrastructure.Ef
{
    public class EventLogContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }

        public EventLogContext(DbContextOptions<EventLogContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
