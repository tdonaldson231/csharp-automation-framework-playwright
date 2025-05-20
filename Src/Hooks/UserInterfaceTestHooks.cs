using Microsoft.Playwright;
using Reqnroll;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AutomationFrameworkRepo_v03.Src.Hooks
{
    [Binding]
    public class UiTestHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly UserInterfaceFixture _uiFixture;
        private static string dateTime = DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss");
        private readonly string projectPath;

        public UiTestHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _uiFixture = _scenarioContext.Get<UserInterfaceFixture>();
        }

        [AfterStep]
        public async Task AfterEachStepAsync()
        {
            if (_scenarioContext.TestError != null && _uiFixture?.Page != null)
            {
                try
                {
                    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string projectPath = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
                    string screenshotPath = Path.Combine(projectPath, $"Reports/SreenCaptures/Screenshot_{dateTime}.png");

                    await _uiFixture.Page.ScreenshotAsync(new PageScreenshotOptions
                    {
                        Path = screenshotPath,
                        FullPage = true
                    });

                    Console.WriteLine($"🖼️ Screenshot saved at: {screenshotPath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"⚠️ Failed to take screenshot: {ex.Message}");
                }
            }
        }
    }
}
