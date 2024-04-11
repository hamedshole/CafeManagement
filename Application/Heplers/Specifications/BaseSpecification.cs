using Domain.Common;
using Domain.Interfaces;
using System.Linq.Expressions;

namespace Application.Helpers.Specifications
{
     public class BaseSpecification<TEntity>:ISpecifications<TEntity> where TEntity : EntityBase
    {
        private readonly List<string>? _includeCollection;




        public BaseSpecification()
        {
            this.FilterCondition = [];
            _includeCollection = [];
        }
        public List<Expression<Func<TEntity, bool>>> FilterCondition { get; private set; }
        public Expression<Func<TEntity, object>>? OrderBy { get; private set; }
        public Expression<Func<TEntity, object>>? OrderByDescending { get; private set; }
        public List<string> Includes
        {
            get
            {
                return _includeCollection ?? throw new Exception();
            }
        }

        public Expression<Func<TEntity, object>>? GroupBy { get; private set; }

        private protected void AddInclude(string includeExpression)
        {
            Includes.Add(includeExpression);
        }

       private protected void ApplyOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        private protected void ApplyOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        private protected void SetFilterCondition(Expression<Func<TEntity, bool>> filterExpression)
        {
            FilterCondition.Add(filterExpression);
        }

        private protected void ApplyGroupBy(Expression<Func<TEntity, object>> groupByExpression)
        {
            GroupBy = groupByExpression;
        }
    }
}
