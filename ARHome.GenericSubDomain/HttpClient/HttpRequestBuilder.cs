using System;
using System.Net.Http;
using ARHome.GenericSubDomain.Common;

namespace ARHome.GenericSubDomain.HttpClient
{
    public class HttpRequestBuilder
    {
        private readonly HttpRequestMessage _httpRequest;

        private HttpRequestBuilder(HttpRequestMessage httpRequest) 
            => _httpRequest = httpRequest;

        public HttpRequestBuilder WithHeader(string headerName, string headerValue)
        {
            if (_httpRequest.Headers.Contains(headerName)) _httpRequest.Headers.Remove(headerName);

            _httpRequest.Headers.Add(headerName, headerValue);

            return this;
        }

        public HttpRequestBuilder WithContent<T>(T content, IJsonSerializer serializer)
        {
            if (_httpRequest.Method == HttpMethod.Get)
                throw new InvalidOperationException(
                    $"Sending content using HTTP {_httpRequest.Method} method is not supported.");

            _httpRequest.Content = content.ToHttpContent(serializer);
            return this;
        }

        public static HttpRequestBuilder Build(HttpMethod method, string url)
        {
            var httpRequest = new HttpRequestMessage(method, new Uri(url, UriKind.RelativeOrAbsolute));
            return new HttpRequestBuilder(httpRequest);
        }

        public HttpRequestMessage Create() => _httpRequest;
    }
}