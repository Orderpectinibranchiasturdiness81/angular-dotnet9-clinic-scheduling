using Microsoft.EntityFrameworkCore;
using Scheduling.Infra.EntitiesConfigurations;

namespace Scheduling.Infra.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddModelBuilderConfigrations();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Enable Lazy Loading
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
