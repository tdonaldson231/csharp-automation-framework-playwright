using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class PlaywrightFixture
{
    private readonly JObject _config;

    public PlaywrightFixture()
    {
        var projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        var configPath = Path.Combine(projectRoot, "Config", "UserInterface", "locators.json");
        var configContent = File.ReadAllText(configPath);
        _config = JsonConvert.DeserializeObject<JObject>(configContent);
    }

    public string GetSelector(string page, string element)
    {
        return _config[page]?[element]?.ToString() ?? throw new KeyNotFoundException($"Selector for {page}.{element} not found.");
    }
}
