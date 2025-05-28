# csharp-automation-framework-playwright

## 🚀 Overview
This repository demonstrates a basic test automation framework in `C#` using `Playwright` for UI automation and `Reqnroll` for BDD. It integrates `NUnit` as the test runner and incorporates the following key components:

- .NET 8 for the core framework
- RestSharp for API testing
- Playwright for UI automation
- Extent Reports for HTML reporting
- MySQL for executing SQL test cases

### Key Feature

- 5 Test Cases: Including 2 API, 1 UI, and 2 SQL-based tests.
- MySQL Initialization: Automated MySQL instance with seeded mock data and stored procedures for SQL validation.
- BDD Integration: Feature files and step definitions using Reqnroll.
- Docker-Based: Uses Docker Compose for setting up the MySQL environment.

---

## 📂 Project Structure
```bash
|-- AutomationFramework.csproj
|-- AutomationFrameworkRepo_v03.sln
|-- Archive
|   |-- AzureDevOps
|   |   `-- pipeline.yaml
|   `-- Dockerfile
|-- AutomationFramework.csproj
|-- AutomationFrameworkRepo_v03.sln
|-- Config
|   |-- Sql
|   |   |-- README.md
|   |   |-- Src
|   |   |   `-- Config
|   |   |       `-- Sql
|   |   |-- docker-compose.yml
|   |   `-- mysql-init
|   |       `-- mock_data.sql
|   `-- UserInterface
|       `-- locators.json
|-- Dockerfile
|-- Features
|   |-- RestApi
|   |   |-- Api.Feature
|   |   `-- Api.Feature.cs
|   |-- Sql
|   |   |-- SqlTests.Feature
|   |   `-- SqlTests.Feature.cs
|   `-- UserInterface
|       |-- Form.Feature
|       `-- Form.Feature.cs
|-- README.md
|-- Reports
|   |-- Extent_Reports_Example.html
|   `-- SreenCaptures
|       `-- Screenshot_2025-05-20_09-29-41.png
|-- Src
|   |-- Base.cs
|   |-- Fixtures
|   |   |-- DatabaseFixture.cs
|   |   |-- ExtentReportsFixture.cs
|   |   |-- PlaywrightFixture.cs
|   |   |-- TestConfigFixture.cs
|   |   `-- UserInterfaceFixture.cs
|   |-- Helpers
|   |   `-- DockerComposeHelper.cs
|   |-- Hooks
|   |   |-- ExtentReportHooks.cs
|   |   |-- Hooks.cs
|   |   `-- UserInterfaceTestHooks.cs
|   `-- Reporting
|       `-- ExtentReportHooksGlobal.cs
|-- Tests
|   |-- Portal.cs
|   |-- RestApi.cs
|   |-- Results
|   |-- RunSettings
|   |   |-- dev.runsettings
|   |   `-- local.runsettings
|   `-- Sql.cs
|-- entrypoint.sh
`-- tests.sh
```

---

## ⚙️ Configuration

- **`Config/`**: contains:
  - SQL Setup: Docker Compose files and mock data (mock_data.sql) for MySQL test cases.
  - UI Locators: JSON file with element selectors used in Playwright tests.
---

## 📄 BDD Feature Files
- **`Features/`**: BDD feature files for `reqnroll` used for RestApi, Sql, and UI test cases.

---

## 📁 Source Code Overview
- **`Base`**: Base file used to initialize the test environment and provides shared configuration values for use across the framework.

- **`Fixtures/`**: Manages test environment setup and teardown for database,user interface, reports, and test configuration.

- **`Helpers/`**: Contains utility functions such as `docker compose up/down` for Docker management.

- **`Reporting/`**: Extent Report classes to assist with reporting setup and initialization for test suite.

- **`Tests/`**: BDD tests, categorized into API, UI, and SQL.

- **`Hooks/`**: Contains `Reqnroll` hook files that define setup and teardown logic for ExtentReports and UserInterface.

---

