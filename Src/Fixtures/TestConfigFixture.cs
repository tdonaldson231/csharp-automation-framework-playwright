public class TestConfigFixture
{
    public string TestEnvironment { get; }
    public string DbServer { get; }
    public string RestApiUrl { get; }
    public string MySqlConnection { get; }
    public string CurrentWorkingDir { get; }
    public string ProjectPath { get; }

    public TestConfigFixture()
    {
        TestEnvironment = TestContext.Parameters["testEnvironment"] ?? "dev";
        DbServer = TestContext.Parameters["dbServer"] ?? "mysql";

        RestApiUrl = $"https://api.restful-api.{TestEnvironment}";
        MySqlConnection = $"Server={DbServer};Port=3306;Database={TestEnvironment}db;User ID={TestEnvironment}user;Password={TestEnvironment}password;";
        CurrentWorkingDir = Directory.GetCurrentDirectory();
        ProjectPath = Directory.GetParent(CurrentWorkingDir)?.Parent?.Parent?.FullName
                      ?? throw new DirectoryNotFoundException("Unable to resolve project root.");
    }
}
