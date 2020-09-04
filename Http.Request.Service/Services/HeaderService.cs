using Messages.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net.Http;

namespace Http.Request.Service.Services
{
    public static class HeaderService
    {
        static string[] HeadersDefaults { get; } = new[] { "Postman-Token", "Cache-Control", "Date", "Expires", "Pragma", "Content-Length", "Content-Type", "Server", "X-AspNet-Version", "X-Powered-By", "X-SourceFiles" };

        internal static TResponse AddHeadersToResponse<TResponse>(TResponse response, HttpResponseMessage responseMessage) where TResponse : Response
        {
            if (responseMessage.Headers == null) return response;

            if (response == null)
                response = Activator.CreateInstance<TResponse>();

            responseMessage.Headers.ToList().ForEach(keyValue =>
            {
                if (HeadersDefaults.Contains(keyValue.Key) || response.Headers.Contains(keyValue.Key))
                    return;

                if (keyValue.Value.Any())
                {
                    if (keyValue.Value.Count() == 1)
                        response.Headers.Add(keyValue.Key, keyValue.Value.Single());
                    else
                        response.Headers.Add(keyValue.Key, string.Join(",", keyValue.Value.ToArray()));
                }
            });

            return response;
        }

        internal static HttpClient AddHeadersToRequest(HttpRequest request, HttpClient httpClient, bool addChunked = true, bool addHost = false)
        {
            if (request == null) return httpClient;
            if (request.Headers == null) return httpClient;

            request.Headers.ToList().ForEach(keyValue =>
            {
                if (HeadersDefaults.Contains(keyValue.Key) || httpClient.DefaultRequestHeaders.Contains(keyValue.Key))
                    return;

                if ((keyValue.Key.Equals("Transfer-Encoding") && keyValue.Value.Contains("chunked")) && !addChunked)
                    return;

                if (keyValue.Key.ToLower().Equals("host") && !addHost)
                    return;

                if (keyValue.Value.Any())
                {
                    if (keyValue.Value.Count() == 1)
                        httpClient.DefaultRequestHeaders.Add(keyValue.Key, keyValue.Value.Single());
                    else
                        httpClient.DefaultRequestHeaders.Add(keyValue.Key, string.Join(",", keyValue.Value.ToArray()));
                }
            });

            return httpClient;
        }
    }
}
