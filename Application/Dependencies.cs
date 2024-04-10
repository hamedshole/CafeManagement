using Application.Helpers;
using Application.Heplers;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class Dependencies
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile<MapperProfile>());
            services.AddScoped<IApplicationUnit,ApplicationUnit>();
            return services;
        }
    }
}
