using Domain.Common;

namespace Domain.Entities
{
    public class UserEntity : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<UserRoleEntity>? Roles { get; set; }
        public UserEntity()
        {
            
        }

        public UserEntity(string firstName, string lastName, Gender gender, string? phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            PhoneNumber = phoneNumber;
        }
        public UserEntity(int id,string firstName, string lastName, Gender gender, string? phoneNumber):base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            PhoneNumber = phoneNumber;
        }
    }
}