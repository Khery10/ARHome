using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ARHome.Application.Segmentation.Options;
using ARHome.Client.Segmentation;
using ARHome.GenericSubDomain.Common;
using ARHome.GenericSubDomain.HttpClient;
using ARHome.GenericSubDomain.MediatR;
using Microsoft.AspNetCore.Http;

namespace ARHome.Application.Segmentation.Handlers
{
    internal sealed class RoomSegmentationHandler : CommandHandler<SegmentationRequest, SegmentationResult>
    {
        private readonly SegmentationOptions _options;
        private readonly IJsonSerializer _serializer;
        private readonly HttpClient _httpClient;

        public RoomSegmentationHandler(HttpClient client, SegmentationOptions options, IJsonSerializer serializer)
        {
            _options = options;
            _serializer = serializer;
            _httpClient = client;
        }

        public override async Task<SegmentationResult> Handle(SegmentationRequest command,
            CancellationToken cancellationToken)
        {
            var request = HttpRequestBuilder
                .Build(HttpMethod.Post, _options.SegmentationUrl)
                .WithContent(command, _serializer)
                .Create();

            var response = await _httpClient.SendAsync(request, cancellationToken);

            var result = await HttpResponseProcessor
                .Create(_serializer)
                .ProcessAsync<SegmentationResult>(response, string.Empty);

            return result;
        }
    }
}