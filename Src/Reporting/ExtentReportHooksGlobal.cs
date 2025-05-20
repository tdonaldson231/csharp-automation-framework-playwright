[SetUpFixture]
public class ExtentReportHooksGlobal
{
    public static ExtentReportsFixture Fixture { get; private set; }

    [OneTimeSetUp]
    public void GlobalSetup()
    {
        Fixture = new ExtentReportsFixture();
        Console.WriteLine("ExtentReports initialized.");
    }

    [OneTimeTearDown]
    public void GlobalTeardown()
    {
        Fixture.Dispose();
        Console.WriteLine("ExtentReports flushed.");
    }
}
