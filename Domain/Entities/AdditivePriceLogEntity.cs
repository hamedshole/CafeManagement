using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class AdditivePriceLogEntity : EntityBase
    {
        public int AdditiveId { get; private set; }
        public AdditiveEntity? Additive { get; private set; }
        public Money Price { get; private set; }
        public DateOnly StartTime { get; private set; }
        public DateOnly? EndTime { get; private set; }
        public AdditivePriceLogEntity()
        {
            
        }
        public AdditivePriceLogEntity(int additiveId, long price, DateOnly startTime)
        {
            AdditiveId = additiveId;
            Price = new Money(price);
            StartTime = startTime;
        }
        public void PriceEnded()
        {
            EndTime = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
