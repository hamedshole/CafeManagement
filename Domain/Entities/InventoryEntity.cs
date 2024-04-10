using Domain.Common;

namespace Domain.Entities
{
    public class InventoryEntity:EntityBase
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public InventoryEntity()
        {
            
        }

        public InventoryEntity(string title, bool isActive)
        {
            Title = title;
            IsActive = isActive;
        }
        public InventoryEntity(int id,string title, bool isActive):base(id)
        {
            Title = title;
            IsActive = isActive;
        }
    }
}