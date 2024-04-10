using Domain.Entities;
using Shared.Model;

namespace Application.Helpers.Specifications
{
    public class TableSpecifications:BaseSpecification<TableEntity>
    {
        public TableSpecifications AddFilters(ListTableParameter parameter)
        {
            if(!string.IsNullOrEmpty(parameter.Title))
                SetFilterCondition(x=>x.Title.Contains(parameter.Title));
            if(parameter.IsActive.HasValue)
                SetFilterCondition(x=>x.IsActive==parameter.IsActive);
            return this;
        }
    }
}
