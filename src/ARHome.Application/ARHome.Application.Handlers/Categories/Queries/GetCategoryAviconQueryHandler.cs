using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ARHome.Client.Categories.Queries.GetCategoryAviconQuery;
using ARHome.Core.Categories;
using ARHome.GenericSubDomain.MediatR;
using ARHome.Infrastructure.Abstractions.ImageStorage;

namespace ARHome.Application.Handlers.Categories.Queries
{
    internal sealed class GetCategoryAviconQueryHandler : QueryHandler<GetCategoryAviconQuery, Stream>
    {
        private readonly IImageStorage _imageStorage;
        
        public GetCategoryAviconQueryHandler(IImageStorage imageStorage)
        {
            _imageStorage = imageStorage;
        }
        
        public override async Task<Stream> Handle(GetCategoryAviconQuery query, CancellationToken cancellationToken)
        {
            return await _imageStorage.GetImageAsync(nameof(Category), query.CategoryId, cancellationToken);
        }
    }
}