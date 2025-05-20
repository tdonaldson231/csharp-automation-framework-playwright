using AventStack.ExtentReports;
using Reqnroll;

[Binding]
public class ExtentReportHooks
{
    private readonly ScenarioContext _scenarioContext;
    private readonly FeatureContext _featureContext;
    private ExtentTest _test;
    private readonly List<(string keyword, string text, string status)> _steps = new();

    public ExtentReportHooks(ScenarioContext scenarioContext, FeatureContext featureContext)
    {
        _scenarioContext = scenarioContext;
        _featureContext = featureContext;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        _test = ExtentReportHooksGlobal.Fixture.Extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
        _scenarioContext["ExtentTest"] = _test;
        _test.Info("Starting scenario: " + _scenarioContext.ScenarioInfo.Title);
    }

    [AfterStep]
    public void AfterEachStep()
    {
        var stepInfo = _scenarioContext.StepContext.StepInfo;
        var stepStatus = _scenarioContext.TestError == null ? "Passed" : "Failed";

        var extentTest = (ExtentTest)_scenarioContext["ExtentTest"];
        extentTest.AssignCategory(_scenarioContext.ScenarioInfo.Tags);

        // Given, When, Then
        string keyword = stepInfo.StepDefinitionType.ToString();
        _steps.Add((keyword, stepInfo.Text, stepStatus));

        if (_scenarioContext.TestError != null)
        {
            extentTest.Fail($"{keyword} {stepInfo.Text} failed with error: {_scenarioContext.TestError.Message}");
        }
        else
        {
            extentTest.Pass($"{keyword} {stepInfo.Text} - {stepStatus}");
        }
    }


    [AfterScenario]
    public void AfterScenario()
    {
        var extentTest = (ExtentTest)_scenarioContext["ExtentTest"];
        extentTest.Info("Ending scenario: " + _scenarioContext.ScenarioInfo.Title);

        // Write pseudo-Gherkin file
        var scenarioTitle = _scenarioContext.ScenarioInfo.Title;
        var featureTitle = _featureContext.FeatureInfo.Title;
        var outputPath = Path.Combine("Reports", $"{featureTitle}_{scenarioTitle}.gherkin.txt");

        Directory.CreateDirectory("Reports");
        using (var writer = new StreamWriter(outputPath))
        {
            writer.WriteLine($"Scenario: {scenarioTitle}");
            foreach (var (keyword, text, status) in _steps)
            {
                var statusNote = status == "Passed" ? "" : $" # {status.ToLower()}";
                writer.WriteLine($"  {keyword} {text}{statusNote}");
            }
        }

        _steps.Clear();
    }
}
