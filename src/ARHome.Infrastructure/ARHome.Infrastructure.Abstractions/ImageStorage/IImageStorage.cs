using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ARHome.Infrastructure.Abstractions.ImageStorage
{
    public interface IImageStorage
    {
        public Task<Stream> GetImageAsync(
            string space,
            Guid objectId, 
            CancellationToken cancellationToken);

        public Task UploadImageAsync(
            Stream stream,
            string extension,
            string space,
            Guid objectId,
            CancellationToken cancellationToken);

        public Task UploadImageAsync(
            string imageUrl,
            string space,
            Guid objectId,
            CancellationToken cancellationToken);
    }
}