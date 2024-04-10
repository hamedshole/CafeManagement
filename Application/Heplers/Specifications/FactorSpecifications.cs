using Domain.Entities;
using Shared.Model;

namespace Application.Helpers.Specifications
{
    public class FactorSpecifications:BaseSpecification<InventoryFactorEntity>
    {
        public FactorSpecifications AddFilters(ListFactorParameter parameter)
        {
            if(parameter.Inventory.HasValue)
                SetFilterCondition(x=>x.InventoryId==parameter.Inventory);
            if (parameter.User.HasValue)
                SetFilterCondition(x => x.UserId == parameter.User);
            if (!string.IsNullOrEmpty(parameter.Number) )
                SetFilterCondition(x=>x.Number.Contains(parameter.Number));
            return this;
        }
        public FactorSpecifications AddIncludes()
        {
            AddInclude(x => x.Items);
            return this;
        }
    }
}
