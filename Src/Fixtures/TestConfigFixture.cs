using System.Diagnostics;

public class TestConfigFixture
{
    public string TestEnvironment { get; }
    public string DbServer { get; }
    public string RestApiUrl { get; set; }
    public string MySqlConnection { get; }
    public string CurrentWorkingDir { get; }
    public string ProjectPath { get; }
    public string UserJourneyUrl { get; }
    public string SuiteType { get; }
    public string MockServerUrl { get; }

    public TestConfigFixture()
    {
        TestEnvironment = TestContext.Parameters["testEnvironment"] ?? "dev";

        DbServer = TestContext.Parameters["dbServer"] ?? "mysql";
        MySqlConnection = $"Server={DbServer};Port=3306;Database={TestEnvironment}db;User ID={TestEnvironment}user;Password={TestEnvironment}password;";

        RestApiUrl = $"https://api.restful-api.{TestEnvironment}";
        MockServerUrl = $"{TestContext.Parameters["mockServerUrl"]}/{TestEnvironment}";
        UserJourneyUrl = TestContext.Parameters["userJourneyUrl"];

        CurrentWorkingDir = Directory.GetCurrentDirectory();
        ProjectPath = Directory.GetParent(CurrentWorkingDir)?.Parent?.Parent?.FullName
            ?? throw new DirectoryNotFoundException("Unable to resolve project root.");

        // Get the namespace of the class that triggered the test
        var testNamespace = GetCallingTestNamespace();
        if (testNamespace != null && testNamespace.Contains("Services"))
        {
            Console.WriteLine("Detected Service/Journey Test");
            SuiteType = "Journeys";
        }
        else
        {
            Console.WriteLine("Detected Suite Test");
            SuiteType = "UserInterface";
        }
    }

    private string? GetCallingTestNamespace()
    {
        var stackTrace = new StackTrace();

        foreach (var frame in stackTrace.GetFrames())
        {
            var method = frame.GetMethod();
            if (method == null) continue;

            var declaringType = method.DeclaringType;
            if (declaringType == null) continue;

            // Skip the fixture class itself
            if (declaringType == typeof(TestConfigFixture)) continue;

            return declaringType.Namespace;
        }

        return null;
    }
}
