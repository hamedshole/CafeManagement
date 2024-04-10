namespace Shared.Model
{
    public class FactorModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string User { get; set; }
        public string Inventory { get; set; }
        public string TotalPrice { get; set; }
        public FactorModel()
        {
            
        }
    }
    public class CreateFactorParameter
    {
        public string Number { get; set; }
        public int UserId { get; set; }
        public int InventoryId { get; set; }
        public CreateFactorParameter()
        {
            
        }
    }

    public class ListFactorParameter:PagingParameter
    {
        public string? Number { get; set; }
        public int? User { get; set; }
        public int? Inventory { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public ListFactorParameter()
        {
            
        }
    }
}