## 📄 HTML Reports
- **`Reports/`**: 
  - Auto-generated HTML reports using Extent Reports, saved in the `Reports` directory.
  - Screen captures in `SreenCaptures` directory with date/timestamp when an error is detected while running UI tests.

---

## 📁 Test Types

  - API: Use RestSharp to validate public endpoints.
  - UI: Use Playwright with predefined locators.
  - SQL: Validate stored procedures and queries against seeded data.
---

## ✅ Prerequisites
- **Docker Desktop** (Windows) must be installed and running.

---

## 🔄 Installation
1. Clone the repository:
```bash
git clone git@github.com:tdonaldson231/csharp-automation-framework-playwright.git
```
2. Navigate to the project directory:
```bash
cd AutomationFrameworkRepo_v03
```

---

## ▶️ Test Execution

### Environment Selection Precedence
1. Environment variable `testEnvironment` (highest priority)
2. Static value in the `Base` class (default: "dev")

### Using Visual Studio 2022
1. Open `AutomationFrameworkRepo_v03.sln`
2. Build the solution via `Build > Build Solution`
3. Run all tests via `Tests > Run All Tests`

### Using the `tests.sh` script to run `dotnet test`
Example running the `smoke` tests in the `dev` environment:
```bash
$ bash tests.sh -e dev -c api
```

### Sample Result Output
<details>
  <summary>(click to expand)</summary>
    ```bash
    $ bash git .sh -e dev -c api
    Running tests in Environment: dev
    Running tests using category: api
    Restore complete (1.3s)
      AutomationFramework succeeded (3.7s) → bin\Debug\net8.0\AutomationFramework.dll
    NUnit Adapter 5.0.0.0: Test execution started
    Running selected tests in C:\Users\toddd\source\repos\csharp-automation-framework-playwright\bin\Debug\net8.0\AutomationFramework.dll
       NUnit3TestExecutor discovered 2 of 2 NUnit test cases using Current Discovery mode, Non-Explicit run
    Given the backend is up and operational
    Environment: dev
    API URL: https://api.restful-api.dev
    SQL DB: devdb
    Current Working Directory: C:\Users\toddd\source\repos\csharp-automation-framework-playwright\bin\Debug\net8.0
    Project Path: C:\Users\toddd\source\repos\csharp-automation-framework-playwright
    -> done: BackendRestApi.GivenTheBackendIsUpAndOperational() (0.8s)
    Given the API endpoint is "/unknown"
    -> done: BackendRestApi.GivenTheApiEndpointIs("/unknown") (0.0s)
    When a GET request is sent to the backend API
    Full request URL: https://api.restful-api.dev/unknown
    -> done: BackendRestApi.WhenAGETRequestIsSentToTheBackendAPI() (0.4s)
    Then the response status code should be "NotFound"
    PASS: Expected status 'NotFound' matched actual 'NotFound'.
    NotFound
    -> done: BackendRestApi.ThenTheResponseStatusCodeShouldBe("NotFound") (0.0s)

    Given the backend is up and operational
    Environment: dev
    API URL: https://api.restful-api.dev
    SQL DB: devdb
    Current Working Directory: C:\Users\toddd\source\repos\csharp-automation-framework-playwright\bin\Debug\net8.0
    Project Path: C:\Users\toddd\source\repos\csharp-automation-framework-playwright
    -> done: BackendRestApi.GivenTheBackendIsUpAndOperational() (0.8s)
    Given the API endpoint is "/objects/5"
    -> done: BackendRestApi.GivenTheApiEndpointIs("/objects/5") (0.0s)
    When a GET request is sent to the backend API
    Full request URL: https://api.restful-api.dev/objects/5
    -> done: BackendRestApi.WhenAGETRequestIsSentToTheBackendAPI() (0.4s)
    Then the response status code should be "OK"
    PASS: Expected status 'OK' matched actual 'OK'.
    OK
    -> done: BackendRestApi.ThenTheResponseStatusCodeShouldBe("OK") (0.0s)

    NUnit Adapter 5.0.0.0: Test execution complete
    WARNING: Overwriting results file: C:\Users\toddd\source\repos\csharp-automation-framework-playwright\Tests\Results\test_results.trx
    Results File: C:\Users\toddd\source\repos\csharp-automation-framework-playwright\Tests\Results\test_results.trx
      AutomationFramework test succeeded (27.2s)

    Test summary: total: 2, failed: 0, succeeded: 2, skipped: 0, duration: 27.1s
    Build succeeded in 33.2s

    Workload updates are available. Run `dotnet workload list` for more information.
    ```
