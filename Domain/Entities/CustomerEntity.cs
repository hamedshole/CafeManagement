using Domain.Common;

namespace Domain.Entities
{
    public class CustomerEntity:EntityBase
    {
        public string Code { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string? PhoneNumber { get; set; }
        public CustomerEntity()
        {
            
        }

        public CustomerEntity(string code,byte? gender, string? firstName, string lastName, DateTime? birthday, string? phoneNumber)
        {
            Gender=new Gender(gender);
            Code = code;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            PhoneNumber = phoneNumber;

        }
        public CustomerEntity(int id,string code,byte? gender, string? firstName, string lastName, DateTime? birthday, string? phoneNumber):base(id)
        {
            Gender = new Gender(gender);
            Code = code;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            PhoneNumber = phoneNumber;
        }
    }
}
