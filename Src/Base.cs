using Reqnroll;

[Binding]
public class Base
{
    protected readonly TestConfigFixture Config;

    public Base(TestConfigFixture config)
    {
        Config = config;

        Console.WriteLine($"Environment: {Config.TestEnvironment}");
        Console.WriteLine($"API URL: {Config.RestApiUrl}");
        Console.WriteLine($"Mock API URL: {Config.MockServerUrl}");
        Console.WriteLine($"User Journey URL: {Config.UserJourneyUrl}");
        Console.WriteLine($"SQL DB: {Config.MySqlConnection}");
        Console.WriteLine($"Current Working Directory: {Config.CurrentWorkingDir}");
        Console.WriteLine($"Project Path: {Config.ProjectPath}");
    }
}
