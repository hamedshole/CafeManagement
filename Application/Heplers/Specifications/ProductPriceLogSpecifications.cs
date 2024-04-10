using Application.Helpers.Specifications;
using Domain.Entities;
using Shared.Model;

namespace Application.Heplers.Specifications
{
    internal class ProductPriceLogSpecifications : BaseSpecification<ProductPriceLogEntity>
    {
        public ProductPriceLogSpecifications AddFilters(int id, DatePeriodParameter? date)
        {
            SetFilterCondition(x => x.ProductId == id);
            if (date is DatePeriodParameter dp)
            {
                if (dp.StartDate is DateOnly dps)
                    SetFilterCondition(x => x.StartTime >= dps && x.EndTime <= dps);
                if (dp.StartDate is DateOnly dpe)
                    SetFilterCondition(x => (x.StartTime <= dpe && !x.EndTime.HasValue) || (x.StartTime <= dpe && x.EndTime <= dpe));
            }
            return this;
        }
        public ProductPriceLogSpecifications LastPrice(int id)
        {
            ApplyOrderByDescending(x=>x.Id);
            SetFilterCondition(x=>x.ProductId == id);
            SetFilterCondition(x => !x.EndTime.HasValue);
            return this;
        }
    }
}
