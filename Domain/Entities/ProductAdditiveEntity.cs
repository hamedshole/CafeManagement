using Domain.Common;

namespace Domain.Entities
{
    public class ProductAdditiveEntity : EntityBase
    {
        public int ProductId { get; set; }
        public ProductEntity? Product { get; set; }
        public int AdditiveId { get; set; }
        public AdditiveEntity? Additive { get; set; }

        public ProductAdditiveEntity(ProductEntity product, int additiveId)
        {
            Product = product;
            AdditiveId = additiveId;
        }

        public ProductAdditiveEntity()
        {
        }
        public ProductAdditiveEntity(int id, int productId, int additiveId) : base(id)
        {
            ProductId = productId;
            AdditiveId = additiveId;
        }

        public ProductAdditiveEntity(int productId, int additiveId)
        {
            ProductId = productId;
            AdditiveId = additiveId;
        }
    }
}