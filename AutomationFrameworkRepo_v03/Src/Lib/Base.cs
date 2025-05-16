using System.Threading.Tasks;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class Base
{
    protected static IPlaywright _playwright;
    protected static IBrowser _browser;
    protected static IBrowserContext _context;
    protected static IPage _page;
    private static bool _initialized = false;

    [BeforeTestRun] // Ensures Playwright initializes once per test suite
    public static async Task GlobalSetup()
    {
        if (!_initialized)
        {
            _playwright = await Playwright.CreateAsync();
            var configFixture = new PlaywrightFixture();

            string browserOptionHeadlessString = configFixture.GetSelector("BrowserOptions", "Headless");
            bool browserOptionHeadless = bool.Parse(browserOptionHeadlessString);

            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = browserOptionHeadless });
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();

            Console.WriteLine("_page initialized successfully.");
            _initialized = true;
        }
    }

    [AfterTestRun] // Ensures browser cleanup after all scenarios
    public static async Task GlobalTeardown()
    {
        if (_browser != null)
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }
    }
}
