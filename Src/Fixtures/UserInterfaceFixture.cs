using Microsoft.Playwright;

namespace AutomationFramework.Features.UserInterface
{
    public class UserInterfaceFixture
    {
        public IPlaywright Playwright { get; private set; } = null!;
        public IBrowser Browser { get; private set; } = null!;
        public IBrowserContext Context { get; private set; } = null!;
        public IPage Page { get; private set; } = null!;

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
}

