using Domain.Entities;
using Shared.Model;

namespace Application.Helpers.Specifications
{
    public class MaterialSpecifications:BaseSpecification<MaterialEntity>
    {
        public MaterialSpecifications AddFilters(ListMaterialParameter parameter)
        {
            if(!string.IsNullOrEmpty(parameter.Title))
                SetFilterCondition(x=>x.Title.Contains(parameter.Title));
            if(parameter.UnitId.HasValue && parameter.UnitId.Value > 0)
                SetFilterCondition(x=>x.UnitId==parameter.UnitId.Value);
            return this;
        }
        public MaterialSpecifications AddIncludes()
        {
            AddInclude(nameof(MaterialEntity.Unit));
            return this;
        }
    }
}
