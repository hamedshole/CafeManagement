using Domain.Common;

namespace Domain.Entities
{
    public class UserRoleEntity:EntityBase
    {
        public int UserId { get; set; }
        public UserEntity? User { get; set; }
        public int RoleId { get; set; }
        public RoleEntity? Role { get; set; }
        public bool IsActive { get; set; }
        public UserRoleEntity()
        {
            
        }

        public UserRoleEntity(int userId,  int roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}