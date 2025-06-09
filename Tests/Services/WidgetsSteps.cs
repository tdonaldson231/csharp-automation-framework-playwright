using AutomationFramework.Features.UserInterface;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reqnroll;


namespace AutomationFramework.Tests.Services
{
    [Binding]
    [Scope(Tag = "journey2")]
    public class WidgetsSteps
    {
        private readonly UserInterfaceFixture _uiFixture;
        private readonly PlaywrightFixture _configFixture;

        public WidgetsSteps(ScenarioContext scenarioContext)
        {
            var testConfig = new TestConfigFixture();
            _configFixture = new PlaywrightFixture(testConfig);
            _uiFixture = scenarioContext.Get<UserInterfaceFixture>();
        }

        [Given(@"the user is on the home page")]
        public async Task GivenUserNavigatesToTheHomePage()
        {
            await _uiFixture.Page.GotoAsync(_configFixture.GetSelector("WebPage", "Url"));
            var image = _uiFixture.Page.Locator(_configFixture.GetSelector("HomePage", "HomePageImage"));
            NUnit.Framework.Assert.That(await image.IsVisibleAsync());
        }

        [When(@"the user accesses the elements page")]
        public async Task WhenUserAccessesAndClicksOnElements()
        {
            NUnit.Framework.Assert.That(await _uiFixture.Page.GetByText(_configFixture.GetSelector("HomePage", "ElementsText")).IsVisibleAsync(), Is.True, "Elements Text is not visible");
            await _uiFixture.Page.GetByText(_configFixture.GetSelector("HomePage", "ElementsText")).ClickAsync();
        }

        [When(@"the user navigates to the widgets page")]
        public async Task WhenUserNavigatesAndClicksOnWidgets()
        {
            NUnit.Framework.Assert.That(await _uiFixture.Page.Locator(_configFixture.GetSelector("WidgetsPage", "WidgetsHeader")).IsVisibleAsync(), Is.True, "Widgets Header is not visible");
            await _uiFixture.Page.Locator(_configFixture.GetSelector("WidgetsPage", "WidgetsHeader")).ClickAsync();
        }

        [Then(@"the user journey has completed successfully")]
        public async Task ThenWidgetsUserJourneyCompletedSuccessfully()
        {
            NUnit.Framework.Assert.That(await _uiFixture.Page.Locator(_configFixture.GetSelector("WidgetsPage", "WidgetsSelectMenu")).IsVisibleAsync(), Is.True, "Widgets Select Menu Form is not visible");
        }
    }
}
