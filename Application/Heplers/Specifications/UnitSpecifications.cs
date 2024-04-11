using Domain.Entities;
using Shared.Model;

namespace Application.Helpers.Specifications
{
    public class UnitSpecifications : BaseSpecification<UnitEntity>
    {
        public UnitSpecifications AddFilters(ListUnitParameter parameter)
        {
            if (parameter.ParentId.HasValue && parameter.ParentId.Value > 0)
                SetFilterCondition(x => x.ParentId == parameter.ParentId);
            if (!string.IsNullOrEmpty(parameter.Title))
                SetFilterCondition(x => x.Title.Contains(parameter.Title));
            return this;
        }
        public UnitSpecifications AddIncludes()
        {
            AddInclude(nameof(UnitEntity.Parent));
            return this;
        }
    }

}
