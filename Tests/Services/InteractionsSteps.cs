using AutomationFramework.Features.UserInterface;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reqnroll;


namespace AutomationFramework.Tests.Services
{
    [Binding]
    [Scope(Tag = "journey3")]
    public class InteractiveSteps
    {
        private readonly UserInterfaceFixture _uiFixture;
        private readonly PlaywrightFixture _configFixture;

        public InteractiveSteps(ScenarioContext scenarioContext)
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

        [When(@"the user accesses the forms page")]
        public async Task WhenUserAccessesAndClicksOnForms()
        {
            NUnit.Framework.Assert.That(await _uiFixture.Page.GetByText(_configFixture.GetSelector("HomePage", "FormsText")).IsVisibleAsync(), Is.True, "Forms Text is not visible");
            await _uiFixture.Page.GetByText(_configFixture.GetSelector("HomePage", "FormsText")).ClickAsync();
        }

        [When(@"the user navigates to the widgets page")]
        public async Task WhenUserNavigatesAndClicksOnWidgets()
        {
            NUnit.Framework.Assert.That(await _uiFixture.Page.Locator(_configFixture.GetSelector("WidgetsPage", "WidgetsHeader")).IsVisibleAsync(), Is.True, "Widgets Header is not visible");
            await _uiFixture.Page.Locator(_configFixture.GetSelector("WidgetsPage", "WidgetsHeader")).ClickAsync();
        }

        [When(@"the user navigates to the interactions page")]
        public async Task WhenUserNavigatesAndClicksOnInteractions()
        {
            NUnit.Framework.Assert.That(await _uiFixture.Page.Locator(_configFixture.GetSelector("InteractionsPage", "InteractionsHeader")).IsVisibleAsync(), Is.True, "Interactions Header is not visible");
            await _uiFixture.Page.Locator(_configFixture.GetSelector("InteractionsPage", "InteractionsHeader")).ClickAsync();
        }


        [Then(@"the user journey has completed successfully")]
        public async Task ThenInteractionsUserJourneyCompletedSuccessfully()
        {
            NUnit.Framework.Assert.That(await _uiFixture.Page.Locator(_configFixture.GetSelector("InteractionsPage", "InteractionsResizable")).IsVisibleAsync(), Is.True, "Interactions Resizable is not visible");
        }
    }
}