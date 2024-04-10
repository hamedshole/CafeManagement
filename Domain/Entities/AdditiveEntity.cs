using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class AdditiveEntity : EntityBase
    {
        public string Title { get; set; }
        public int MaterialId { get; set; }
        public MaterialEntity? Material { get; set; }
        public Money Price { get; set; }
        public Amount Amount { get; set; }
        public bool IsActive { get; set; }

     
        public AdditiveEntity()
        {
            Title=string.Empty;
            Amount=new Amount(0);
        }

        public AdditiveEntity(int id, string title, int materialId, long amount,long price,bool isActive) : base(id)
        {
            Title = title;
            MaterialId = materialId;
            IsActive = isActive;
            Amount = new Amount(amount);
            Price=new Money(price);
        }
        public AdditiveEntity(string title, int materialId, long amount,long price,bool isActive)
        {
            Title = title;
            MaterialId = materialId;
            IsActive = isActive;
            Amount = new Amount(amount);
            Price=new Money(price);
        }
    }
    public class UpdateAdditivePriceParameter
    {
        public int AdditiveId { get; set; }
        public long Price { get; set; }
    }
}