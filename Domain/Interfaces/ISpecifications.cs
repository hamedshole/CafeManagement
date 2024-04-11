﻿using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface ISpecifications<T>
    {
        // Filter Conditions
        List<Expression<Func<T, bool>>> FilterCondition { get; }

        // Order By Ascending
        Expression<Func<T, object>> OrderBy { get; }

        // Order By Descending
        Expression<Func<T, object>> OrderByDescending { get; }

        // Include collection to load related data
        List<string> Includes { get; }

        // GroupBy expression
        Expression<Func<T, object>> GroupBy { get; }
      
        
    }
}
