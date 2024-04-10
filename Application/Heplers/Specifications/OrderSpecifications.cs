using Domain.Entities;
using Shared.Model;

namespace Application.Helpers.Specifications
{
    public class OrderSpecifications : BaseSpecification<OrderEntity>
    {
        public OrderSpecifications AddFilter(ListOrderParameter parameter)
        {
            if (parameter.Customer.HasValue)
                SetFilterCondition(x => x.CustomerId==parameter.Customer);
            if (parameter.Table.HasValue)
                SetFilterCondition(x => x.TableId == parameter.Customer);
            if (parameter.Start.HasValue)
                SetFilterCondition(x => x.Time >= parameter.Start);
            if (parameter.End.HasValue)
                SetFilterCondition(x => x.Time <= parameter.End);
            if (parameter.State.HasValue)
                SetFilterCondition(x => x.State.Value == parameter.State);

            return this;
        }
        public OrderSpecifications AddIncludes()
        {
            AddInclude(x => x.Table);
            AddInclude(x => x.Customer);

            return this;
        }
    }
}
