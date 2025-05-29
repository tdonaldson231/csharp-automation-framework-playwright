public class TestConfigFixture
{
    public string TestEnvironment { get; }
    public string RestApiUrl { get; }
    public string MySqlConnection { get; }
    public string CurrentWorkingDir { get; }
    public string ProjectPath { get; }

    public TestConfigFixture()
    {
        TestEnvironment = TestContext.Parameters["testEnvironment"] ?? "dev";
        RestApiUrl = $"https://api.restful-api.{TestEnvironment}";
        MySqlConnection = $"Server=localhost;Port=3306;Database={TestEnvironment}db;User ID={TestEnvironment}user;Password={TestEnvironment}password;";
        CurrentWorkingDir = Directory.GetCurrentDirectory();
        ProjectPath = Directory.GetParent(CurrentWorkingDir)?.Parent?.Parent?.FullName
                      ?? throw new DirectoryNotFoundException("Unable to resolve project root.");
    }
}
