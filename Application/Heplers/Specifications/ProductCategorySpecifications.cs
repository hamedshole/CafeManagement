using Domain.Entities;
using Shared.Model;
using System.Linq.Expressions;

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
        public ProductCategorySpecifications AddFilter(Expression<Func<ProductCategoryEntity,bool>> expression)
        {
            SetFilterCondition(expression);
            return this;
        }
        public ProductCategorySpecifications IncludeProduct()
        {
            AddInclude("Products.Additives.Additive");
            return this;
        }
    }
}
