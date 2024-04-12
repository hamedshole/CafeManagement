namespace Shared.Model
{
    public class ProductCategoryModel
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
        public string? Description { get; set; }
    }
    
    public class CreateProductCategoryParameter
    {
        public int Order { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public string Image{ get; set; }
        public string? Description { get; set; }
    }
    public class UpdateProductCategoryParameter
    {
        public UpdateProductCategoryParameter(int id, int order, string title, bool isActive, string image, string? description)
        {
            Id = id;
            Order = order;
            Title = title;
            IsActive = isActive;
            Image = image;
            Description = description;
        }

        public int Id { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
        public string? Description { get; set; }

    }
    public class UpdateCategoryOrderParameter
    {
        public int CategoryId { get; set; }
        public int Order { get; set; }
    }
    public class UpdateCategoryOrderParameterCollection
    {
        public ICollection<UpdateCategoryOrderParameter> Items { get; set; }
    }
    public class ListProductCategoryParameter:PagingParameter
    {
        public string? Title { get; set; }
        public bool? IsActive { get; set; }
        public override string ToString()
        {
            string? route = string.Empty;
            if (!string.IsNullOrEmpty(Title))
                route = string.Format(string.Format("{0}={1}", nameof(Title), Title));
            if (IsActive.HasValue)
                route = route + "&" + string.Format("{0}={1}", nameof(IsActive), IsActive);
            return route + base.ToString();
        }
    }
    public class MenuCategoryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public ICollection<MenuProductModel> Products { get; set; }
    }
}
