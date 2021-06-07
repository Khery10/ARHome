using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ARHome.Application.Handlers.Converters;
using ARHome.Client.Categories;
using ARHome.Client.Categories.Queries.GetAllCategories;
using ARHome.GenericSubDomain.MediatR;
using ARHome.Infrastructure.Abstractions.Repositories;

namespace ARHome.Application.Handlers.Categories.Queries
{
    internal sealed class GetAllCategoriesQueryHandler  : QueryHandler<GetAllCategoriesQuery, CategoryDto[]>
    {
        private readonly ICategoryRepository _repository;
        private readonly CategoryConverter _converter;

        public GetAllCategoriesQueryHandler(ICategoryRepository repository, CategoryConverter converter)
        {
            _repository = repository;
            _converter = converter;
        }

        public override async Task<CategoryDto[]> Handle(GetAllCategoriesQuery query, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAllAsync(cancellationToken);
            return categories.Select(_converter.ConvertToDto).ToArray();
        }
    }
}