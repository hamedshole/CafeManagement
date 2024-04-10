using Domain.Entities;
using Shared.Model;

namespace Application.Helpers.Specifications
{
    public class ProductCategorySpecifications:BaseSpecification<ProductCategoryEntity>
    {
        public ProductCategorySpecifications AddFilters(ListProductCategoryParameter parameter)
        {
            if(!string.IsNullOrEmpty(parameter.Title))
                SetFilterCondition(x=>x.Title.Contains(parameter.Title));
          
            if(parameter.IsActive.HasValue )
                SetFilterCondition(x=>x.IsActive==parameter.IsActive.Value);
            return this;
        }
    }
}
