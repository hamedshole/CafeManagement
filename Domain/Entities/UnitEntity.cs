using Domain.Common;

namespace Domain.Entities
{
    public class UnitEntity:EntityBase
    {
        public int? ParentId { get; set; }
        public UnitEntity? Parent { get; set; }
        public string Title { get; set; }
        public long? Relation { get; set; }
        public bool IsActive { get; set; }


        public ICollection<UnitEntity>? Childs { get; set; }
        public UnitEntity()
        {
            Title=string.Empty;
        }
        public UnitEntity(int id):base(id)
        {
            
        }
        public UnitEntity(int? parentId,  string title, long? relation)
        {
            ParentId = parentId;
            Title = title;
            Relation = relation;
        }
        public UnitEntity(int id,int? parentId, string title, long? relation):base(id)
        {
            ParentId = parentId;
            Title = title;
            Relation = relation;
        }

    }
}
