using Domain.Common;

namespace Domain.Entities
{
    public class OrderItemAdditiveEntity:EntityBase
    {
        public int OrderItemId { get; set; }
        public OrderItemEntity? OrderItem { get; set; }
        public int AdditiveId { get; set; }
        public AdditiveEntity? Additive { get; set; }
        public int Amount { get; set; }
    }
}