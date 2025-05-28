using System.Net;

namespace AutomationFramework.Interfaces.RestApi
{
    public interface IApiClient
    {
        HttpStatusCode GetStatus(string endpoint);
        string GetResponseContent(string endpoint);
    }
}
