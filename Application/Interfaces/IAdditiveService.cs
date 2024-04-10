using Domain.Entities;
using Shared.Model;

namespace Application.Interfaces
{
    public interface IAdditiveService:IBaseService<AdditiveEntity,AdditiveModel,AdditiveDetailModel>
    {
        Task UpdatePrice(UpdateAdditivePriceParameter parameter);
        Task<ICollection<PriceLogModel>> AdditivePriceLogs(int Id, DatePeriodParameter date);
    }
}
