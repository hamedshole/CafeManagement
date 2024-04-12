using Shared.Model;

namespace Shared.RestClient.Interfaces
{
    public interface ICategoryClient:IBaseClient
    {
        Task UpdateOrder(UpdateCategoryOrderParameterCollection parameters);
        Task<ICollection<ProductModel>> GetProducts(int id);
        Task<ICollection<MenuCategoryModel>> GetMenu();
    }
}
