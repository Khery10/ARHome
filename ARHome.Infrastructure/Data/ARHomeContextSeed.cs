using ARHome.Core.Configuration;
using ARHome.Core.Entities;
using ARHome.Core.Repositories;
using ARHome.Core.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARHome.Infrastructure.Data
{
    public class ARHomeContextSeed
    {
        private readonly ARHomeContext _ARHomeContext;
        private readonly IProductRepository _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly ARHomeSettings _settings;

        public ARHomeContextSeed(
            ARHomeContext ARHomeContext,
            IProductRepository productRepository,
            IRepository<Category> categoryRepository,
            ARHomeSettings settings)
        {
            _ARHomeContext = ARHomeContext;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _settings = settings;
        }

        public async Task SeedAsync()
        {
            // TODO: Only run this if using a real database
            // _ARHomeContext.Database.Migrate();
            // _ARHomeContext.Database.EnsureCreated();

            // categories - specifications
            await SeedCategoriesAsync();

        }

        private async Task SeedCategoriesAsync()
        {
            if (!_categoryRepository.Table.Any())
            {
                var categories = new List<Category>(_settings.DbContextSeed.Categories.Length);
                for (int i = 0; i < _settings.DbContextSeed.Categories.Length; i++)
                    categories.Add(Category.Create(i + 1, categories[i].Name));

                await _categoryRepository.AddRangeAsync(categories);
            }
        }

    }
}
