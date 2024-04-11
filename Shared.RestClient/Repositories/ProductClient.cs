using Shared.Model;
using Shared.RestClient.Interfaces;
using System.Net.Http.Json;

namespace Shared.RestClient.Repositories
{
    internal class ProductClient(HttpClient httpClient, string controller, INotification notification) : BaseClient(httpClient, controller, notification), IProductClient
    {
        public async Task UpdateOrder(UpdateProductsOrderCollection parameters)
        {
            var res = await _httpClient.PatchAsJsonAsync($"api/{_controller}/orders", parameters);
            if (res.IsSuccessStatusCode)
                _notification.NotifyUpdate();
            else
                _notification.Error(res.StatusCode.ToString());
        }
    }
}
