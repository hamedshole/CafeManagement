using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class InventoryFactorEntity:EntityBase
    {
        public string Number { get; set; }
        public DateTime Time { get; set; }
        public int UserId { get; set; }
        public UserEntity? User { get; set; }
        public int InventoryId { get; set; }
        public InventoryEntity? Inventory { get; set; }
        public Money TotalPrice{ get; set; }
        public ICollection<InventoryLogEntity>? Items { get; set; }
        public InventoryFactorEntity()
        {
            
        }

        public InventoryFactorEntity(string number, int userId,int inventoryId, ICollection<InventoryLogEntity>? items)
        {
            InventoryId = inventoryId;
            Number = number;
            UserId = userId;
            Items = items;
        }
    }
}
