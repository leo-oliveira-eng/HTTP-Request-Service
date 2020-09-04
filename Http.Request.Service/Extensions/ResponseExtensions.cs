using Messages.Core;
using System.Net;
using System.Net.Http;

namespace Http.Request.Service.Extensions
{
    public static class ResponseExtensions
    {
        public static TResponse SetContent<TResponse>(this TResponse response, HttpContent content) where TResponse : Response
        {
            if (response == null) return response;

            response.Content = content;

            return response;
        }

        public static TResponse SetStatusCode<TResponse>(this TResponse response, HttpStatusCode statusCode) where TResponse : Response
        {
            if (response == null) return response;

            response.StatusCode = statusCode;

            return response;
        }
    }
}
