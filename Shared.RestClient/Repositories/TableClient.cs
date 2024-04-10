using Shared.RestClient.Interfaces;

namespace Shared.RestClient.Repositories
{
    internal class TableClient(HttpClient httpClient, string controller, INotification notification) : BaseClient(httpClient, controller, notification), ITableClient
    {
    }
}
