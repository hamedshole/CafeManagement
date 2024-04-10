using Application.Heplers.Specifications;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;
using Shared.Model;

namespace Application.Repositories
{
    internal class ProductService(IRepository<ProductEntity> repository, IMapper mapper) : BaseService<ProductEntity, ProductModel>(repository, mapper), IProductService
    {
        public override async Task CreateAsync<TParameter>(TParameter parameter)
        {
            if (parameter is CreateProductParameter p)
            {
                ProductEntity entity = _mapper.Map<ProductEntity>(p);
                if (p.Materials is ICollection<CreateProductMaterialParameter> m)
                {
                    var materials = p.Materials.Select(x => new ProductMaterialEntity(entity, x.MaterialId, x.Amount)).ToList();
                    entity.SetMaterials(materials);
                }
                if (p.Additives is ICollection<int> a)
                {
                    var additives = p.Additives.Select(x => new ProductAdditiveEntity(entity, x)).ToList();
                    entity.SetAdditives(additives);
                }
                await SetPrice(entity);
                await _repository.CreateAsync(entity);
                await _repository.DataUnit.SaveChangesAsync();
            }

        }
        private async Task SetPrice(ProductEntity productEntity)
        {
           await _repository.DataUnit.ProductPriceLogs.CreateAsync(new ProductPriceLogEntity(productEntity, productEntity.Price.Value));
        }
        public async Task<ICollection<PriceLogModel>> ProductPriceLogs(int id, DatePeriodParameter date)
        {
            ProductPriceLogSpecifications productPriceLogSpecifications = new();
            productPriceLogSpecifications.AddFilters(id, date);
            var res = _repository.DataUnit.ProductPriceLogs.Get(productPriceLogSpecifications)
                 .ProjectTo<PriceLogModel>(_mapper.ConfigurationProvider)
                 .ToList();
            return await Task.FromResult(res);
        }

        public override async Task UpdateAsync<TParameter>(TParameter parameter)
        {
            if (parameter is UpdateProductParameter updateProductParameter)
            {
                ProductEntity product = await _repository.GetByIdAsync(updateProductParameter.Id);
                if (product.Price.Value != updateProductParameter.Price)
                    await UpdatePrice(new UpdateProductPriceParameter(product.Id, updateProductParameter.Price));

            }
            await base.UpdateAsync(parameter);
        }

        public async Task UpdatePrice(UpdateProductPriceParameter parameter)
        {
            ProductPriceLogEntity productPriceLogEntity = new(parameter.GetId(), parameter.Price);
            await _repository.DataUnit.ProductPriceLogs.CreateAsync(productPriceLogEntity);
            ProductPriceLogSpecifications productPriceLogSpecifications = new();
            productPriceLogSpecifications.LastPrice(parameter.GetId());

            var lastPrice = _repository.DataUnit.ProductPriceLogs.Get(productPriceLogSpecifications).FirstOrDefault();
            if (lastPrice is ProductPriceLogEntity ppl)
            {
                ppl.PriceEnded();
                await _repository.DataUnit.ProductPriceLogs.UpdateAsync(ppl);
            }
            await _repository.ExecuteUpdateAsync(x=>x.Id==parameter.GetId(),(nameof(ProductEntity.Price),new Money(parameter.Price)));
            await _repository.DataUnit.SaveChangesAsync();

        }


    }
}
