using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class MaterialPriceLogEntity : EntityBase
    {
        public int MaterialId { get; private set; }
        public MaterialEntity? Material { get; private set; }
        public Money BuyPrice { get; private set; }
        public Money SellPrice { get; private set; }
        public DateOnly StartTime { get; private set; }
        public DateOnly? EndTime { get; private set; }
        public MaterialPriceLogEntity()
        {
            BuyPrice = new Money(0);
            SellPrice = new Money(0);
        }
        public MaterialPriceLogEntity(int materialId, long buyPrice, long sellPrice)
        {
            MaterialId = materialId;
            SellPrice = new Money(sellPrice);
            BuyPrice = new Money(buyPrice);
            StartTime = DateOnly.FromDateTime(DateTime.Now);
        }
        public void PriceEnded()
        {
            EndTime = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
