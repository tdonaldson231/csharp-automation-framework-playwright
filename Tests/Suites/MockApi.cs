using AutomationFramework.Interfaces.RestApi;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Reqnroll;
using System.ComponentModel;
using System.Net;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace AutomationFramework.Tests.Suites
{
    [Binding]
    public class MockRestApi : Base
    {
        private readonly TestConfigFixture _config;
        private IApiClient _apiClient;
        private string? _endpoint;
        private HttpStatusCode _statusCode;
        private string _responseContent = string.Empty;

        public MockRestApi(IApiClient apiClient, TestConfigFixture config) : base(config)
        {
            _apiClient = apiClient;
            _config = config;
        }

        [BeforeScenario("mockapi")]
        public void UseMockServer()
        {
            Console.WriteLine($"[DEBUG] Switching base URL from {_config.RestApiUrl} to {_config.MockServerUrl}");
            _config.RestApiUrl = _config.MockServerUrl;

            // Create the API client using the updated URL
            _apiClient = new RestSharpClient(_config.RestApiUrl);
        }

        [Given(@"the mock backend is up and operational")]
        public void GivenTheBackendIsUpAndOperational()
        {
            _statusCode = _apiClient.GetStatus("/");
            Assert.That(_statusCode, Is.EqualTo(HttpStatusCode.OK), "Mock backend is not operational.");
        }

        [Given(@"the Mock API endpoint is ""(.*)""")]
        public void GivenTheApiEndpointIs(string endpoint)
        {
            _endpoint = endpoint;
        }

        [When(@"a GET request is sent to the mock API")]
        public void WhenAGETRequestIsSentToTheBackendAPI()
        {
            if (string.IsNullOrEmpty(_endpoint)) throw new ArgumentException("Endpoint is null or empty.");
            _statusCode = _apiClient.GetStatus(_endpoint);
            _responseContent = _apiClient.GetResponseContent(_endpoint);
        }

        [Then(@"the mock response status code should be ""(.*)""")]
        public void ThenTheResponseStatusCodeShouldBe(string expectedStatus)
        {
            var expectedCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), expectedStatus);
            Assert.That(_statusCode, Is.EqualTo(expectedCode), $"Expected: {expectedCode}, Got: {_statusCode}");
        }
    }
}
