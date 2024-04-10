using Domain.Entities;
using Shared.Model;

namespace Application.Interfaces
{
    public interface IInventoryService:IBaseService<InventoryEntity,InventoryModel>
    {
    }
}
