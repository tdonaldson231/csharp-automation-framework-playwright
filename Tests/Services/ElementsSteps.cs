using AutomationFramework.Features.UserInterface;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reqnroll;


namespace AutomationFramework.Tests.Services
{
    [Binding]
    [Scope(Tag = "journeys")]
    public class ElementsSteps
    {
        private readonly UserInterfaceFixture _uiFixture;
        private readonly PlaywrightFixture _configFixture;

        public ElementsSteps(ScenarioContext scenarioContext)
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
        public async Task WhenUserEntersNameMessageAndClicksSubmit()
        {
            NUnit.Framework.Assert.That(await _uiFixture.Page.GetByText(_configFixture.GetSelector("HomePage", "Elements")).IsVisibleAsync(), Is.True, "Elements is not visible");
            await _uiFixture.Page.GetByText(_configFixture.GetSelector("HomePage", "Elements")).ClickAsync();
        }

        [When(@"the user navigates to the forms page")]
        public async Task WhenUserEntersNameMessageAndClicksForms()
        {
            NUnit.Framework.Assert.That(await _uiFixture.Page.Locator(_configFixture.GetSelector("ElementsPage", "Forms")).IsVisibleAsync(), Is.True, "Forms is not visible");
            await _uiFixture.Page.Locator(_configFixture.GetSelector("ElementsPage", "Forms")).ClickAsync();
        }

        [Then(@"the user journey has completed successfully")]
        public async Task ThenFormIsProcessedWithThankYouMessage()
        {
            NUnit.Framework.Assert.That(await _uiFixture.Page.Locator(_configFixture.GetSelector("ElementsPage", "PracticeForm")).IsVisibleAsync(), Is.True, "Practice Form is not visible");
        }
    }
}
