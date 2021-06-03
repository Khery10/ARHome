﻿using System;

namespace ARHome.Client.Categories
{
    public sealed class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}