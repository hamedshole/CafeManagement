using Domain.Entities;
using Shared.Model;

namespace Application.Interfaces
{
    public interface IMaterialService:IBaseService<MaterialEntity,MaterialModel,MaterialDetailModel>
    {
        Task UpdatePrice(UpdateMaterialPriceParameter parameter);
        Task<ICollection<PriceLogModel>> MaterialPriceLogs(int Id, DatePeriodParameter date);
    }
}
