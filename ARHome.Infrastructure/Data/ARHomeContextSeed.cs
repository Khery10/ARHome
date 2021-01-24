using ARHome.Core.Configuration;
using ARHome.Core.Entities;
using ARHome.Core.Repositories;
using ARHome.Core.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
            IOptions<ARHomeSettings> settings)
        {
            _ARHomeContext = ARHomeContext;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _settings = settings?.Value;
        }

        public async Task SeedAsync()
        {
          //  _ARHomeContext.Database.Migrate();

            // categories - specifications
            await SeedCategoriesAsync();
        }

        private async Task SeedCategoriesAsync()
        {
            if (!_categoryRepository.Table.Any())
            {
                var categories = Enumerable
                    .Range(1, _settings.DbContextSeed.Categories.Length)
                    .Select(i => Category.Create(i, _settings.DbContextSeed.Categories[i - 1].Name));

                await _categoryRepository.AddRangeAsync(categories);
            }
        }

    }
}
