using Reqnroll;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _scenarioContext;
    private UserInterfaceFixture _fixture;

    public Hooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario]
    public async Task BeforeScenario()
    {
        _fixture = new UserInterfaceFixture();
        await _fixture.InitializeAsync();
        _scenarioContext.Set(_fixture);
    }

    [AfterScenario]
    public async Task AfterScenario()
    {
        var fixture = _scenarioContext.Get<UserInterfaceFixture>();
        await fixture.TeardownAsync();
    }
}
