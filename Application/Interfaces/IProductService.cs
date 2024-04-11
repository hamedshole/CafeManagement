using Domain.Entities;
using Shared.Model;

namespace Application.Interfaces
{
    public interface IProductService:IBaseService<ProductEntity,ProductModel,ProductDetailModel>
    {
        Task UpdatePrice(UpdateProductPriceParameter parameter);
        Task<ICollection<PriceLogModel>> ProductPriceLogs(int Id, DatePeriodParameter date);
        Task UpdateOrder(UpdateProductsOrderCollection parameter);
    }
}
