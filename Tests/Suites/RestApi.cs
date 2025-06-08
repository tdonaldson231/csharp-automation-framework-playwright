using AutomationFramework.Interfaces.RestApi;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Reqnroll;
using System.ComponentModel;
using System.Net;

namespace AutomationFramework.Tests.Suites
{
    [Binding]
    public class BackendRestApi : Base
    {
        private readonly IApiClient _apiClient;
        private string? _endpoint;
        private HttpStatusCode _statusCode;
        private string _responseContent = string.Empty;

        // Scans your code for static methods with [ScenarioDependencies] attribute
        // Calls that method to get the IServiceCollection
        // Builds its DI container from it
        public BackendRestApi(IApiClient apiClient) : base(new TestConfigFixture())
        {
            _apiClient = apiClient;
        }

        [Given(@"the backend is up and operational")]
        public void GivenTheBackendIsUpAndOperational()
        {
            _statusCode = _apiClient.GetStatus("/");
            Assert.That(_statusCode, Is.EqualTo(HttpStatusCode.OK), "Backend is not operational.");
        }

        [Given(@"the API endpoint is ""(.*)""")]
        public void GivenTheApiEndpointIs(string endpoint)
        {
            _endpoint = endpoint;
        }

        [When(@"a GET request is sent to the backend API")]
        public void WhenAGETRequestIsSentToTheBackendAPI()
        {
            if (string.IsNullOrEmpty(_endpoint)) throw new ArgumentException("Endpoint is null or empty.");
            _statusCode = _apiClient.GetStatus(_endpoint);
            _responseContent = _apiClient.GetResponseContent(_endpoint);
        }

        [Then(@"the response status code should be ""(.*)""")]
        public void ThenTheResponseStatusCodeShouldBe(string expectedStatus)
        {
            var expectedCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), expectedStatus);
            Assert.That(_statusCode, Is.EqualTo(expectedCode), $"Expected: {expectedCode}, Got: {_statusCode}");
        }
    }
}
