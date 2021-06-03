using System.Threading;
using System.Threading.Tasks;
using ARHome.Application.Handlers.Converters;
using ARHome.Client.Categories;
using ARHome.Client.Categories.Queries.GetCategoryById;
using ARHome.Core.Categories;
using ARHome.GenericSubDomain.MediatR;
using ARHome.Infrastructure.Abstractions.Repositories;

namespace ARHome.Application.Handlers.Categories.Queries.GetCategoryById
{
    internal sealed class GetCategoryByIdHandler : QueryHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryByIdHandler(ICategoryRepository repository)
            => _repository = repository;
        
        public override async Task<CategoryDto> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(new CategoryKey(query.CategoryId), cancellationToken);
            return CategoryConverter.ConvertToDto(category);
        }
    }
}