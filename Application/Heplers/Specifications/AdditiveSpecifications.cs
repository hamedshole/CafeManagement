using Domain.Entities;
using Shared.Model;

namespace Application.Helpers.Specifications
{
    public class AdditiveSpecifications : BaseSpecification<AdditiveEntity>
    {
        public AdditiveSpecifications AddFilter(ListAdditiveParameter parameter)
        {
            if (!string.IsNullOrEmpty(parameter.Title))
                SetFilterCondition(x => x.Title.Contains(parameter.Title));
            if (parameter.IsActive.HasValue)
                SetFilterCondition(x => x.IsActive == parameter.IsActive);

            return this;
        }
        public AdditiveSpecifications AddIncludes()
        {
            AddInclude(nameof(AdditiveEntity.Material));
            return this;
        }
    }
}
