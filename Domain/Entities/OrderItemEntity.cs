using Domain.Common;

namespace Domain.Entities
{
    public class OrderItemEntity:EntityBase
    {
        public int OrderId { get; set; }
        public OrderEntity? Order { get; set; }
        public int ProductId { get; set; }
        public ProductEntity? Product { get; set; }
        public bool HasAdditive { get; set; }
        public string? Description { get; set; }
        public ICollection<OrderItemAdditiveEntity>? ItemAdditives { get; set; }

    }
}