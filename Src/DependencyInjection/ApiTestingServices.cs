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
            services.AddSingleton<TestConfigFixture>();

            services.AddScoped<IApiClient>(provider =>
            {
                var config = provider.GetRequiredService<TestConfigFixture>();
                return new RestSharpClient(config.RestApiUrl);
            });

            return services;
        }
    }
}
