using System.Threading;
using System.Threading.Tasks;
using ARHome.Application.Handlers.Converters;
using ARHome.Client.Categories;
using ARHome.Client.Categories.Queries.GetCategoryById;
using ARHome.Core.Categories;
using ARHome.GenericSubDomain.MediatR;
using ARHome.Infrastructure.Abstractions.Repositories;

namespace ARHome.Application.Handlers.Categories.Queries
{
    internal sealed class GetCategoryByIdQueryHandler : QueryHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly ICategoryRepository _repository;
        private readonly CategoryConverter _converter;

        public GetCategoryByIdQueryHandler(ICategoryRepository repository, CategoryConverter converter)
        {
            _repository = repository;
            _converter = converter;
        }

        public override async Task<CategoryDto> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(new CategoryKey(query.CategoryId), cancellationToken);
            return _converter.ConvertToDto(category);
        }
    }
}