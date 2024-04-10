using Microsoft.Extensions.DependencyInjection;
using Shared.RestClient.Interfaces;

namespace Shared.RestClient
{
    public static class Dependencies
    {
        public static IServiceCollection AddRestClient(this IServiceCollection services)
        {
            services.AddScoped<IRestUnit, RestUnit>();
            return services;
        }
    }
}
