using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class MaterialEntity : EntityBase
    {
        public string Title { get; set; }
        public int UnitId { get; set; }
        public UnitEntity? Unit { get; set; }
        public Money UnitPrice { get; set; }
        public bool IsActive { get; set; }

        public MaterialEntity()
        {
            Title = string.Empty;
        }
        public MaterialEntity(string title,long unitPrice, int unitId, bool isActive)
        {
            Title = title;
            UnitId = unitId;
            UnitPrice=new Money(unitPrice);
            IsActive = isActive;
        }
        public MaterialEntity(int id, string title,long unitPrice, int unitId, bool isActive) : base(id)
        {
            Title = title;
            UnitPrice=new Money(unitPrice);
            UnitId = unitId;
            IsActive = isActive;
        }
    }
}
