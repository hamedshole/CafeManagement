namespace Domain.Common
{
    public class EntityBase
    {
        public int Id { get;private set; }
        public bool IsDeleted { get;private set; }
        public EntityBase()
        {
            
        }
        public EntityBase(int id)
        {
            Id = id;
            IsDeleted = false;
        }
        public void Delete()=>IsDeleted = true;
    }
}
