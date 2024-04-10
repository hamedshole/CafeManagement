namespace Shared.Model
{
    public class UserModel
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Birthday { get; set; }
        public string Username { get; set; }
        public UserModel()
        {
            
        }
    }
    public class CreateUserRoleParameter
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
    public class CreateUserParameter
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Gender{ get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<CreateUserRoleParameter> Roles { get; set; }
        public CreateUserParameter()
        {
            
        }
    }
    public class UpdateUserParameter
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<CreateUserRoleParameter>? Roles { get; set; }
        public UpdateUserParameter()
        {

        }
    }

    public class  ListUserParameter:PagingParameter
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Username { get; set; }
    }
}
