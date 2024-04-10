using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class ProductEntity : EntityBase
    {
        public int Order { get; private set; }
        public int CategoryId { get; private set; }
        public ProductCategoryEntity? Category { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public string Image { get; private set; }
        public bool IsNew { get; private set; }
        public Money Price { get; private set; }
        public bool IsActive { get; private set; }
        public ICollection<ProductMaterialEntity>? Materials { get;private set; }
        public ICollection<ProductAdditiveEntity>? Additives { get; private set; }
        public void UpdatePrice(long price)=>Price=new Money(price);
        public void SetMaterials(ICollection<ProductMaterialEntity> materials) =>Materials=materials;
        public void SetAdditives(ICollection<ProductAdditiveEntity> additives) => Additives = additives;

        public ProductEntity()
        {
            Title = string.Empty;
            Image = string.Empty;
            Price = new Money(0);
            Category = null;
        }

        public ProductEntity(int order, int categoryId, string title, string? description, string image, bool isNew, long price, bool isActive)
        {
            Order = order;
            CategoryId = categoryId;
            Title = title;
            Description = description;
            Image = image;
            IsNew = isNew;
            Price = new Money(price);
            IsActive = isActive;

        }
        public ProductEntity(int id, int order, int categoryId, string title, string? description, string image, bool isNew, long price, bool isActive) : base(id)
        {
            Order = order;
            CategoryId = categoryId;
            Title = title;
            Description = description;
            Image = image;
            IsNew = isNew;
            Price = new Money(price);
            IsActive = isActive;

        }
    }
}