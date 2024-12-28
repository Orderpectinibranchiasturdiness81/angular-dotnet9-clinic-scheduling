using Microsoft.EntityFrameworkCore;
using Scheduling.Domain.Entity;
using System.Reflection;

namespace Scheduling.Domain.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
