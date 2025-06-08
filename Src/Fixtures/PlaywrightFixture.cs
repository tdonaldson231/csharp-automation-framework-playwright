using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class PlaywrightFixture
{
    private readonly JObject _config;

    public PlaywrightFixture(TestConfigFixture config)
    {
        var configPath = Path.Combine(config.ProjectPath, "Config", config.SuiteType, "locators.json");

        if (!File.Exists(configPath))
            throw new FileNotFoundException($"Locator config file not found at {configPath}");

        var configContent = File.ReadAllText(configPath);

        _config = JsonConvert.DeserializeObject<JObject>(configContent)
            ?? throw new InvalidOperationException("Failed to parse locators.json.");
    }

    public string GetSelector(string page, string element)
    {
        return _config[page]?[element]?.ToString() ?? throw new KeyNotFoundException($"Selector for {page}.{element} not found.");
    }
}
