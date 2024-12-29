using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Scheduling.Domain.EntitiesConfigurations
{
    public static class ModelBuilderProvider
    {
        public static void AddModelBuilderConfigrations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
