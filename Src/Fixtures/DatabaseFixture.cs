using MySql.Data.MySqlClient;
using NUnit.Framework;
using System.Threading.Tasks;

namespace AutomationFramework.Features.Sql
{
    public class DatabaseFixture
    {
        public static DockerComposeHelper DockerHelper { get; private set; }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            DockerHelper = new DockerComposeHelper();
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

        private static async Task WaitForDatabaseAsync(int maxAttempts = 15)
        {
            int attempts = 0;
            while (attempts < maxAttempts)
            {
                try
                {
                    using var connection = new MySqlConnection(Base.mySqlConnection);
                    await connection.OpenAsync();
                    return;
                }
                catch
                {
                    attempts++;
                    await Task.Delay(2500); // Wait before retrying
                }
            }

            throw new Exception("Failed to connect to the database after multiple attempts.");
        }
    }
}