using Microsoft.Extensions.DependencyInjection;

namespace Scheduling.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services) { 
        
            return services;
            //return services.AddScoped<IService,CService>;
        }
    }
}
