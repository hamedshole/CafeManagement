using Application.Helpers.Specifications;
using Domain.Entities;
using Shared.Model;

namespace Application.Heplers.Specifications
{
    internal class AdditivePriceLogSpecifications : BaseSpecification<AdditivePriceLogEntity>
    {
        public AdditivePriceLogSpecifications AddFilters(int id, DatePeriodParameter? date)
        {
            SetFilterCondition(x => x.AdditiveId == id);
            if (date is DatePeriodParameter dp)
            {
                if (dp.StartDate is DateOnly dps)
                    SetFilterCondition(x => x.StartTime >= dps && x.EndTime <= dps);
                if (dp.StartDate is DateOnly dpe)
                    SetFilterCondition(x => (x.StartTime <= dpe && !x.EndTime.HasValue) || (x.StartTime <= dpe && x.EndTime <= dpe));
            }
            return this;
        }
        public AdditivePriceLogSpecifications LastPrice(int id)
        {
            ApplyOrderByDescending(x=>x.Id);
            SetFilterCondition(x=>x.AdditiveId == id);
            SetFilterCondition(x => !x.EndTime.HasValue);
            return this;
        }
    }
}
