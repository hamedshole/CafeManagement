namespace Shared.Model
{
    public class InventoryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string IsActive { get; set; }
        public InventoryModel()
        {
            
        }
    }
    public class CreateInventoryParameter
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public CreateInventoryParameter()
        {
            
        }
    }
    public class UpdateInventoryParameter
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
    public class ListInventoryParameter:PagingParameter
    {
        public string? Title { get; set; }
        public bool? IsActive { get; set; }
    }
}
