using Shared.RestClient.Interfaces;

namespace Shared.RestClient.Repositories
{
    internal class AdditiveClient(HttpClient httpClient, string controller, INotification notification) : BaseClient(httpClient, controller, notification), IAdditiveClient
    {
    }
}
