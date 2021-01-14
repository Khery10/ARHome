using ARHome.Application.Models;
using ARHome.Core.Entities;
using AutoMapper;
using System;

namespace ARHome.Application.Mapper
{
    public class ObjectMapper
    {
        private static readonly Lazy<IMapper> MapperLazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<ARHomeDtoMapper>();
            });

            return config.CreateMapper();
        });

        public static IMapper Mapper => MapperLazy.Value;
    }

    public class ARHomeDtoMapper : Profile
    {
        public ARHomeDtoMapper()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
        }
    }

}
