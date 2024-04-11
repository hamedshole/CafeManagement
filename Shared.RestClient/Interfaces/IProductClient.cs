using Shared.Model;

namespace Shared.RestClient.Interfaces
{
    public interface IProductClient:IBaseClient
    {
        Task UpdateOrder(UpdateProductsOrderCollection parameters);

    }
}
