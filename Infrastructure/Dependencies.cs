using Domain.Interfaces;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Dependencies
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<CafeContext>(x => x.UseSqlServer(connectionString));
            services.AddScoped<ICafeDataUnit, CafeDataUnit>();
            return services;
        }
        
    }
}
