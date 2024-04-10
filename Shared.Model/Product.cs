namespace Shared.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public string? Description { get; set; }
        public bool IsNew { get; set; }
        public bool IsActive { get; set; }
    }
    public class CreateProductParameter
    {
        public int Order { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public long Price { get; set; }
        public string? Description { get; set; }
        public bool IsNew { get; set; }
        public bool IsActive { get; set; }
        public ICollection<CreateProductMaterialParameter>? Materials { get; set; }
        public ICollection<int>? Additives { get; set; }
    }
    public class UpdateProductParameter
    {
        public UpdateProductParameter(int id, int order, int categoryId, string title, string image, long price, string? description, bool isNew, bool isActive, ICollection<CreateProductMaterialParameter>? materials, ICollection<int>? additives)
        {
            Id = id;
            Order = order;
            CategoryId = categoryId;
            Title = title;
            Image = image;
            Price = price;
            Description = description;
            IsNew = isNew;
            IsActive = isActive;
            Materials = materials;
            Additives = additives;
        }

        public int Id { get; set; }
        public int Order { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public long Price { get; set; }
        public string? Description { get; set; }
        public bool IsNew { get; set; }
        public bool IsActive { get; set; }
        public ICollection<CreateProductMaterialParameter>? Materials { get; set; }
        public ICollection<int>? Additives { get; set; }
    }
    public class CreateProductMaterialParameter
    {
        public int MaterialId { get; set; }
        public long Amount { get; set; }
    }
   
    public class ListProductParameter:PagingParameter
    {
        public int? CategoryId { get; set; }
        public string? Title { get; set; }
        public long? Price { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsNew { get; set; }
    }
    public class UpdateProductPriceParameter
    {
        public UpdateProductPriceParameter()
        {
            
        }
        private int Id { get; }
        public long Price { get; set; }
        public UpdateProductPriceParameter(int id,long price)
        {
            Id = id;
            Price = price;
        }
        public int GetId()
        {
            return Id;
        }
    }
  

}
