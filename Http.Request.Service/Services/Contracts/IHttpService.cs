using Http.Request.Service.Messages;
using Messages.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Http.Request.Service.Services.Contracts
{
    public interface IHttpService
    {
        Task<Response<TResponseMessage>> GetAsync<TResponseMessage>(string requestEndpoint, string HttpClientConfigurationName)
            where TResponseMessage : ResponseMessage;

        Task<Response<List<TResponseMessage>>> GetManyAsync<TResponseMessage>(string requestEndpoint, string HttpClientConfigurationName)
            where TResponseMessage : ResponseMessage;

        Task<Response<List<TResponseMessage>>> GetManyAsync<TRequestMessage, TResponseMessage>(string requestEndpoint, TRequestMessage requestMessage, string httpClientConfigurationName)
            where TRequestMessage : RequestMessage
            where TResponseMessage : ResponseMessage;

        Task<Response<TResponseMessage>> PostAsync<TRequestMessage, TResponseMessage>(string requestEndpoint, TRequestMessage requestMessage, string HttpClientConfigurationName)
            where TRequestMessage : RequestMessage
            where TResponseMessage : ResponseMessage;

        Task<Response<TResponseMessage>> PutAsync<TRequestMessage, TResponseMessage>(string requestEndpoint, Guid code, TRequestMessage requestMessage, string HttpClientConfigurationName)
            where TRequestMessage : RequestMessage
            where TResponseMessage : ResponseMessage;

        Task<Response> PutAsync<TRequestMessage>(string requestEndpoint, Guid code, TRequestMessage requestMessage, string httpClientConfigurationName)
            where TRequestMessage : RequestMessage;

        Task<Response<TResponseMessage>> PutAsync<TRequestMessage, TResponseMessage>(string requestEndpoint, TRequestMessage requestMessage, string HttpClientConfigurationName)
            where TRequestMessage : RequestMessage
            where TResponseMessage : ResponseMessage;

        Task<Response> PutAsync<TRequestMessage>(string requestEndpoint, TRequestMessage requestMessage, string httpClientConfigurationName)
            where TRequestMessage : RequestMessage;

        Task<Response> DeleteAsync(string requestEndpoint, Guid code, string HttpClientConfigurationName);
    }
}
