using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace AutomationFramework.Features.Sql
{
    public class DockerComposeHelper : IAsyncDisposable
    {
        private readonly TestConfigFixture _config;
        private readonly string _dockerComposeDirectory;

        public DockerComposeHelper(TestConfigFixture config)
        {
            _config = config;
            _dockerComposeDirectory = Path.Combine(config.ProjectPath);
            if (string.Equals(_config.DbServer, "localhost", StringComparison.OrdinalIgnoreCase))
            try
            {
                StartDockerCompose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Docker Compose startup failed: {ex.Message}");
            }
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

            Console.WriteLine(output);
        }

        public async ValueTask DisposeAsync()
        {
            if (string.Equals(_config.DbServer, "localhost", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    StopDockerCompose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Docker Compose cleanup failed: {ex.Message}");
                }
            }
            
            await Task.CompletedTask;
        }
    }
}