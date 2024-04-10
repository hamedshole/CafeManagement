using Domain.Entities;
using Shared.Model;

namespace Application.Helpers.Specifications
{
    public class InventorySpecifications:BaseSpecification<InventoryEntity>
    {
        public InventorySpecifications AddFilters(ListInventoryParameter parameter)
        {
            if(!string.IsNullOrEmpty(parameter.Title))
                SetFilterCondition(x=>x.Title.Contains(parameter.Title));
          
            if(parameter.IsActive.HasValue )
                SetFilterCondition(x=>x.IsActive==parameter.IsActive.Value);
            return this;
        }
    }
}
