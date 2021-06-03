using System;
using System.Linq.Expressions;

namespace ARHome.DataAccess.Specifications
{
    public abstract class BasePagingSpecification<TEntity> : BaseSpecification<TEntity>, IPagingSpecification<TEntity>
    {
        protected BasePagingSpecification(int pageIndex, int pageSize) : this(null, pageIndex, pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        
        protected BasePagingSpecification(Expression<Func<TEntity, bool>> criteria, int pageIndex, int pageSize) : base(criteria)
        {
            
        }

        public int PageIndex { get; }
        public int PageSize { get; }
    }
}