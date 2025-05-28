using Reqnroll;

[Binding]
public class Base
{
    public static string testEnvironment = TestContext.Parameters["testEnvironment"] ?? "dev";
    public static string restApiUrl => $"https://api.restful-api.{testEnvironment}";

    public static string mySqlConnection = $"Server=localhost;Port=3306;Database={testEnvironment}db;User ID={testEnvironment}user;Password={testEnvironment}password;";
    
    public static string currentWorkingDir = Directory.GetCurrentDirectory();
    public static string projectPath = Directory.GetParent(currentWorkingDir)?.Parent?.Parent?.FullName
        ?? throw new DirectoryNotFoundException("Unable to resolve project root.");

    public Base(TestConfigFixture config)
    {
        Console.WriteLine($"Environment: {testEnvironment}");
        Console.WriteLine($"API URL: {restApiUrl}");
        Console.WriteLine($"SQL DB: {testEnvironment}db");
        Console.WriteLine($"Current Working Directory: {currentWorkingDir}");
        Console.WriteLine($"Project Path: {projectPath}");
        
    }
}
