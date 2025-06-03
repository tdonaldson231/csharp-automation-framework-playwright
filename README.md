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
|-- AzureDevOps
|   `-- pipeline.yaml
|-- Config
|   |-- Sql
|   |   |-- README.md
|   |   |-- Src
|   |   |   `-- Config
|   |   |       `-- Sql
|   |   |           `-- mysql-init
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
|   |-- ExtentReport_2025-06-01_12-47-55.html
|   |-- Extent_Reports_Example.html
|   `-- SreenCaptures
|       `-- Screenshot_2025-05-20_09-29-41.png
|-- Src
|   |-- Base.cs
|   |-- DependencyInjection
|   |   `-- ApiTestingServices.cs
|   |-- Fixtures
|   |   |-- DatabaseFixture.cs
|   |   |-- ExtentReportsFixture.cs
|   |   |-- PlaywrightFixture.cs
|   |   |-- TestConfigFixture.cs
|   |   `-- UserInterfaceFixture.cs
|   |-- Helpers
|   |   |-- DockerComposeHelper.cs
|   |   `-- RestSharpClient.cs
|   |-- Hooks
|   |   |-- ExtentReportHooks.cs
|   |   |-- Hooks.cs
|   |   `-- UserInterfaceTestHooks.cs
|   |-- Interfaces
|   |   `-- IApiClient.cs
|   `-- Reporting
|       `-- ExtentReportGlobal.cs
|-- TestResults
|   `-- test_results.trx
|-- Tests
|   |-- Portal.cs
|   |-- RestApi.cs
|   |-- RunSettings
|   |   |-- dev.runsettings
|   |   `-- local.runsettings
|   `-- Sql.cs
|-- bin
|   `-- Debug
|       `-- net8.0
|-- entrypoint.sh
|-- obj
|   `-- Debug
|       `-- net8.0
|           |-- AutomationFramework.AssemblyInfo.cs
|           |-- AutomationFramework.AssemblyInfoInputs.cache
|           |-- AutomationFramework.GeneratedMSBuildEditorConfig.editorconfig
|           |-- AutomationFramework.GlobalUsings.g.cs
|           |-- ref
|           `-- refint
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

- **`Interfaces/`**: Contains abstract definitions for services and utilities used in tests.
 
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
Example running the `regression` tests in the `dev` environment:
```bash
$ bash tests.sh -e dev -c regression
```

### Sample Result Output
<details>
  <summary>(click to expand)</summary>
    ```bash
    $ bash tests.sh -e dev -c regression
    Running tests in Environment: dev
    Running tests using category: regression
    Restore complete (1.1s)
      AutomationFramework succeeded (12.0s) → bin\Debug\net8.0\AutomationFramework.dll
    NUnit Adapter 5.0.0.0: Test execution started
    Running selected tests in C:\Users\toddd\source\repos\csharp-automation-framework-playwright\bin\Debug\net8.0\AutomationFramework.dll
       NUnit3TestExecutor discovered 5 of 5 NUnit test cases using Current Discovery mode, Non-Explicit run
    Given the backend is up and operational
    Environment: dev
    API URL: https://api.restful-api.dev
    SQL DB: Server=localhost;Port=3306;Database=devdb;User ID=devuser;Password=devpassword;
    Current Working Directory: C:\Users\toddd\source\repos\csharp-automation-framework-playwright\bin\Debug\net8.0
    Project Path: C:\Users\toddd\source\repos\csharp-automation-framework-playwright
    -> done: BackendRestApi.GivenTheBackendIsUpAndOperational() (0.5s)
    Given the API endpoint is "/unknown"
    -> done: BackendRestApi.GivenTheApiEndpointIs("/unknown") (0.0s)
    When a GET request is sent to the backend API
    -> done: BackendRestApi.WhenAGETRequestIsSentToTheBackendAPI() (0.6s)
    Then the response status code should be "NotFound"
    -> done: BackendRestApi.ThenTheResponseStatusCodeShouldBe("NotFound") (0.0s)

    
    Given the backend is up and operational
    Environment: dev
    API URL: https://api.restful-api.dev
    SQL DB: Server=localhost;Port=3306;Database=devdb;User ID=devuser;Password=devpassword;
    Current Working Directory: C:\Users\toddd\source\repos\csharp-automation-framework-playwright\bin\Debug\net8.0
    Project Path: C:\Users\toddd\source\repos\csharp-automation-framework-playwright
    -> done: BackendRestApi.GivenTheBackendIsUpAndOperational() (0.3s)
    Given the API endpoint is "/objects/5"
    -> done: BackendRestApi.GivenTheApiEndpointIs("/objects/5") (0.0s)
    When a GET request is sent to the backend API
    -> done: BackendRestApi.WhenAGETRequestIsSentToTheBackendAPI() (0.6s)
    Then the response status code should be "OK"
    -> done: BackendRestApi.ThenTheResponseStatusCodeShouldBe("OK") (0.0s)

    Given the database is up and running
    -> done: SqlQueries.GivenTheDatabaseIsUpAndRunning() (0.0s)
    When the "GetHighScores" stored procedure is executed with minimum score 70
    -> done: SqlQueries.WhenStoredProcedureIsExecuted("GetHighScores", 70) (0.1s)
    Then the results should all have scores >= 70
    -> done: SqlQueries.ThenScoresShouldBeGreaterThanOrEqualTo(70) (0.0s)

    Given the database is up and running
    -> done: SqlQueries.GivenTheDatabaseIsUpAndRunning() (0.0s)
    When I query the "results" table
    -> done: SqlQueries.WhenIQueryTheTable("results") (0.0s)
    Then I should find user "Ringo" with score >= 75
    -> done: SqlQueries.ThenUserScoreShouldBeAtLeast("Ringo", 75) (0.0s)

    Given the user navigates to the form page
    -> done: PortalTests.GivenUserNavigatesToTheFormPage() (0.9s)
    When the user enters a name, message and clicks the submit button
    -> done: PortalTests.WhenUserEntersNameMessageAndClicksSubmit() (1.1s)
    Then the form is processed with a thank you message
    -> done: PortalTests.ThenFormIsProcessedWithThankYouMessage() (2.0s)

    NUnit Adapter 5.0.0.0: Test execution complete
    WARNING: Overwriting results file: C:\Users\toddd\source\repos\csharp-automation-framework-playwright\TestResults\test_results.trx
    Results File: C:\Users\toddd\source\repos\csharp-automation-framework-playwright\TestResults\test_results.trx
      AutomationFramework test succeeded (57.8s)

    Test summary: total: 5, failed: 0, succeeded: 5, skipped: 0, duration: 57.8s
    Build succeeded in 75.1s
    ```
</details>

### Building & Running Docker Image
1. Navigate to the root directory containing `Dockerfile`
2. Build the docker image: `docker build -t test-image .`
3. Run the docker image: `docker run --network sql_test-network -e TEST_ENV=dev -e TEST_CATEGORY=smoke test-image`\
**Note:** to allocate an interactive terminal (for shell access), execute the following:
```bash
> docker run -it --entrypoint /bin/bash <image-name:image-tag>
```

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

Results from running the API suite from an Azure DevOps pipeline:

```bash
AutomationFrameworkRepo_v03 -> /app/bin/Debug/net8.0/AutomationFrameworkRepo_v03.dll
Test run for /app/bin/Debug/net8.0/AutomationFrameworkRepo_v03.dll (.NETCoreApp,Version=v8.0)
VSTest version 17.11.1 (x64)

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.
WARNING: Overwriting results file: /app/TestResults/test_results.trx
Results File: /app/TestResults/test_results.trx

Passed!  - Failed:     0, Passed:     2, Skipped:     0, Total:     2, Duration: 6 s - AutomationFrameworkRepo_v03.dll (net8.0)
```