using Shared.Model;
using Shared.RestClient.Interfaces;
using System.Net.Http.Json;

namespace Shared.RestClient.Repositories
{
	internal class CategoryClient(HttpClient httpClient, string controller, INotification notification) : BaseClient(httpClient, controller, notification), ICategoryClient
	{
        public async Task UpdateOrder(UpdateCategoryOrderParameterCollection parameters)
		{
			var res= await _httpClient.PatchAsJsonAsync($"api/{_controller}/orders", parameters);
			if (res.IsSuccessStatusCode)
				_notification.NotifyUpdate();
			else
				_notification.Error(res.StatusCode.ToString());
		}

		public async Task<ICollection<ProductModel>> GetProducts(int id)
		{
			var res = await _httpClient.GetFromJsonAsync<ICollection<ProductModel>>($"api/{_controller}/{id}/products");
			return res;
		}
	}
}
