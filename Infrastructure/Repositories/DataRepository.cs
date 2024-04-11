using Domain.Common;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Contexts;
using Infrastructure.Data.Util;
using Infrastructure.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    internal class DataRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private protected readonly CafeContext _context;
        private protected readonly DbSet<TEntity> _dbSet;
        private readonly ICafeDataUnit _dataUnit;

        public DataRepository(CafeContext context, ICafeDataUnit dataUnit)
        {
            _context = context ?? throw new NotImplementedException(nameof(context));
            _dbSet = _context.Set<TEntity>();
            _dataUnit = dataUnit;
        }

        ICafeDataUnit IRepository<TEntity>.DataUnit => _dataUnit;


        async Task<TEntity> IRepository<TEntity>.CreateAsync(TEntity entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                return entity;
            }
            catch (DbUpdateException dbe) when (dbe.InnerException?.HResult == -2146232060)
            {
                throw new WrongNeccasaryFieldException();
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task IRepository<TEntity>.CreateRangeAsync(ICollection<TEntity> entities)
        {

            await _dbSet.AddRangeAsync(entities);
        }

        async Task IRepository<TEntity>.SoftDeleteAsync(int id)
        {
            TEntity? entity = await _dbSet.FindAsync(id) ?? throw new NotFoundException(nameof(TEntity), id);
            entity.Delete();
            _dbSet.Update(entity);
        }

        IQueryable<TEntity> IRepository<TEntity>.Get(ISpecifications<TEntity> specifications)
        {
            try
            {
                var result = SpecificationEvaluator<TEntity>.GetQuery(_dbSet, specifications);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        IQueryable<TEntity> IRepository<TEntity>.Get(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression);
        }




        async Task<TEntity> IRepository<TEntity>.GetByIdAsync(int id)
        {
            try
            {
                TEntity? entity = await _dbSet.FindAsync(id);
                return await _dbSet.FindAsync(id) ?? throw new NotFoundException(nameof(TEntity), id);
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }

        }


        async Task IRepository<TEntity>.UpdateAsync(TEntity entity)
        {
            try
            {
                TEntity? updateEntity = await _dbSet.FindAsync(entity.Id) ?? throw new NotFoundException(nameof(TEntity), entity.Id);
                _dbSet.Entry(updateEntity).State = EntityState.Detached;
                updateEntity = entity;
                _dbSet.Entry(updateEntity).State = EntityState.Modified;


            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (DbUpdateException dbe) when (dbe.InnerException?.HResult == -2146232060)
            {
                throw new WrongNeccasaryFieldException();
            }
            catch (Exception)
            {
                throw;
            }
        }


        async Task IRepository<TEntity>.DeleteAsync(int id)
        {
            TEntity? entity = await _dbSet.FindAsync(id) ?? throw new NotFoundException(nameof(TEntity), id);
            _dbSet.Remove(entity);
        }

        Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> CombineSetters(
     IEnumerable<Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>>> setters
 )
        {
            Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> expr = sett => sett;

            foreach (var expr2 in setters)
            {
                var call = (MethodCallExpression)expr2.Body;
                expr = Expression.Lambda<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>>(
                    Expression.Call(expr.Body, call.Method, call.Arguments),
                    expr2.Parameters
                );
            }

            return expr;
        }

        async Task IRepository<TEntity>.ExecuteDeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            await _dbSet.Where(expression).ExecuteDeleteAsync();
        }

        async Task IRepository<TEntity>.ExecuteUpdateAsync(Expression<Func<TEntity, bool>> expression, params (string, object?)[] parameter)
        {

            await _dbSet.Where(expression).ExecuteUpdateAsync((IReadOnlyDictionary<string, object?>)parameter.ToDictionary(x => x.Item1, x => x.Item2));
        }
    }
}
