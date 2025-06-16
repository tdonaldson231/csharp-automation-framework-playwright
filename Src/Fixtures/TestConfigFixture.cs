using dotenv.net;
using System.Diagnostics;
using DotEnv = dotenv.net.DotEnv;

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
        // Load .env if it exists (optional)
        //var envFile = $"Tests/RunSettings/.env.{Environment.GetEnvironmentVariable("ENV_NAME") ?? "dev"}";
        TestEnvironment = TestContext.Parameters["testEnvironment"] ?? "dev";

        var envPath = Path.Combine($".env.{TestEnvironment}");
        if (!File.Exists(envPath))
        {
            Console.WriteLine($"[WARN] .env file not found: {envPath}");
        }
        else
        {
            Console.WriteLine($"[INFO] Loading .env file from: {envPath}");

            DotEnv.Load(new DotEnvOptions(
                envFilePaths: new[] { envPath },
                probeForEnv: false, // <-- Disable probing (you are giving the path directly)
                ignoreExceptions: false,
                overwriteExistingVars: true
            ));

            Console.WriteLine($"[INFO] DB_SERVER loaded: {Environment.GetEnvironmentVariable("DB_SERVER") ?? "null"}");
        }


        DbServer = Environment.GetEnvironmentVariable("DB_SERVER");
        var dbName = Environment.GetEnvironmentVariable("DB_NAME");
        var dbUser = Environment.GetEnvironmentVariable("DB_USER");
        var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
        MySqlConnection = $"Server={DbServer};Port=3306;Database={dbName};User ID={dbUser};Password={dbPassword};";

        Console.WriteLine($"[DEBUG] DB_SERVER: {Environment.GetEnvironmentVariable("DB_SERVER")}");
        Console.WriteLine($"[DEBUG] DB_NAME: {Environment.GetEnvironmentVariable("DB_NAME")}");
        Console.WriteLine($"[DEBUG] DB_USER: {Environment.GetEnvironmentVariable("DB_USER")}");
        Console.WriteLine($"[DEBUG] DB_PASSWORD: {Environment.GetEnvironmentVariable("DB_PASSWORD")}");

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
