using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ARHome.GenericSubDomain.Middleware
{
    internal sealed class RequestHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestHandlerMiddleware> _logger;

        public RequestHandlerMiddleware(RequestDelegate next, ILogger<RequestHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation($"Request {context.Request?.Method} {context.Request?.Path}");
            await _next(context);
            _logger.LogInformation($"Response {context.Response?.StatusCode}");
        }
    }
}
