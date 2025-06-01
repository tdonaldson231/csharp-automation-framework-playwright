using Microsoft.Extensions.DependencyInjection;
using AutomationFramework.Interfaces.RestApi;
using Reqnroll.Microsoft.Extensions.DependencyInjection;

namespace AutomationFramework.DependencyInjection
{
    public static class ApiTestingServices
    {
        [ScenarioDependencies]
        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            // Registering config fixture so DI can provide it
            services.AddSingleton<TestConfigFixture>();

            // Registering API client with injected TestConfigFixture
            services.AddSingleton<IApiClient>(provider =>
            {
                var config = provider.GetRequiredService<TestConfigFixture>();
                return new RestSharpClient(config.RestApiUrl);
            });

            return services;
        }
    }
}
