using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ARHome.Client.Products.Queries.GetProductAvicon;
using ARHome.Core.Products;
using ARHome.GenericSubDomain.MediatR;
using ARHome.Infrastructure.Abstractions.ImageStorage;

namespace ARHome.Application.Handlers.Products.Queries
{
    internal sealed class GetProductAviconQueryHandler : QueryHandler<GetProductAviconQuery, Stream>
    {
        private readonly IImageStorage _imageStorage;

        public GetProductAviconQueryHandler(IImageStorage imageStorage)
            => _imageStorage = imageStorage;

        public override async Task<Stream> Handle(GetProductAviconQuery query, CancellationToken cancellationToken)
        {
            return await _imageStorage.GetImageAsync(nameof(Product), query.ProductId, cancellationToken);
        }
    }
}