</details>

### Building & Running Docker Image
1. Navigate to the root directory containing `Dockerfile`
2. Build the docker image: `docker build -t test-image .`
3. Run the docker image: `docker run --rm -e TEST_ENV=api -e TEST_CATEGORY=smoke test-image`

---

## 📄 Additional Notes
- **Extent Reports**: Automatically generated after every test run.
- **Mock Data**: Seeded into MySQL using `mock_data.sql` during test initialization.
- **Locators**: Defined in `Config/UserInterface/locators.json` for UI tests.

---

## 🛠 Troubleshooting
- **Docker Not Running**: Ensure Docker Desktop is running before executing tests.
- **Environment Variable Issues**: Verify `testEnvironment` is correctly set for dynamic environment selection.

---

## ▶️ Azure DevOps 

A test container was built and executed using an Azure DevOps pipeline.  
The pipeline YAML file is archived under the `Archive > Azure DevOps` directory for reference.

To run the pipeline, a self-hosted agent was configured by following the official Microsoft documentation:  
[Set up a self-hosted Windows agent](https://learn.microsoft.com/en-us/azure/devops/pipelines/agents/windows-agent?view=azure-devops&tabs=IP-V4)

The agent was set up and started using PowerShell with the following command:

```powershell
PS C:\agent> .\config.cmd

  ___                      ______ _            _ _
 / _ \                     | ___ (_)          | (_)
/ /_\ \_____   _ _ __ ___  | |_/ /_ _ __   ___| |_ _ __   ___  ___
|  _  |_  / | | | '__/ _ \ |  __/| | '_ \ / _ \ | | '_ \ / _ \/ __|
| | | |/ /| |_| | | |  __/ | |   | | |_) |  __/ | | | | |  __/\__ \
\_| |_/___|\__,_|_|  \___| \_|   |_| .__/ \___|_|_|_| |_|\___||___/
                                   | |
        agent v4.255.0             |_|          (commit 470b366)


>> Connect:

Enter server URL > https://dev.azure.com/toddadonaldson22
Enter authentication type (press enter for PAT) >
Enter personal access token > ************************************************************************************
Connecting to server ...

>> Register Agent:

Enter agent pool (press enter for default) >
Enter agent name (press enter for DONALDSON-WIN10) >
Scanning for tool capabilities.
Connecting to the server.
Successfully added the agent
Testing agent connection.

PS C:\agent> .\run.cmd
Scanning for tool capabilities.
Connecting to the server.
2025-05-21 14:29:30Z: Listening for Jobs
2025-05-21 14:32:15Z: Running job: Build Dockerfile from Public GitHub Repo
```

Results from running the API suite from Azure DevOps:

```bash
AutomationFrameworkRepo_v03 -> /app/bin/Debug/net8.0/AutomationFrameworkRepo_v03.dll
Test run for /app/bin/Debug/net8.0/AutomationFrameworkRepo_v03.dll (.NETCoreApp,Version=v8.0)
VSTest version 17.11.1 (x64)

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.
WARNING: Overwriting results file: /app/TestResults/test_results.trx
Results File: /app/TestResults/test_results.trx

Passed!  - Failed:     0, Passed:     2, Skipped:     0, Total:     2, Duration: 6 s - AutomationFrameworkRepo_v03.dll (net8.0)
Finishing: Run Docker Image with TEST_CATEGORY
```