using System;
using System.Linq;
using ARHome.DataAccess.Specifications;
using Microsoft.EntityFrameworkCore;

namespace ARHome.DataAccess.EntityFramework
{
    internal sealed class SpecificationEvaluator : ISpecificationEvaluator
    {
        public IQueryable<TEntity> ApplySpecification<TEntity>(
            IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> specification)
            where TEntity : class
        {
            if (inputQuery is null)
                throw new ArgumentNullException(nameof(inputQuery));

            if (specification is null)
                throw new ArgumentNullException(nameof(specification));

            var query = inputQuery;

            // modify the IQueryable using the specification's criteria expression
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            // Includes all expression-based includes
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            // Include any string-based include statements
            query = specification.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));

            // Apply ordering if expressions are set
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            return query;
        }

        public IQueryable<TEntity> ApplyPagingSpecification<TEntity>(
            IQueryable<TEntity> inputQuery,
            IPagingSpecification<TEntity> specification)
            where TEntity : class
        {
            var query = ApplySpecification(inputQuery, specification)
                .Skip(specification.PageIndex * specification.PageSize)
                .Take(specification.PageSize);
            
            return query;
        }
    }
}