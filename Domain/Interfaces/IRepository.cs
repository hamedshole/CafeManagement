using Domain.Common;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        ICafeDataUnit DataUnit { get; }
        Task CreateRangeAsync(ICollection<TEntity> entities);
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task ExecuteUpdateAsync(Expression<Func<TEntity,bool>> expression,params (string,object?)[] parameter);
        Task SoftDeleteAsync(int id);
        Task DeleteAsync(int id);

        Task<TEntity> GetByIdAsync(int id);
        IQueryable<TEntity> Get(ISpecifications<TEntity> specifications);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);
    }
}
