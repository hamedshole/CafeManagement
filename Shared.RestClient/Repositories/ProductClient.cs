using Shared.RestClient.Interfaces;

namespace Shared.RestClient.Repositories
{
    internal class ProductClient(HttpClient httpClient, string controller, INotification notification) : BaseClient(httpClient, controller, notification), IProductClient
    {
    }
}
