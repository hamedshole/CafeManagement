namespace Shared.Model
{
    public class TableModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
    public class CreateTableParameter
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
    public class UpdateTableParameter
    {
        public UpdateTableParameter(int id, string title, bool isActive)
        {
            Id = id;
            Title = title;
            IsActive = isActive;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
    public class ListTableParameter : PagingParameter
    {
        public string? Title { get; set; }
        public bool? IsActive { get; set; }
        public override string ToString()
        {
            string? route = string.Empty;
            if (!string.IsNullOrEmpty(Title))
                route = string.Format(string.Format("{0}={1}",nameof(Title),Title));
            if (IsActive.HasValue)
                route = route + "&" + string.Format("{0}={1}", nameof(IsActive), IsActive);
            return route + base.ToString();
        }
    }

}
