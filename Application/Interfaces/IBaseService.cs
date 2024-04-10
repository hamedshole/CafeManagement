using Domain.Common;
using Domain.Interfaces;
using Shared.Model;

namespace Application.Interfaces
{

    public interface IBaseService<TEntity, TDto, TDetailedDto> where TDto : class where TEntity : EntityBase
    {
        Task CreateAsync<TParameter>(TParameter parameters);
        Task UpdateAsync<TParameter>(TParameter parameters);
        Task DeleteAsync(int id);
        Task<TDetailedDto> GetById(int id);
        Task<List<TDto>> GetAll(ISpecifications<TEntity> parameters);
        TDetailedDto GetBy(ISpecifications<TEntity> parameters);
        Task<PagedList<TDto>> GetPaged(ISpecifications<TEntity> parameters,PagingParameter pagingParameter);
    }

    public interface IBaseService<TEntity, TDto> : IBaseService<TEntity, TDto, TDto> where TDto : class where TEntity:EntityBase
    {

    }

}
