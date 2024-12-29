using Microsoft.Extensions.DependencyInjection;
using Scheduling.Domain.IServices;
using Scheduling.Infra.Services;

namespace Scheduling.Infra
{
    public static class DependencyInjection_AddServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddScoped<IUserProfileService, UserProfileService>();
        }
    }
}
