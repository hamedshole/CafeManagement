using Shared.RestClient.Interfaces;
using Shared.RestClient;
namespace WebApp.Util
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterWebApp(this IServiceCollection services,string url)
        {
            services.AddSingleton(new HttpClient { BaseAddress = new Uri(url ?? throw new Exception("api url not implemented")) });
           services.AddScoped<INotification, Notification>();
         services.AddRestClient();
            return services;
        }
    }
}
