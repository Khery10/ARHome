namespace ARHome.DataAccess.Specifications
{
    public interface IPagingSpecification<TEntity> : ISpecification<TEntity>
    {
         int PageIndex { get; }
         
         int PageSize { get; }
    }
}