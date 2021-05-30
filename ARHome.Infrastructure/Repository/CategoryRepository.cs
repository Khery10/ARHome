using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using ARHome.Core.Categories;
using ARHome.Infrastructure.Abstractions.Repositories;
using ARHome.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ARHome.Infrastructure.Repository
{
    internal sealed class CategoryRepository : ICategoryRepository
    {
        private readonly ARHomeContext _context;

        public CategoryRepository(ARHomeContext context)
            => _context = context;

        public async Task<Category[]> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<Category>().ToArrayAsync(cancellationToken);
        }

        public async Task<Category> GetByIdAsync(CategoryKey id, CancellationToken cancellationToken = default)
        {
            var category = await _context
                .Set<Category>()
                .SingleOrDefaultAsync(cat => cat.Id == id, cancellationToken);

            if (category is null)
                throw new KeyNotFoundException($"{nameof(Category)} with Id = {id} not found.");

            return category;
        }

        public async Task AddAsync(Category category, CancellationToken cancellationToken = default)
        {
            await _context.Set<Category>().AddAsync(category, cancellationToken);
        }

        public Task UpdateAsync(Category category, CancellationToken cancellationToken = default)
        {
            _context.Set<Category>().Update(category);
            return Task.CompletedTask;
        }
    }
}