using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using Reqnroll;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AutomationFramework.Features.Sql
{
    [Binding]
    public class SqlQueries
    {
        private List<(string Name, int Score)> _results = new();
        private string _connectionString = Base.mySqlConnection;
             
        [Given("the database is up and running")]
        public async Task GivenTheDatabaseIsUpAndRunning()
        {
            int attempts = 0;
            int maxAttempts = 15;
            while (attempts < maxAttempts)
            {
                try
                {
                    using var connection = new MySqlConnection(_connectionString);
                    await connection.OpenAsync();
                    if (connection.State == ConnectionState.Open) return;
                }
                catch
                {
                    await Task.Delay(2500);
                    attempts++;
                }
            }
            throw new Exception("Failed to connect to the database.");
        }

        [When(@"the ""(.*)"" stored procedure is executed with minimum score (\d+)")]
        public async Task WhenStoredProcedureIsExecuted(string procedureName, int minScore)
        {
            _results = new();

            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new MySqlCommand(procedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@min_score", minScore);
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                _results.Add((reader.GetString("name"), reader.GetInt32("score")));
            }

            Assert.That(_results, Is.Not.Empty, "Stored procedure returned no results.");
        }

        [Then("the results should all have scores >= (\\d+)")]
        public void ThenScoresShouldBeGreaterThanOrEqualTo(int expectedScore)
        {
            foreach (var (name, score) in _results)
            {
                Assert.That(score, Is.GreaterThanOrEqualTo(expectedScore),
                    $"Score {score} for {name} is below {expectedScore}");
            }
        }

        [When(@"I query the ""(.*)"" table")]
        public async Task WhenIQueryTheTable(string tableName)
        {
            string query = $"SELECT name, score FROM {tableName}";
            _results = new();

            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new MySqlCommand(query, connection);
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                _results.Add((reader.GetString("name"), reader.GetInt32("score")));
            }

            Assert.That(_results.Count, Is.GreaterThan(0), $"No results found in '{tableName}' table.");
        }

        [Then(@"I should find user ""(.*)"" with score >= (\d+)")]
        public void ThenUserScoreShouldBeAtLeast(string userName, int expectedScore)
        {
            bool found = _results.Any(r => r.Name == userName && r.Score >= expectedScore);
            Assert.That(found, Is.True, $"User '{userName}' with score >= {expectedScore} not found.");
        }
    }
}
