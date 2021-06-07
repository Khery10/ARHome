using System.Threading;
using System.Threading.Tasks;
using ARHome.Application.Handlers.Converters;
using ARHome.Client.Products;
using ARHome.Client.Products.Queries.GetProductById;
using ARHome.Core.Products;
using ARHome.GenericSubDomain.MediatR;
using ARHome.Infrastructure.Abstractions.Repositories;

namespace ARHome.Application.Handlers.Products.Queries
{
    internal sealed class GetProductByIdQueryHandler : QueryHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _repository;
        private readonly ProductConverter _converter;

        public GetProductByIdQueryHandler(
            IProductRepository repository,
            ProductConverter converter)
        {
            _repository = repository;
            _converter = converter;
        }

        public override async Task<ProductDto> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(new ProductKey(query.ProductId), cancellationToken);
            return _converter.ConvertToDto(product);
        }
    }
}