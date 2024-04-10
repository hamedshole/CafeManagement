using Shared.Model;
using Shared.RestClient.Interfaces;
using System.Net.Http.Json;

namespace Shared.RestClient.Repositories
{
    internal class BaseClient(HttpClient httpClient, string controller, INotification notification) : IBaseClient
    {
        protected readonly HttpClient _httpClient = httpClient;
        protected readonly string _controller = controller;
        protected readonly INotification _notification = notification;

        public async Task CreateAsync<T>(T createParameter) where T : class
        {
            try
            {
                await _httpClient.PostAsJsonAsync("api/"+_controller, createParameter);
                 _notification.NotifyCreate();
            }
            catch (Exception)
            {

            }

        }

        public async Task DeleteAsync(int id)
        {
           
                await _httpClient.DeleteAsync(string.Format("{0}/{1}/{2}","api", _controller, id));
                 _notification.NotifyDelete();
            
           
        }

        public async Task<T> Get<T>(int id) where T : class
        {
           
                var res = await _httpClient.GetFromJsonAsync<T>(string.Format("{0}/{1}/{2}","api", _controller, id));
                return res;
           
        }

        public async Task<PagedList<T>> GetPagedList<T>(string parameters) where T : class
        {
           
                return await _httpClient.GetFromJsonAsync<PagedList<T>>("api/"+_controller + parameters);


           
          
        }

        public async Task UpdateAsync<T>(int id,T updatePArameter) where T : class
        {
            
               var t= await _httpClient.PutAsJsonAsync<T>("api/" + _controller+"/"+id, updatePArameter);
                _notification.NotifyUpdate();
            
           
        }
    }
}
