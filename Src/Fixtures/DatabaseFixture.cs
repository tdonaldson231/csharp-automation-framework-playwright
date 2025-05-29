using MySql.Data.MySqlClient;

namespace AutomationFramework.Features.Sql
{
    [SetUpFixture]
    public class DatabaseFixture
    {
        private TestConfigFixture _config;

        public static DockerComposeHelper DockerHelper { get; private set; }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _config = new TestConfigFixture();
            DockerHelper = new DockerComposeHelper(_config);
            await WaitForDatabaseAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTeardown()
        {
            if (DockerHelper != null)
            {
                await DockerHelper.DisposeAsync();
            }
        }

        private async Task WaitForDatabaseAsync(int maxAttempts = 15)
        {
            int attempts = 0;
            while (attempts < maxAttempts)
            {
                try
                {
                    using var connection = new MySqlConnection(_config.MySqlConnection);
                    await connection.OpenAsync();
                    return;
                }
                catch (Exception ex)
                {
                    attempts++;
                    Console.WriteLine($"Attempt {attempts} failed: {ex.Message}");
                    await Task.Delay(2500);
                }
            }

            throw new Exception("Failed to connect to the database after multiple attempts.");
        }
    }
}
