using ARHome.Client.Categories;
using ARHome.Core.Categories;
using AutoMapper;

namespace ARHome.Application.Handlers.Converters
{
    internal sealed class AutomapperProfiler : Profile
    {
        public AutomapperProfiler()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(category => category.Id.Value));
        }
    }
}