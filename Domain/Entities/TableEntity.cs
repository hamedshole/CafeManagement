using Domain.Common;

namespace Domain.Entities
{
    public class TableEntity:EntityBase
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }

        public TableEntity(string title, bool isActive)
        {
            Title = title;
            IsActive = isActive;
        }
        public TableEntity(int id,string title, bool isActive):base(id)
        {
            Title = title;
            IsActive = isActive;
        }
    }
}
