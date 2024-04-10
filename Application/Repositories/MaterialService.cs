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
    internal class MaterialService(IRepository<MaterialEntity> repository, IMapper mapper) : BaseService<MaterialEntity, MaterialModel,MaterialDetailModel>(repository, mapper), IMaterialService
    {
        public async Task<ICollection<PriceLogModel>> MaterialPriceLogs(int id, DatePeriodParameter date)
        {
            MaterialPriceLogSpecifications materialPriceLogSpecifications = new();
            materialPriceLogSpecifications.AddFilters(id, date);
            var res = _repository.DataUnit.MaterialPriceLogs.Get(materialPriceLogSpecifications)
                 .ProjectTo<PriceLogModel>(_mapper.ConfigurationProvider)
                 .ToList();
            return await Task.FromResult(res);
        }

        public async Task UpdatePrice(UpdateMaterialPriceParameter parameter)
        {
            await SetPrice(parameter);
            await UpdtePriceLog(parameter);
            await _repository.DataUnit.SaveChangesAsync();
        }

        private async Task SetPrice(UpdateMaterialPriceParameter parameter)
        {
            MaterialEntity entity = await _repository.GetByIdAsync(parameter.MaterialId) ?? throw new NotFoundException(nameof(AdditiveEntity), parameter.MaterialId);
            await _repository.ExecuteUpdateAsync(x => x.Id == parameter.MaterialId, (nameof(entity.UnitPrice), new Money(parameter.BuyPrice)));

        }
        private async Task UpdtePriceLog(UpdateMaterialPriceParameter parameter)
        {
            MaterialPriceLogEntity materialPrice = new(parameter.MaterialId, parameter.BuyPrice, parameter.SellPrice);
            await _repository.DataUnit.MaterialPriceLogs.ExecuteUpdateAsync(x => x.MaterialId == parameter.MaterialId && x.EndTime == null, (nameof(AdditivePriceLogEntity.EndTime), DateOnly.FromDateTime(DateTime.Now)));
            await _repository.DataUnit.MaterialPriceLogs.CreateAsync(materialPrice);
        }
    }
}
