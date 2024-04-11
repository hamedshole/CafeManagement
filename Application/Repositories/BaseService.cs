using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Common;
using Domain.Interfaces;
using Shared.Model;

namespace Application.Services
{
    internal class BaseService<TEntity, TDto, TDetailedDto>(IRepository<TEntity> repository, IMapper mapper) : IBaseService<TEntity, TDto, TDetailedDto> where TDto : class where TEntity : EntityBase where TDetailedDto : class
    {
        protected readonly IRepository<TEntity> _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        protected readonly IMapper _mapper=mapper ?? throw new ArgumentNullException(nameof(mapper));
        public virtual async Task CreateAsync<TParameter>(TParameter parameter)
        {
            try
            {

            TEntity entity = _mapper.Map<TParameter, TEntity>(parameter);
            await _repository.CreateAsync(entity);
            await _repository.DataUnit.SaveChangesAsync();
            }
            catch (Exception )
            {

                throw;
            }
        }

        public virtual async Task DeleteAsync(int id)
        {
            await _repository.SoftDeleteAsync(id);
            await _repository.DataUnit.SaveChangesAsync();
        }

        public virtual async Task<List<TDto>> GetAll(ISpecifications<TEntity> specifications)
        {
            List<TDto> dtos = _repository.Get(specifications).ProjectTo<TDto>(_mapper.ConfigurationProvider).ToList();
            return await Task.FromResult(dtos);
        }

        public virtual TDetailedDto GetBy(ISpecifications<TEntity> specifications)
        {
            TEntity? entity = _repository.Get(specifications).FirstOrDefault();
            return _mapper.Map<TEntity, TDetailedDto>(entity);
        }

        public async Task<TDetailedDto> GetById(int id)
        {
            var entity= await _repository.GetByIdAsync(id);
            return _mapper.Map<TDetailedDto>(entity);
        }

        public virtual async Task<PagedList<TDto>> GetPaged(ISpecifications<TEntity> specifications, PagingParameter pagingParameter)
        {

            var queryable = _repository.Get(specifications);
            int count = queryable.Count();
            var collection = queryable.Take(pagingParameter.PageSize).Skip((pagingParameter.Page-1)*pagingParameter.PageSize).ProjectTo<TDto>(_mapper.ConfigurationProvider).ToList();
            PagedList<TDto> result = new(collection, count);
            return await Task.FromResult(result);
        }

        public virtual async Task UpdateAsync<TParameter>(TParameter parameter)
        {
            try
            {

            TEntity entity = _mapper.Map<TParameter, TEntity>(parameter);
            await _repository.UpdateAsync(entity);
            await _repository.DataUnit.SaveChangesAsync();
            }
            catch (Exception )
            {

                throw;
            }
        }
    }
    internal class BaseService<TEntity, TDto>(IRepository<TEntity> repository,IMapper mapper) : BaseService<TEntity, TDto, TDto>(repository,mapper), IBaseService<TEntity, TDto> where TDto : class where TEntity : EntityBase
    {
    }
}
