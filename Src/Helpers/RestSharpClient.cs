using RestSharp;
using System;
using System.Net;

namespace AutomationFramework.Interfaces.RestApi
{
    public class RestSharpClient : IApiClient
    {
        private readonly RestClient _client;

        public RestSharpClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public HttpStatusCode GetStatus(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);
            var response = _client.Execute(request);
            return response.StatusCode;
        }

        public string GetResponseContent(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);
            var response = _client.Execute(request);
            return response.Content ?? string.Empty;
        }
    }
}
