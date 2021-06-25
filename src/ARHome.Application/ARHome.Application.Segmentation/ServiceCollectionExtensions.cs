using System.Net;
using System.Net.Http.Headers;
using ARHome.Application.Segmentation.Handlers;
using ARHome.Application.Segmentation.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ARHome.Application.Segmentation
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSegmentation(this IServiceCollection services, IConfiguration configuration)
        {
            var segmentationOptions = configuration.GetSection(nameof(SegmentationOptions)).Get<SegmentationOptions>();
            
            services
                .AddSingleton(segmentationOptions)
                .AddHttpClient<RoomSegmentationHandler>(c =>
                {
                    c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                });

            return services;
        }
    }
}