using Microsoft.Playwright;
using Reqnroll;


namespace AutomationFramework.Features.UserInterface
{
    [Binding]
    public class PortalTests
    {
        private readonly UserInterfaceFixture _uiFixture;
        private readonly PlaywrightFixture _configFixture;

        public PortalTests(ScenarioContext scenarioContext)
        {
            _uiFixture = scenarioContext.Get<UserInterfaceFixture>();
            var testConfig = new TestConfigFixture();
            _configFixture = new PlaywrightFixture(testConfig);
        }

        [Given(@"the user navigates to the form page")]
        public async Task GivenUserNavigatesToTheFormPage()
        {
            await _uiFixture.Page.GotoAsync(_configFixture.GetSelector("WebPage", "Url"));
        }

        [When(@"the user enters a name, message, and clicks the submit button")]
        public async Task WhenUserEntersNameMessageAndClicksSubmit()
        {
            await _uiFixture.Page.ClickAsync(_configFixture.GetSelector("AutomationPage", "FormPage"));
            await _uiFixture.Page.FillAsync(_configFixture.GetSelector("FillOutFormPage", "ContactNameId"), _configFixture.GetSelector("FillOutFormPage", "NameField"));
            await _uiFixture.Page.FillAsync(_configFixture.GetSelector("FillOutFormPage", "ContactMessageId"), _configFixture.GetSelector("FillOutFormPage", "MessageField"));
            await _uiFixture.Page.ClickAsync(_configFixture.GetSelector("FillOutFormPage", "SubmitButton"));
        }

        [Then(@"the form is processed with a thank you message")]
        public async Task ThenFormIsProcessedWithThankYouMessage()
        {
            string confirmationText = await _uiFixture.Page.InnerTextAsync("p:has-text('Thanks for contacting us')");
            Assert.That(confirmationText, Is.EqualTo("Thanks for contacting us"));
        }
    }
}
