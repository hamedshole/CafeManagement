using Shared.RestClient.Interfaces;

namespace Shared.RestClient.Repositories
{
    internal class InventoryClient(HttpClient httpClient, string controller, INotification notification) : BaseClient(httpClient, controller, notification), IInventoryClient
    {
    }
}
