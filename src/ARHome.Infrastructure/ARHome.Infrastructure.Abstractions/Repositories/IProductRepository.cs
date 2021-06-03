using System.Threading;
using System.Threading.Tasks;
using ARHome.Core.Products;
using ARHome.DataAccess.Specifications;
using ARHome.GenericSubDomain.Paging;

namespace ARHome.Infrastructure.Abstractions.Repositories
{
    public interface IProductRepository
    {
        public Task<Product> GetByIdAsync(ProductKey id, CancellationToken cancellationToken = default);
        
        public Task<Product[]> GetAsync(IPagingSpecification<Product> specification, CancellationToken cancellationToken = default);

        public Task AddAsync(Product product, CancellationToken cancellationToken = default);

        public Task UpdateAsync(Product product, CancellationToken cancellationToken = default);
    }
}