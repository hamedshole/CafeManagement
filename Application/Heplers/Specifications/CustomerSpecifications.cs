using Domain.Entities;
using Shared.Model;

namespace Application.Helpers.Specifications
{
    public class CustomerSpecifications : BaseSpecification<CustomerEntity>
    {
        public CustomerSpecifications AddFilters(ListCustomerParameter parameter)
        {
            if (!string.IsNullOrEmpty(parameter.FirstName))
                SetFilterCondition(x => !string.IsNullOrEmpty(x.FirstName) && x.FirstName.Contains(parameter.FirstName));
            if (!string.IsNullOrEmpty(parameter.LastName))
                SetFilterCondition(x => x.LastName.Contains(parameter.LastName));
            if (!string.IsNullOrEmpty(parameter.PhoneNumber))
                SetFilterCondition(x => !string.IsNullOrEmpty(x.PhoneNumber) && x.PhoneNumber.Contains(parameter.PhoneNumber));
            if (parameter.Gender.HasValue)
                SetFilterCondition(x => x.Gender.Value == parameter.Gender.Value);
            if (parameter.Birthday.HasValue)
                SetFilterCondition(x => x.Birthday == parameter.Birthday.Value);
            return this;
        }
    }
}
