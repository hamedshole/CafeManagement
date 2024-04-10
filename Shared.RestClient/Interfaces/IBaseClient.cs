using Shared.Model;

namespace Shared.RestClient.Interfaces
{
    public interface IBaseClient
    {
        public Task CreateAsync<T>(T createParameter) where T : class;
        public Task UpdateAsync<T>(int id,T updatePArameter) where T : class;
        public Task DeleteAsync(int id);
        public Task<PagedList<T>> GetPagedList<T>(string parameters) where T : class;
        public Task<T> Get<T>(int id)where T : class;
    }
}
