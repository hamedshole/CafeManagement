using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class ProductMaterialEntity : EntityBase
    {
        public int ProductId { get; set; }
        public ProductEntity? Product { get; set; }
        public int MaterialId { get; set; }
        public MaterialEntity? Material { get; set; }
        public Amount Amount { get; set; }
        public ProductMaterialEntity()
        {
            Amount = new Amount(0);
        }

        public ProductMaterialEntity(ProductEntity? product, int materialId, long amount)
        {
            Product = product;
            MaterialId = materialId;
            Amount = new Amount(amount);
        }

        public ProductMaterialEntity(int productId, int materialId, long amount)
        {
            ProductId = productId;
            MaterialId = materialId;
            Amount = new Amount(amount);
        }
        public ProductMaterialEntity(int id, int productId, int materialId, long amount) : base(id)
        {
            ProductId = productId;
            MaterialId = materialId;
            Amount = new Amount(amount);
        }
    }
}