using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ARHome.Core.Products;
using ARHome.DataAccess.Specifications;
using ARHome.GenericSubDomain.Paging;
using ARHome.Infrastructure.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ARHome.Infrastructure.Repository
{
    internal sealed class ProductRepository : IProductRepository
    {
        private readonly ARHomeContext _context;
        private readonly ISpecificationEvaluator _specificationEvaluator;

        public ProductRepository(ARHomeContext context, ISpecificationEvaluator specificationEvaluator)
        {
            _context = context;
            _specificationEvaluator = specificationEvaluator;
        }

        public async Task<Product[]> GetAsync(
            IPagingSpecification<Product> specification,
            CancellationToken cancellationToken = default)
        {
            return await _specificationEvaluator
                .ApplySpecification(_context.Set<Product>(), specification)
                .ToArrayAsync(cancellationToken);
        }

        public async Task<Product> GetByIdAsync(ProductKey id, CancellationToken cancellationToken = default)
        {
            var product = await _context
                .Set<Product>()
                .SingleOrDefaultAsync(cat => cat.Id == id, cancellationToken);

            if (product is null)
                throw new KeyNotFoundException($"{nameof(Product)} with Id = {id} not found.");

            return product;
        }

        public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
        {
            await _context.Set<Product>().AddAsync(product, cancellationToken);
        }

        public Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            _context.Set<Product>().Update(product);
            return Task.CompletedTask;
        }
    }
}