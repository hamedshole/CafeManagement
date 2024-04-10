namespace Shared.Model
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string? Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Birthday { get; set; }
        public CustomerModel()
        {
            
        }

    }
    public class CreateCustomerParameter
    {
        public int Code { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public byte? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
    }
    public class UpdateCustomerParameter
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public byte? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
    }
    public class ListCustomerParameter : PagingParameter
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
