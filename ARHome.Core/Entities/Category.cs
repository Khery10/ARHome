﻿using ARHome.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ARHome.Core.Entities
{
    public class Category : Entity
    {
        [Required, StringLength(80)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public static Category Create(int categoryId, string name, string description = null)
        {
            var category = new Category
            {
                Id = categoryId,
                Name = name,
                Description = description
            };
            return category;
        }
    }
}
