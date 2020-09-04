using Messages.Core;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Http.Request.Service.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static Response<List<TResponseMessage>> GetResponses<TResponseMessage>(this HttpResponseMessage httpResponseMessage)
        {
            var response = httpResponseMessage.Content.ReadAsAsync<Response<List<TResponseMessage>>>().GetAwaiter().GetResult();

            if (response == null)
                response = Response<List<TResponseMessage>>.Create();

            if (!response.Data.HasValue)
                response.SetValue(new List<TResponseMessage>());

            return response;
        }

        public static Response<TResponseMessage> GetResponse<TResponseMessage>(this HttpResponseMessage httpResponseMessage)
        {
            var response = httpResponseMessage.Content.ReadAsAsync<Response<TResponseMessage>>().GetAwaiter().GetResult();

            if (response == null)
                response = Response<TResponseMessage>.Create();

            if (!response.Data.HasValue)
                response.SetValue(Activator.CreateInstance<TResponseMessage>());

            return response;
        }

        public static Response GetResponse(this HttpResponseMessage httpResponseMessage)
        {
            var response = httpResponseMessage.Content.ReadAsAsync<Response>().GetAwaiter().GetResult();

            if (response == null)
                response = Response.Create();

            return response;
        }
    }
}
