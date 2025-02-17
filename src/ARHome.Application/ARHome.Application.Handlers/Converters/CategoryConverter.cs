﻿using System.Collections.Generic;
using System.Linq;
using ARHome.Client.Categories;
using ARHome.Core.Categories;

namespace ARHome.Application.Handlers.Converters
{
    internal class CategoryConverter
    {
        public CategoryDto ConvertToDto(Category category)
        {
            return new()
            {
                Id = category.Id.Value,
                Name = category.Name,
                Description = category.Description,
            };
        }


        public CategoryDto[] ConvertToDto(IEnumerable<Category> categories)
            => categories.Select(ConvertToDto).ToArray();
    }
}