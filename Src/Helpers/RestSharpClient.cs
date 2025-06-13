using RestSharp;
using System;
using System.Net;

namespace AutomationFramework.Interfaces.RestApi
{
    public class RestSharpClient : IApiClient
    {
        private readonly RestClient _client;
        private readonly string _baseUrl;

        public RestSharpClient(string baseUrl)
        {
            _baseUrl = baseUrl.TrimEnd('/'); // prevent double slashes
            Console.WriteLine($"[DEBUG] Initialized RestSharpClient with base URL: {_baseUrl}");

            _client = new RestClient(_baseUrl);
        }

        public HttpStatusCode GetStatus(string endpoint)
        {
            var fullUrl = $"{_baseUrl}{NormalizeEndpoint(endpoint)}";
            Console.WriteLine($"[DEBUG] Sending GET request to: {fullUrl}");

            var request = new RestRequest(endpoint, Method.Get);
            var response = _client.Execute(request);

            Console.WriteLine($"[DEBUG] Status Code: {response.StatusCode}");
            return response.StatusCode;
        }

        public string GetResponseContent(string endpoint)
        {
            var fullUrl = $"{_baseUrl}{NormalizeEndpoint(endpoint)}";
            Console.WriteLine($"[DEBUG] Sending GET request to: {fullUrl}");

            var request = new RestRequest(endpoint, Method.Get);
            var response = _client.Execute(request);

            Console.WriteLine($"[DEBUG] Response Content: {response.Content}");
            return response.Content ?? string.Empty;
        }

        private static string NormalizeEndpoint(string endpoint)
        {
            return endpoint.StartsWith("/") ? endpoint : "/" + endpoint;
        }
    }
}

