using System.Threading;
using System.Threading.Tasks;
using ARHome.Core.Categories;
using ARHome.Core.Products;
using ARHome.DataAccess.Specifications;

namespace ARHome.Infrastructure.Abstractions.Repositories
{
    public interface ICategoryRepository
    {
        public Task<Category[]> GetAllAsync(CancellationToken cancellationToken = default);

        public Task<Category> GetByIdAsync(CategoryKey id, CancellationToken cancellationToken = default);

        public Task AddAsync(Category category, CancellationToken cancellationToken = default);

        public Task UpdateAsync(Category category, CancellationToken cancellationToken = default);

        public Task<Category[]> GetBySurfaceAsync(
            SurfaceType surfaceType,
            CancellationToken cancellationToken = default);
    }
}