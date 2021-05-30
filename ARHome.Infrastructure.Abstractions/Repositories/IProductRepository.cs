using System.Threading;
using System.Threading.Tasks;
using ARHome.Core.Products;

namespace ARHome.Infrastructure.Abstractions.Repositories
{
    public interface IProductRepository
    {
        public Task<Product[]> GetAllAsync(CancellationToken cancellationToken = default);

        public Task<Product> GetByIdAsync(ProductKey id, CancellationToken cancellationToken = default);

        public Task AddAsync(Product category, CancellationToken cancellationToken = default);

        public Task UpdateAsync(Product category, CancellationToken cancellationToken = default);
    }
}