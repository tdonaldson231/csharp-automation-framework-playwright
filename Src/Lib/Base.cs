using System.Threading.Tasks;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class Base
{
    protected readonly string testEnvironment = "";  // specify when runnig visual studio debug else the environment: "dev";

    protected static IPlaywright _playwright;
    protected static IBrowser _browser;
    protected static IBrowserContext _context;
    protected static IPage _page;
    private static bool _isUiInitialized = false;

    public static string restApiUrl = "https://api.restful-api.dev";
    public static string mySqlConnection = "Server=localhost;Port=3306;Database=testdb;User ID=testuser;Password=testpassword;";

    public Base(TestConfigFixture config)
    {
        testEnvironment = !string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("testEnvironment"))
            ? Environment.GetEnvironmentVariable("testEnvironment")
            : (!string.IsNullOrWhiteSpace(testEnvironment) ? testEnvironment : "local");
    }
}
