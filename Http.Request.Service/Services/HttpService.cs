using Http.Request.Service.Extensions;
using Http.Request.Service.Messages;
using Http.Request.Service.Services.Contracts;
using Messages.Core;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Http.Request.Service.Services
{
    public class HttpService : BaseHttpService, IHttpService
    {
        public HttpService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor) { }

        public async Task<Response<TResponseMessage>> GetAsync<TResponseMessage>(string requestEndpoint, string httpClientConfigurationName)
            where TResponseMessage : ResponseMessage
        {
            var httpClient = HeaderService.AddHeadersToRequest(HttpContextAccessor.HttpContext.Request, GetHttpCliente(httpClientConfigurationName), false);

            var responseMessage = await httpClient.GetAsync(requestEndpoint);

            var response = GetResponse<TResponseMessage>(responseMessage);

            response.SetContent(responseMessage.Content).SetStatusCode(responseMessage.StatusCode);

            HttpContextAccessor.HttpContext.Response.StatusCode = (int)responseMessage.StatusCode;

            return HeaderService.AddHeadersToResponse(response, responseMessage);
        }

        public async Task<Response<List<TResponseMessage>>> GetManyAsync<TResponseMessage>(string requestEndpoint, string httpClientConfigurationName)
            where TResponseMessage : ResponseMessage
        {
            var httpclient = HeaderService.AddHeadersToRequest(HttpContextAccessor.HttpContext.Request, GetHttpCliente(httpClientConfigurationName), false);

            var responseMessage = await httpclient.GetAsync(requestEndpoint);

            var response = GetResponses<TResponseMessage>(responseMessage);

            response.SetContent(responseMessage.Content).SetStatusCode(responseMessage.StatusCode);

            HttpContextAccessor.HttpContext.Response.StatusCode = (int)responseMessage.StatusCode;

            return HeaderService.AddHeadersToResponse(response, responseMessage);
        }

        public async Task<Response<List<TResponseMessage>>> GetManyAsync<TRequestMessage, TResponseMessage>(string requestEndpoint, TRequestMessage requestMessage, string httpClientConfigurationName)
            where TRequestMessage : RequestMessage
            where TResponseMessage : ResponseMessage
        {
            var httpclient = HeaderService.AddHeadersToRequest(HttpContextAccessor.HttpContext.Request, GetHttpCliente(httpClientConfigurationName), false);

            var responseMessage = await httpclient.GetAsync($"{requestEndpoint}?requestMessage={JsonConvert.SerializeObject(requestMessage)}");

            var response = GetResponses<TResponseMessage>(responseMessage);

            response.SetContent(responseMessage.Content).SetStatusCode(responseMessage.StatusCode);

            HttpContextAccessor.HttpContext.Response.StatusCode = (int)responseMessage.StatusCode;

            return HeaderService.AddHeadersToResponse(response, responseMessage);
        }

        public async Task<Response<TResponseMessage>> PostAsync<TRequestMessage, TResponseMessage>(string requestEndpoint, TRequestMessage requestMessage, string httpClientConfigurationName)
            where TRequestMessage : RequestMessage
            where TResponseMessage : ResponseMessage
        {
            var content = new ObjectContent<RequestMessage>(requestMessage, new JsonMediaTypeFormatter());

            var httpclient = HeaderService.AddHeadersToRequest(HttpContextAccessor.HttpContext.Request, GetHttpCliente(httpClientConfigurationName));

            var responseMessage = await httpclient.PostAsync(requestEndpoint, content);

            var response = GetResponse<TResponseMessage>(responseMessage);

            response.SetContent(responseMessage.Content).SetStatusCode(responseMessage.StatusCode);

            HttpContextAccessor.HttpContext.Response.StatusCode = (int)responseMessage.StatusCode;

            return HeaderService.AddHeadersToResponse(response, responseMessage);
        }

        public async Task<Response> DeleteAsync(string requestEndpoint, Guid code, string httpClientConfigurationName)
        {
            var response = Response.Create();

            var httpclient = HeaderService.AddHeadersToRequest(HttpContextAccessor.HttpContext.Request, GetHttpCliente(httpClientConfigurationName));

            var responseMessage = await httpclient.DeleteAsync($"{requestEndpoint}/{code}");

            if (responseMessage.IsSuccessStatusCode)
            {
                response = responseMessage.GetResponse();
            }

            response.SetContent(responseMessage.Content).SetStatusCode(responseMessage.StatusCode);

            HttpContextAccessor.HttpContext.Response.StatusCode = (int)responseMessage.StatusCode;

            return HeaderService.AddHeadersToResponse(response, responseMessage);
        }

        #region ' PUT '

        public async Task<Response> PutAsync<TRequestMessage>(string requestEndpoint, TRequestMessage requestMessage, string httpClientConfigurationName)
            where TRequestMessage : RequestMessage
        {
            var response = Response.Create();

            var content = new ObjectContent<RequestMessage>(requestMessage, new JsonMediaTypeFormatter());

            var httpclient = HeaderService.AddHeadersToRequest(HttpContextAccessor.HttpContext.Request, GetHttpCliente(httpClientConfigurationName));

            var responseMessage = await httpclient.PutAsync($"{requestEndpoint}", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                response = responseMessage.GetResponse();
            }

            response.SetContent(responseMessage.Content).SetStatusCode(responseMessage.StatusCode);

            HttpContextAccessor.HttpContext.Response.StatusCode = (int)responseMessage.StatusCode;

            return HeaderService.AddHeadersToResponse(response, responseMessage);
        }

        public async Task<Response<TResponseMessage>> PutAsync<TRequestMessage, TResponseMessage>(string requestEndpoint, TRequestMessage requestMessage, string httpClientConfigurationName)
            where TRequestMessage : RequestMessage
            where TResponseMessage : ResponseMessage
        {
            var content = new ObjectContent<RequestMessage>(requestMessage, new JsonMediaTypeFormatter());

            var httpclient = HeaderService.AddHeadersToRequest(HttpContextAccessor.HttpContext.Request, GetHttpCliente(httpClientConfigurationName));

            var responseMessage = await httpclient.PutAsync($"{requestEndpoint}", content);

            var response = GetResponse<TResponseMessage>(responseMessage);

            response.SetContent(responseMessage.Content).SetStatusCode(responseMessage.StatusCode);

            HttpContextAccessor.HttpContext.Response.StatusCode = (int)responseMessage.StatusCode;

            return HeaderService.AddHeadersToResponse(response, responseMessage);
        }

        public async Task<Response> PutAsync<TRequestMessage>(string requestEndpoint, Guid code, TRequestMessage requestMessage, string httpClientConfigurationName)
            where TRequestMessage : RequestMessage
        {
            var response = Response.Create();

            var content = new ObjectContent<RequestMessage>(requestMessage, new JsonMediaTypeFormatter());

            var httpclient = HeaderService.AddHeadersToRequest(HttpContextAccessor.HttpContext.Request, GetHttpCliente(httpClientConfigurationName));

            var responseMessage = await httpclient.PutAsync($"{requestEndpoint}/{code}", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                response = responseMessage.GetResponse();
            }

            response.SetContent(responseMessage.Content).SetStatusCode(responseMessage.StatusCode);

            HttpContextAccessor.HttpContext.Response.StatusCode = (int)responseMessage.StatusCode;

            return HeaderService.AddHeadersToResponse(response, responseMessage);
        }

        public async Task<Response<TResponseMessage>> PutAsync<TRequestMessage, TResponseMessage>(string requestEndpoint, Guid code, TRequestMessage requestMessage, string httpClientConfigurationName)
            where TRequestMessage : RequestMessage
            where TResponseMessage : ResponseMessage
        {
            var content = new ObjectContent<RequestMessage>(requestMessage, new JsonMediaTypeFormatter());

            var httpclient = HeaderService.AddHeadersToRequest(HttpContextAccessor.HttpContext.Request, GetHttpCliente(httpClientConfigurationName));

            var responseMessage = await httpclient.PutAsync($"{requestEndpoint}/{code}", content);

            var response = GetResponse<TResponseMessage>(responseMessage);

            response.SetContent(responseMessage.Content).SetStatusCode(responseMessage.StatusCode);

            HttpContextAccessor.HttpContext.Response.StatusCode = (int)responseMessage.StatusCode;

            return HeaderService.AddHeadersToResponse(response, responseMessage);
        }

        #endregion
    }
}
