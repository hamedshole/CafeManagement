using Domain.Entities;
using Shared.Model;

namespace Application.Interfaces
{
    public interface IOrderService:IBaseService<OrderEntity,OrderModel>
    {
    }
}
