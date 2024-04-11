namespace Shared.Model
{
    public class AdditiveModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Material { get; set; }
        public string Amount { get; set; }
        public string Price { get; set; }
        public bool IsActive { get; set; }
    }
    public class AdditiveSelectModel
    {
        public AdditiveSelectModel()
        {
            
        }
        public AdditiveSelectModel(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public int Id { get; set; }
        public string Title { get; set; }
    }
    public class AdditiveDetailModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MaterialId { get; set; }
        public long Amount { get; set; }
        public long Price { get; set; }
        public bool IsActive { get; set; }
    }
    public class CreateAdditiveParameter
    {
        public string Title { get; set; }
        public int MaterialId { get; set; }
        public long Amount { get; set; }
        public long Price { get; set; }
        public bool IsActive { get; set; }
    }
    public class UpdateAdditiveParameter
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MaterialId { get; set; }
        public long Amount { get; set; }
        public long Price { get; set; }
        public bool IsActive { get; set; }
    }
    public class ListAdditiveParameter:PagingParameter
    {
        public string? Title { get; set; }
        public int? MaterialId { get; set; }
        public bool? IsActive { get; set; }
        public override string ToString()
        {
            string? route = string.Empty;
            if (!string.IsNullOrEmpty(Title))
                route = string.Format(string.Format("{0}={1}", nameof(Title), Title));
            if (IsActive.HasValue)
                route = route + "&" + string.Format("{0}={1}", nameof(IsActive), IsActive);
            if (MaterialId.HasValue)
                route = route + "&" + string.Format("{0}={1}", nameof(MaterialId), MaterialId);
            return route + base.ToString();
        }
    }
}
