namespace Shared.Model
{
    public class MaterialModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Unit { get; set; }
        public string UnitPrice { get; set; }
        public bool IsActive { get; set; }
    }
    public class MaterialSelectModel
    {
        public MaterialSelectModel()
        {
            
        }
        public MaterialSelectModel(int id, string title, string unit, long value)
        {
            Id = id;
            Title = title;
            Unit = unit;
            Amount = value;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Unit { get; set; }
        public long Amount { get; set; }


    }
    public class MaterialDetailModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UnitId { get; set; }
        public long UnitPrice { get; set; }
        public bool IsActive { get; set; }
    }
    public class CreateMaterialParameter
    {
        public string Title { get; set; }
        public int UnitId { get; set; }
        public long UnitPrice { get; set; }
        public bool IsActive { get; set; }
    }
    public class UpdateMaterialParameter
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UnitId { get; set; }
        public long UnitPrice { get; set; }
        public bool IsActive { get; set; }
    }
    public class ListMaterialParameter : PagingParameter
    {
        public string? Title { get; set; }
        public int? UnitId { get; set; }
        public bool? IsActive { get; set; }
        public override string ToString()
        {
            string? route = string.Empty;
            if (!string.IsNullOrEmpty(Title))
                route = string.Format(string.Format("{0}={1}",nameof(Title),Title));
            if (IsActive.HasValue)
                route = route + "&" + string.Format("{0}={1}", nameof(IsActive), IsActive);
            if (UnitId.HasValue)
                route = route + "&" + string.Format("{0}={1}", nameof(UnitId), UnitId);
            return route + base.ToString();
        }
    }

    public class UpdateMaterialPriceParameter
    {
        public int MaterialId { get; set; }
        public long BuyPrice { get; set; }
        public long SellPrice { get; set; }
    }

}
