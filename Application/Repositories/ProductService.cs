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
    internal class ProductService(IRepository<ProductEntity> repository, IMapper mapper) : BaseService<ProductEntity, ProductModel, ProductDetailModel>(repository, mapper), IProductService
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
            try
            {
                if (parameter is UpdateProductParameter updateProductParameter)
                {
                    ProductEntity entity = _mapper.Map<ProductEntity>(parameter);
                    if (updateProductParameter.Materials is ICollection<CreateProductMaterialParameter> m)
                    {
                        await _repository.DataUnit.ProductMaterials.ExecuteDeleteAsync(x => x.ProductId == entity.Id);
                        var materials = updateProductParameter.Materials.Select(x => new ProductMaterialEntity(entity.Id, x.MaterialId, x.Amount)).ToList();
                        await _repository.DataUnit.ProductMaterials.CreateRangeAsync(materials);

                    }
                    if (updateProductParameter.Additives is ICollection<int> a)
                    {
                        await _repository.DataUnit.ProductAdditives.ExecuteDeleteAsync(x => x.ProductId == entity.Id);
                        var additives = updateProductParameter.Additives.Select(x => new ProductAdditiveEntity(entity.Id, x)).ToList();
                        await _repository.DataUnit.ProductAdditives.CreateRangeAsync(additives);
                    }


                    ProductEntity product = await _repository.GetByIdAsync(updateProductParameter.Id);
                    if (product.Price.Value != updateProductParameter.Price)
                        await UpdatePrice(new UpdateProductPriceParameter(product.Id, updateProductParameter.Price));

                    await _repository.DataUnit.SaveChangesAsync();

                    await _repository.UpdateAsync(entity);
                    await _repository.DataUnit.SaveChangesAsync();

                }
            }
            catch (Exception e)
            {

                throw e;
            }
            

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
            await _repository.ExecuteUpdateAsync(x => x.Id == parameter.GetId(), (nameof(ProductEntity.Price), new Money(parameter.Price)));

        }

        public async Task UpdateOrder(UpdateProductsOrderCollection parameters)
        {
            foreach (var item in parameters.Items)
            {
                await _repository.ExecuteUpdateAsync(x => x.Id == item.ProductId, (nameof(ProductEntity.Order), item.Order));
            }
            await _repository.DataUnit.SaveChangesAsync();
        }


    }
}
