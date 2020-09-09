using Http.Request.Service.Extensions;
using Http.Request.Service.Messages;
using Messages.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Http.Request.Service.Services
{
    public abstract class BaseHttpService
    {
        #region Properties

        protected internal IHttpClientFactory HttpClientFactory { get; }

        protected internal IHttpContextAccessor HttpContextAccessor { get; }

        #endregion

        #region Constructors

        public BaseHttpService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            HttpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            HttpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        #endregion

        #region Methods

        protected internal HttpClient GetHttpCliente(string httpClientConfigurationName)
        {
            var httpClient = HttpClientFactory.CreateClient(httpClientConfigurationName);

            if (httpClient == null)
                throw new ArgumentNullException($"The configuration with name '{httpClientConfigurationName}' could not be found on the package host.");

            return httpClient;
        }

        protected Response<TResponseMessage> GetResponse<TResponseMessage>(HttpResponseMessage responseMessage)
            where TResponseMessage : ResponseMessage
        {
            try
            {
                var response = responseMessage.GetResponse<TResponseMessage>();

                if (response == null) return Response<TResponseMessage>.Create();

                return response;
            }
            catch
            {
                return Response<TResponseMessage>.Create();
            }
        }

        protected Response<List<TResponseMessage>> GetResponses<TResponseMessage>(HttpResponseMessage responseMessage)
            where TResponseMessage : ResponseMessage
        {
            try
            {
                var response = responseMessage.GetResponse<List<TResponseMessage>>();

                if (response == null)
                    return Response<List<TResponseMessage>>.Create();

                return response;
            }
            catch
            {
                return Response<List<TResponseMessage>>.Create();
            }
        }

        #endregion
    }
}
