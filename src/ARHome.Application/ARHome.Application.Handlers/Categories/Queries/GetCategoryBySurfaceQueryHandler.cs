using System;
using System.Threading;
using System.Threading.Tasks;
using ARHome.Application.Handlers.Converters;
using ARHome.Client.Categories;
using ARHome.Client.Categories.Queries.GetCategoriesBySurface;
using ARHome.Core.Categories;
using ARHome.GenericSubDomain.MediatR;
using ARHome.Infrastructure.Abstractions.Repositories;

namespace ARHome.Application.Handlers.Categories.Queries
{
    internal sealed class GetCategoryBySurfaceQueryHandler : QueryHandler<GetCategoriesBySurfaceQuery, CategoryDto[]>
    {
        private readonly ICategoryRepository _repository;
        private readonly CategoryConverter _converter;
        
        public GetCategoryBySurfaceQueryHandler(ICategoryRepository repository, CategoryConverter converter)
        {
            _repository = repository;
            _converter = converter;
        }
        
        public override async Task<CategoryDto[]> Handle(GetCategoriesBySurfaceQuery query, CancellationToken cancellationToken)
        {
            var surfaceCode = Enum.Parse<SurfaceTypeCode>(query.Surface, true);
            var categories = await _repository.GetBySurfaceAsync(new SurfaceType(surfaceCode), cancellationToken);

            return _converter.ConvertToDto(categories);
        }
    }
}