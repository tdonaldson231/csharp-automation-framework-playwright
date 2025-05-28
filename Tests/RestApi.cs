using RestSharp;
using System;
using NUnit.Framework;
using Reqnroll;
using AventStack.ExtentReports;


namespace AutomationFramework.Features.RestApi
{
    [Binding]
    public class BackendRestApi : Base
    {
        private RestResponse? _response; 
        private string? _endpoint;
        private string? testMsg;

        public BackendRestApi() : base(new TestConfigFixture())
        {
        }

        [Given(@"the backend is up and operational")]
        public void GivenTheBackendIsUpAndOperational()
        {
            string apiUrl = Base.restApiUrl;
            var client = new RestClient(apiUrl);
            var request = new RestRequest("/", Method.Get);

            if (_response != null)
            {
                throw new InvalidOperationException("Response has not been initialized.");
            }
            else
            {                 
                _response = client.Execute(request);
            }
        }

        [Given(@"the API endpoint is ""(.*)""")]
        public void GivenTheApiEndpointIs(string endpoint)
        {
            _endpoint = endpoint;
        }

        [When(@"a GET request is sent to the backend API")]
        public void WhenAGETRequestIsSentToTheBackendAPI()
        {

            var baseUrl = Base.restApiUrl;
            var endpoint = _endpoint?.TrimStart('/');
            var fullUrl = $"{baseUrl}/{endpoint}";
            Console.WriteLine($"Full request URL: {fullUrl}");

            var client = new RestClient(baseUrl);
            var request = new RestRequest($"/{endpoint}", Method.Get);

            _response = client.Execute(request);
        }

        [Then(@"the response status code should be ""(.*)""")]
        public void ThenTheResponseStatusCodeShouldBe(string expectedStatus)
        {
            try
            {
                if (_response == null)
                {
                    testMsg = "FAIL: Response is null.";
                    throw new AssertionException(testMsg);
                }

                string actualStatus = _response.StatusCode.ToString();
                Assert.That(expectedStatus, Is.EqualTo(actualStatus));

                testMsg = $"PASS: Expected status '{expectedStatus}' matched actual '{actualStatus}'.";
            }
            catch (AssertionException ex)
            {
                testMsg = $"FAIL: Status mismatch. Expected '{expectedStatus}', got '{_response?.StatusCode}'. {ex.Message}";
                throw;
            }
            finally
            {
                Console.WriteLine(testMsg);
                if (_response != null)
                    Console.WriteLine(_response.StatusCode);
            }
        }
    }
}
