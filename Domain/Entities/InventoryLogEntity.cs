using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class InventoryLogEntity : EntityBase
    {
        public InOutState InOut { get; private set; }
        public DateTime Time { get; private set; }
        public int InventoryId { get; private set; }
        public InventoryEntity? Inventory { get; private set; }
        public int MaterialId { get; private set; }
        public MaterialEntity? Material { get; private set; }
        public Amount Amount { get; private set; }
        public int UnitId { get; private set; }
        public UnitEntity? Unit { get; private set; }

        public InventoryLogEntity()
        {
            Amount = new Amount(0);
            InOut = new InOutState(false);
        }
        public static InventoryLogEntity TakeIn(int InventoryId, int MaterialId, long Amount, int UnitId)
        {
            return new InventoryLogEntity()
            {
                InOut = new InOutState(true),
                Time = DateTime.Now,
                InventoryId = InventoryId,
                MaterialId = MaterialId,
                Amount = new Amount(Amount),
                UnitId = UnitId
            };
        }
        public static InventoryLogEntity TakeOut(int InventoryId, int MaterialId, long Amount, int UnitId)
        {
            return new InventoryLogEntity()
            {
                InOut = new InOutState(false),
                Time = DateTime.Now,
                InventoryId = InventoryId,
                MaterialId = MaterialId,
                Amount = new Amount(Amount),
                UnitId = UnitId
            };
        }
    }
}
