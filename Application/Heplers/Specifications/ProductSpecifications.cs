using Domain.Entities;
using Shared.Model;

namespace Application.Helpers.Specifications
{
    public class ProductSpecifications : BaseSpecification<ProductEntity>
    {
        public ProductSpecifications AddFilters(ListProductParameter parameter)
        {
            if (string.IsNullOrEmpty(parameter.Title))
                SetFilterCondition(x => x.Title.Contains(x.Title));
           
            if (parameter.Price.HasValue && parameter.Price.Value > 0)
                SetFilterCondition(x => x.Price.Value == parameter.Price);
            if (parameter.IsNew.HasValue)
                SetFilterCondition(x => x.IsNew == parameter.IsNew);
            if (parameter.IsActive.HasValue)
                SetFilterCondition(x => x.IsActive == parameter.IsActive);
            return this;
        }
        public ProductSpecifications IncludeCategory()
        {
            AddInclude(x => x.Category);
            return this;
        }
        public ProductSpecifications IncludeMaterials()
        {
            AddInclude(x =>  x.Materials);
            return this;
        }
        public ProductSpecifications IncludeAdditives()
        {
            AddInclude(x => x.Additives);
            return this;
        }
    }
}
