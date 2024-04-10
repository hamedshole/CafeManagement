using Domain.Common;

namespace Domain.Entities
{
    public class ProductCategoryEntity : EntityBase
    {
        public int Order { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; }
        public ProductCategoryEntity()
        {
            Title = string.Empty;
            Image = string.Empty;
        }
        public ProductCategoryEntity(int id, int order, string title, string image, bool isActive, string? description) : base(id)
        {
            Order = order;
            Title = title;
            Image = image;
            IsActive = isActive;
            Description = description;
        }
        public ProductCategoryEntity(int order, string title, string image, bool isActive, string? description)
        {
            Order = order;
            Title = title;
            Image = image;
            IsActive = isActive;
            Description = description;
        }
    }
}
