using Microsoft.Playwright;
using Reqnroll;


[Binding]
public class SubmitForm : Base
{
    private readonly PlaywrightFixture _configFixture;

    public SubmitForm()
    {
        _configFixture = new PlaywrightFixture();
    }

    [Given(@"the user navigates to the form page")]
    public async Task GivenUserNavigatesToLoginPage()
    {
        await _page.GotoAsync(_configFixture.GetSelector("WebPage", "Url"));
    }

    [When(@"they enter a name, message and submit")]
    public async Task WhenUserEntersValidCredentials()
    {
        await _page.ClickAsync(_configFixture.GetSelector("AutomationPage", "FormPage"));
        await _page.FillAsync(_configFixture.GetSelector("FillOutFormPage", "ContactNameId"), _configFixture.GetSelector("FillOutFormPage", "NameField"));
        await _page.FillAsync(_configFixture.GetSelector("FillOutFormPage", "ContactMessageId"), _configFixture.GetSelector("FillOutFormPage", "MessageField"));
        await _page.ClickAsync(_configFixture.GetSelector("FillOutFormPage", "SubmitButton"));
    }

    [Then(@"the from is processed with a thank you message")]
    public async Task ThenUserIsRedirectedToDashboard()
    {
        string confirmationText = await _page.InnerTextAsync("p:has-text('Thanks for contacting us')");
        Assert.That(confirmationText, Is.EqualTo("Thanks for contacting us"));

    }
}
