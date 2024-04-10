using Shared.RestClient.Interfaces;

namespace Shared.RestClient.Repositories
{
    internal class MaterialClient(HttpClient httpClient, string controller, INotification notification) : BaseClient(httpClient, controller, notification), IMaterialClient
    {
    }
}
