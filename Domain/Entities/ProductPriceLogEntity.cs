using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class ProductPriceLogEntity : EntityBase
    {
        public int ProductId { get; private set; }
        public ProductEntity? Product { get; private set; }
        public Money Price { get; private set; }
        public DateOnly StartTime { get; private set; }
        public DateOnly? EndTime { get; private set; }
        public ProductPriceLogEntity()
        {
            
        }
        public ProductPriceLogEntity(int productId, long price)
        {
            ProductId = productId;
            Price = new Money(price);
            StartTime = DateOnly.FromDateTime(DateTime.Now);
        }
        public ProductPriceLogEntity(ProductEntity product, long price)
        {
            Product = product;
            Price = new Money(price);
            StartTime = DateOnly.FromDateTime(DateTime.Now);
        }
        public void PriceEnded()
        {
            EndTime = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
