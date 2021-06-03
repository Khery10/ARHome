using System.Linq;

namespace ARHome.DataAccess.Specifications
{
    public interface ISpecificationEvaluator
    {
        IQueryable<TEntity> ApplySpecification<TEntity>(
            IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> specification) where TEntity : class;
        
        IQueryable<TEntity> ApplyPagingSpecification<TEntity>(
            IQueryable<TEntity> inputQuery,
            IPagingSpecification<TEntity> specification) where TEntity : class;
    }
}