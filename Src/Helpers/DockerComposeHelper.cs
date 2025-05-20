using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

public class DockerComposeHelper : IAsyncDisposable
{
    private readonly string projectPath;
    private readonly string _dockerComposeDirectory;

    public DockerComposeHelper()
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        projectPath = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
        _dockerComposeDirectory = Path.Combine(projectPath, "Config", "Sql");

        // debugging: Output the computed paths
        Console.WriteLine($"Base Directory: {baseDirectory}");
        Console.WriteLine($"Project Path: {projectPath}");
        Console.WriteLine($"Docker Compose Directory: {_dockerComposeDirectory}");

        StartDockerCompose();
    }

    private void StartDockerCompose()
    {
        RunCommand("docker-compose", "up -d");
    }

    private void StopDockerCompose()
    {
        RunCommand("docker-compose", "down -v");
    }

    private void RunCommand(string command, string args)
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = args,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = _dockerComposeDirectory, // Now correctly assigned
            }
        };

        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();
        process.WaitForExit();

        if (process.ExitCode != 0)
        {
            throw new Exception($"Command `{command} {args}` failed with error: {error}");
        }

        Console.WriteLine(output);  // Output result for debugging
    }

    public async ValueTask DisposeAsync()
    {
        StopDockerCompose();
        await Task.CompletedTask;
    }
}
