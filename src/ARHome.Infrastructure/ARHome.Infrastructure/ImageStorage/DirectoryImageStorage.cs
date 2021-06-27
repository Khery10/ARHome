using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ARHome.GenericSubDomain.Extensions;
using ARHome.Infrastructure.Abstractions.ImageStorage;

namespace ARHome.Infrastructure.ImageStorage
{
    internal sealed class DirectoryImageStorage : IImageStorage
    {
        private readonly HttpClient _httpClient;

        public DirectoryImageStorage(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Stream> GetImageAsync(string space, Guid objectId, CancellationToken cancellationToken)
        {
            var fileInfo = GetDirectory(space).GetFileInfo($"{objectId}*");
            return fileInfo.OpenRead();
        }

        public async Task UploadImageAsync(
            Stream stream,
            string extension,
            string space,
            Guid objectId,
            CancellationToken cancellationToken)
        {
            Directory.CreateDirectory(space);
            var path = GetImagePath(space, objectId, extension);

            await using var fs = File.Create(path);

            stream.Seek(0, SeekOrigin.Begin);
            await stream.CopyToAsync(fs, cancellationToken);
        }

        public async Task UploadImageAsync(
            string imageUrl, 
            string space, 
            Guid objectId,
            CancellationToken cancellationToken)
        {
            var extension = Path.GetExtension(imageUrl);
            
            var response = await _httpClient.GetAsync(imageUrl, cancellationToken);
            response.EnsureSuccessStatusCode();

            await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
            await UploadImageAsync(stream, extension, space, objectId, cancellationToken);
        }

        private DirectoryInfo GetDirectory(string path)
        {
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException($" Could not find {path}");

            return new DirectoryInfo(path);
        }

        private string GetImagePath(string space, Guid objectId, string extension)
        {
            extension = $".{extension.Trim('.')}";
            return $"{space}/{objectId}{extension}";
        }
    }
}