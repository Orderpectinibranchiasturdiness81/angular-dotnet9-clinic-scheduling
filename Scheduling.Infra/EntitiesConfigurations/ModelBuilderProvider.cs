using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ModuleName.Infra.ProvidersConfigurations.RDB
{
    public static class ModelBuilderProvider
    {
        internal static void AddModelBuilderConfigrations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
