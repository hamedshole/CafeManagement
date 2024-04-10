using Application.Heplers.Specifications;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.ValueObjects;
using Shared.Model;

namespace Application.Repositories
{
    internal class AdditiveService(IRepository<AdditiveEntity> repository, IMapper mapper) : BaseService<AdditiveEntity, AdditiveModel,AdditiveDetailModel>(repository, mapper), IAdditiveService
    {
        public async Task<ICollection<PriceLogModel>> AdditivePriceLogs(int id, DatePeriodParameter date)
        {
            AdditivePriceLogSpecifications additivePriceLogSpecifications = new();
            additivePriceLogSpecifications.AddFilters(id, date);
            var res = _repository.DataUnit.AdditivePriceLogs.Get(additivePriceLogSpecifications)
                 .ProjectTo<PriceLogModel>(_mapper.ConfigurationProvider)
                 .ToList();
            return await Task.FromResult(res);
        }

        public async Task UpdatePrice(UpdateAdditivePriceParameter parameter)
        {
            await SetPrice(parameter);
            await UpdtePriceLog(parameter.AdditiveId, parameter.Price);
            await _repository.DataUnit.SaveChangesAsync();
        }

        private async Task SetPrice(UpdateAdditivePriceParameter parameter)
        {
            AdditiveEntity entity = await _repository.GetByIdAsync(parameter.AdditiveId) ?? throw new NotFoundException(nameof(AdditiveEntity), parameter.AdditiveId);
            await _repository.ExecuteUpdateAsync(x => x.Id == parameter.AdditiveId, (nameof(entity.Price), new Money(parameter.Price)));
        }
        private async Task UpdtePriceLog(int additiveId, long price)
        {
            AdditivePriceLogEntity additivePrice = new(additiveId, price, DateOnly.FromDateTime(DateTime.Now));
            await _repository.DataUnit.AdditivePriceLogs.ExecuteUpdateAsync(x => x.AdditiveId == additiveId && x.EndTime == null, (nameof(AdditivePriceLogEntity.EndTime), DateOnly.FromDateTime(DateTime.Now)));
            await _repository.DataUnit.AdditivePriceLogs.CreateAsync(additivePrice);
        }
    }
}
