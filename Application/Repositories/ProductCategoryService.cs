using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Shared.Model;

namespace Application.Services
{
    internal class ProductCategoryService(IRepository<ProductCategoryEntity> repository, IMapper mapper) : BaseService<ProductCategoryEntity, ProductCategoryModel>(repository, mapper), IProductCategoryService
	{
		public async Task UpdateOrder( UpdateCategoryOrderParameterCollection parameters)
		{
			foreach ( var item in parameters.Items )
			{
			await _repository.ExecuteUpdateAsync(x => x.Id == item.CategoryId, (nameof(ProductCategoryEntity.Order), item.Order));
			}
			await _repository.DataUnit.SaveChangesAsync();
		}
	}
}
