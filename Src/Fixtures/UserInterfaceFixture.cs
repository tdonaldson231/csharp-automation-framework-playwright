using Microsoft.Playwright;

public class UserInterfaceFixture
{
    public IPlaywright Playwright { get; private set; }
    public IBrowser Browser { get; private set; }
    public IBrowserContext Context { get; private set; }
    public IPage Page { get; private set; }

    public async Task InitializeAsync()
    {
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        var configFixture = new PlaywrightFixture();

        bool headless = bool.Parse(configFixture.GetSelector("BrowserOptions", "Headless"));
        Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = headless });
        Context = await Browser.NewContextAsync();
        Page = await Context.NewPageAsync();
    }

    public async Task TeardownAsync()
    {
        if (Browser != null)
        {
            await Browser.CloseAsync();
            Playwright.Dispose();
        }
    }
}

