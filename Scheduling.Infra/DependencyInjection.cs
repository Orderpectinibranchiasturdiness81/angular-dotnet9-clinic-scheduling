using Microsoft.Extensions.DependencyInjection;

namespace Scheduling.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            return services;
            //return services.AddScoped<IRepos,CRepos>;
        }
    }
}
