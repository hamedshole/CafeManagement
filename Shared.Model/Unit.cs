namespace Shared.Model
{
    public class UnitModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Parent { get; set; }
        public long? Relation { get; set; }
        public bool IsActive { get; set; }
    }
    public class UnitDetailModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
        public long? Relation { get; set; }
        public bool IsActive { get; set; }
    }
    public class CreateUnitParameter
    {
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public long? Relation { get; set; }
        public bool IsActive { get; set; }
    }
    public class UpdateUnitParameter
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public long? Relation { get; set; }
        public bool IsActive { get; set; }

        public UpdateUnitParameter(int id, string title, int? parentId, long? relation, bool isActive)
        {
            Id = id;
            Title = title;
            ParentId = parentId;
            Relation = relation;
            IsActive = isActive;
        }
    }
    public class ListUnitParameter:PagingParameter
    {
        public string? Title { get; set; }
        public int? ParentId { get; set; }
        public bool? IsActive { get; set; }
        public override string ToString()
        {
            string? route = string.Empty;
            if (!string.IsNullOrEmpty(Title))
                route = string.Format(string.Format("{0}={1}",nameof(Title),Title));
            if (IsActive.HasValue)
                route = route + "&" + string.Format("{0}={1}", nameof(IsActive), IsActive);
            if (ParentId.HasValue)
                route = route + "&" + string.Format("{0}={1}", nameof(ParentId), ParentId);
            return route + base.ToString();
        }
    }
}
