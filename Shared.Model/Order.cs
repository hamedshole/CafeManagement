namespace Shared.Model
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string State { get; set; }
        public string? Customer { get; set; }
        public string Table { get; set; }
        public string TotalPrice { get; set; }
        public OrderModel()
        {
            
        }
    }
    public class CreateOrderItemAdditiveParameter
    {
        public int Id { get; set; }
        public int Amount { get; set; }
    }
    public class CreateOrderItemParameter
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public bool HasAdditive { get; set; }
        public ICollection<CreateOrderItemAdditiveParameter>? Additives { get; set; }
        public CreateOrderItemParameter()
        {
            
        }
    }
    public class CreateOrderParameter
    {
        public int? Customer { get; set; }
        public int Table { get; set; }
        public ICollection<CreateOrderItemParameter> Items{ get; set; }
        public CreateOrderParameter()
        {
            
        }
    }
    public class ListOrderParameter:PagingParameter
    {
        public byte? State { get; set; }
        public int? Customer { get; set; }
        public int? Table { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public ListOrderParameter()
        {
            
        }
    }
}
