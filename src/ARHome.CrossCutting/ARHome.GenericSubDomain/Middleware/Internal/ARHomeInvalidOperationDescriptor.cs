using System;
using System.Net;
using ARHome.GenericSubDomain.Exceptions;
using Microsoft.Extensions.Logging;

namespace ARHome.GenericSubDomain.Middleware.Internal
{
    internal sealed class ARHomeInvalidOperationDescriptor : IExceptionDescriptor
    {
        private readonly ILogger<ARHomeInvalidOperationDescriptor> _logger;

        public ARHomeInvalidOperationDescriptor(ILogger<ARHomeInvalidOperationDescriptor> logger)
        {
            _logger = logger;
        }

        public bool CanHandle(Exception ex)
        {
            return ex is ARHomeInvalidOperationException;
        }

        public HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

        public ErrorResult Handle(Exception ex)
        {
            _logger.LogError(ex, "BusinessLogicException");

            string message = string.IsNullOrWhiteSpace(ex.Message) ? "Error. Invalid operation." : ex.Message;

            var errors = new[]
            {
                new ErrorProperty(nameof(ARHomeInvalidOperationException), message)
            };

            return new ErrorResult(errors);
        }
    }
}