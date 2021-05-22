using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ARHome.GenericSubDomain.Common;
using ARHome.GenericSubDomain.Exceptions;
using ARHome.GenericSubDomain.MediatR;
using ARHome.GenericSubDomain.Middleware;

namespace ARHome.GenericSubDomain.HttpClient
{
    public sealed class HttpResponseProcessor
    {
        private readonly static Dictionary<HttpStatusCode, string> KnownErrors = new()
        {
            {HttpStatusCode.BadRequest, "The request is formed incorrectly."},
            {HttpStatusCode.Unauthorized, "Unable to get the current user."},
            {HttpStatusCode.Forbidden, "Access denied for current user."},
            {HttpStatusCode.NotFound, "Object was not found."},
        };

        private readonly IJsonSerializer _jsonSerializer;

        private HttpResponseProcessor(IJsonSerializer jsonSerializer) 
            => _jsonSerializer = jsonSerializer;

        public async Task<TResponse> ProcessAsync<TResponse>(
            HttpResponseMessage responseMessage,
            string defaultErrorMessage)
        {
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var result = _jsonSerializer.Deserialize<Response<TResponse>>(content);
                return result.Data;
            }

            try
            {
                var errorData = await responseMessage.Content.ReadAsStringAsync();
                var errorResult = _jsonSerializer.Deserialize<ErrorResult>(errorData);

                if (errorResult.Errors?.Any() == true)
                {
                    var errorMessages = string.Join("; ", errorResult.Errors.Select(e => e.Message));

                    throw new ARHomeInvalidOperationException(errorMessages);
                }
            }
            catch (Exception ex)
                when (!(ex is ARHomeInvalidOperationException))
            {
                var error = await responseMessage.Content
                    .ReadAsStringAsync()
                    .ConfigureAwait(false);

                throw new ARHomeInvalidOperationException(error);
            }

            var errorMessage = KnownErrors.TryGetValue(responseMessage.StatusCode, out var message)
                ? message
                : defaultErrorMessage;

            throw new ARHomeInvalidOperationException(errorMessage);
        }

        public async Task<TResponse> ProcessOriginAsync<TResponse>(
            HttpResponseMessage responseMessage,
            string defaultErrorMessage)
        {
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var result = _jsonSerializer.Deserialize<TResponse>(content);
                return result;
            }

            try
            {
                var errorData = await responseMessage.Content.ReadAsStringAsync();
                var errorResult = _jsonSerializer.Deserialize<ErrorResult>(errorData);

                if (errorResult.Errors?.Any() == true)
                {
                    var errorMessages = string.Join("; ", errorResult.Errors.Select(e => e.Message));

                    throw new ARHomeInvalidOperationException(errorMessages);
                }
            }
            catch
            {
                var error = await responseMessage.Content
                    .ReadAsStringAsync()
                    .ConfigureAwait(false);

                throw new ARHomeInvalidOperationException(error);
            }

            var errorMessage = KnownErrors.TryGetValue(responseMessage.StatusCode, out var message)
                ? message
                : defaultErrorMessage;

            throw new ARHomeInvalidOperationException(errorMessage);
        }

        public static HttpResponseProcessor Create(IJsonSerializer jsonSerializer)
        {
            if (jsonSerializer is null)
                throw new ArgumentNullException(nameof(jsonSerializer));

            return new HttpResponseProcessor(jsonSerializer);
        }
    }
}