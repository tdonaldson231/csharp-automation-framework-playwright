using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Reflection;
using System.IO;
using AventStack.ExtentReports.Reporter.Config;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using RazorEngine;

public class ExtentReportsFixture : IDisposable
{
    private static string dateTime = DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss");
    public ExtentReports Extent { get; private set; }

    public ExtentReportsFixture(TestConfigFixture config)
    {
        string reportPath = Path.Combine(config.ProjectPath, $"Reports/ExtentReport_{dateTime}.html");
        string configPath = Path.Combine(config.ProjectPath, "Extent-Config.xml");

        Console.WriteLine($"Loading Extent Config from: {configPath}");

        var htmlReporter = new ExtentSparkReporter(reportPath);

        htmlReporter.Config.Theme = Theme.Standard;
        htmlReporter.Config.DocumentTitle = "Test Automation Report";
        htmlReporter.Config.ReportName = "Extent Report - Automated Tests";
        htmlReporter.Config.Encoding = "UTF8";

        Extent = new ExtentReports();
        Extent.AttachReporter(htmlReporter);
    }

    public void Dispose()
    
    {
        Extent.Flush();
    }
}
