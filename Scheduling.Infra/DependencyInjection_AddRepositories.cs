using Microsoft.Extensions.DependencyInjection;
using Scheduling.Domain.IRepositories;
using Scheduling.Infra.Repositories;

namespace Scheduling.Infra
{
    public static class DependencyInjection_AddRepositories
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
        }
    }
}
