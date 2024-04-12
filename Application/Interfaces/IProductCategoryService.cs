using Domain.Entities;
using Shared.Model;

namespace Application.Interfaces
{
    public interface IProductCategoryService:IBaseService<ProductCategoryEntity,ProductCategoryModel>
    {
        Task UpdateOrder(UpdateCategoryOrderParameterCollection parameters);
        Task<ICollection<ProductModel>> GetProducts(int id);
        Task<ICollection<MenuCategoryModel>> GetMenu();
    }
}
