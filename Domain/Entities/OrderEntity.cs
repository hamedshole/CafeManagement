using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class OrderEntity : EntityBase
    {
        public OrderState State { get;private set; }
        public int UserId { get;private set; }
        public UserEntity? User { get;private set; }
        public int? CustomerId { get;private set; }
        public CustomerEntity? Customer { get;private set; }
        public int TableId { get;private set; }
        public TableEntity? Table { get;private set; }
        public DateTime Time { get;private set; }
        public Money TotalPrice { get;private set; }

        public ICollection<OrderItemEntity>? Items { get; set; }
        public OrderEntity()
        {
            
        }
        public void Cancel()=>State=OrderState.Cancelled;
        public void Progress()=>State=OrderState.InProgress;
        public OrderEntity(int userId, int? customerId, int tableId, long totalPrice, ICollection<OrderItemEntity>? items)
        {
            Time = DateTime.Now;
            State = OrderState.InQeue;
            UserId = userId;
            CustomerId = customerId;
            TableId = tableId;
            TotalPrice = new Money (totalPrice);
            Items = items;
        }
    }
}
