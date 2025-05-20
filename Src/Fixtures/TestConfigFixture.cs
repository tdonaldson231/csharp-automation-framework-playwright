public class TestConfigFixture
{
    public string testEnvironment { get; }

    public TestConfigFixture()
    {
        testEnvironment = Environment.GetEnvironmentVariable("testEnvironment");
    }
}