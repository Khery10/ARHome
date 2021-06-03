using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ARHome.Application.Handlers.Converters;
using ARHome.Client.Categories;
using ARHome.Client.Categories.Queries.GetAllCategories;
using ARHome.GenericSubDomain.MediatR;
using ARHome.Infrastructure.Abstractions.Repositories;

namespace ARHome.Application.Handlers.Categories.Queries.GetAllCategories
{
    internal sealed class GetAllCategoriesHandler  : QueryHandler<GetAllCategoriesQuery, CategoryDto[]>
    {
        private readonly ICategoryRepository _repository;

        public GetAllCategoriesHandler(ICategoryRepository repository)
            => _repository = repository;
        
        public override async Task<CategoryDto[]> Handle(GetAllCategoriesQuery query, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAllAsync(cancellationToken);
            return categories.Select(CategoryConverter.ConvertToDto).ToArray();
        }
    }
}