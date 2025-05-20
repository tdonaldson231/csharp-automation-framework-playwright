# csharp-automation-framework-playwright

## 🚀 Overview
This repository was created to get more familiar with `Playwright` in combintaion with BDD using `Reqnroll` and showcases a basic test automation framework in `C#` and `NUnit`:

- **.NET 8** for the core framework
- **RestSharp** for API testing
- **Playwright** for UI automation
- **Extent Reports** for generating HTML reports
- **MySQL** for executing SQL test cases

### Key Highlights
- **5 Test Cases**: 2 API, 1 UI, and 2 SQL tests.
- **SQL Initialization**: Spins up a MySQL DB with mock data and stored procedures for SQL testing.

---

## 📂 Project Structure
```bash
|-- AutomationFrameworkRepo_v03.csproj
|-- AutomationFrameworkRepo_v03.sln
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
|-- Extent-Config.xml
|-- README.md
|-- Reports
|   `-- Extent_Reports_Example.html
|-- Src
|   |-- Fixtures
|   |   |-- DatabaseFixture.cs
|   |   |-- ExtentReportsFixture.cs
|   |   |-- TestConfigFixture.cs
|   |   `-- WebDriverFixture.cs
|   |-- Helpers
|   |   `-- DockerComposeHelper.cs
|   |-- Lib
|   |   |-- Base.cs
|   |   `-- ExtentReportCollection.cs
|   |-- PageObjects
|   |   |-- AboutPage.cs
|   |   `-- HomePage.cs
|   `-- Utilities
|       `-- LocatorReader.cs
`-- Tests
    |-- Portal.cs
    |-- RestApi.cs
    |-- RunSettings
    |   |-- dev.runsettings
    |   `-- test.runsettings
    `-- Sql.cs
```

---

## ⚙️ Configuration
- **`Config/`**: Houses configuration files for MySQL, Selenium locators, and docker setup.
- **`Extent-Config.xml`**: Extent report customization.

---

## 📁 Source Code Overview
### `Base`
- Initializes the environment and Selenium WebDriver setup.

### `Fixtures`
- Manages test environment setup and teardown for database, reports, and configuration.

### `Helpers`
- Contains utility functions like Docker management with `DockerComposeHelper.cs`.

### `Reports`
- Auto-generates HTML reports using Extent Reports, saved in the `Reports` directory.

### `Tests`
- xUnit tests, categorized into API, UI, and SQL.

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
cd AutomationFrameworkRepo_v02
```

---

## ▶️ Test Execution

### Environment Selection Precedence
1. Environment variable `testEnvironment` (highest priority)
2. Static value in the `Base` class (default: "dev")
3. If both are unset, defaults to `local`.

### Using Visual Studio 2022
1. Open `AutomationFrameworkRepo_v03.sln`
2. Build the solution via `Build > Build Solution`
3. Run all tests via `Tests > Run All Tests`

### Using Command Line (dotnet CLI)
Run just `Smoke` tests with default environment:
```bash
$ dotnet test --filter "TestCategory=smoke"
```

### Sample Result Output
```bash
$ dotnet test --filter "TestCategory=smoke"
Restore complete (0.9s)
  AutomationFrameworkRepo_v03 succeeded (1.5s) → bin\Debug\net8.0\AutomationFrameworkRepo_v03.dll
NUnit Adapter 5.0.0.0: Test execution started
Running selected tests in C:\Users\toddd\source\repos\csharp-automation-framework-playwright\bin\Debug\net8.0\AutomationFrameworkRepo_v03.dll
   NUnit3TestExecutor discovered 3 of 3 NUnit test cases using Current Discovery mode, Non-Explicit run
Given the backend is up and operational
-> done: BackendRestApi.GivenTheBackendIsUpAndOperational() (1.8s)
Given the API endpoint is "/objects/5"
-> done: BackendRestApi.GivenTheApiEndpointIs("/objects/5") (0.0s)
When a GET request is sent to the backend API
Full request URL: https://api.restful-api.dev/objects/5
-> done: BackendRestApi.WhenAGETRequestIsSentToTheBackendAPI() (0.3s)
Then the response status code should be "OK"
PASS: Expected status 'OK' matched actual 'OK'.
-> done: BackendRestApi.ThenTheResponseStatusCodeShouldBe("OK") (0.0s)

Given the database is up and running
-> done: SqlQueries.GivenTheDatabaseIsUpAndRunning() (0.1s)
When the "GetHighScores" stored procedure is executed with minimum score 70
-> done: SqlQueries.WhenStoredProcedureIsExecuted("GetHighScores", 70) (0.1s)
Then the results should all have scores >= 70
-> done: SqlQueries.ThenScoresShouldBeGreaterThanOrEqualTo(70) (0.0s)

Given the user navigates to the form page
-> done: PortalTests.GivenUserNavigatesToTheFormPage() (1.4s)
When the user enters a name, message and clicks the submit button
-> done: PortalTests.WhenUserEntersNameMessageAndClicksSubmit() (1.6s)
Then the form is processed with a thank you message
-> done: PortalTests.ThenFormIsProcessedWithThankYouMessage() (2.1s)

NUnit Adapter 5.0.0.0: Test execution complete
  AutomationFrameworkRepo_v03 test succeeded (61.3s)

Test summary: total: 3, failed: 0, succeeded: 3, skipped: 0, duration: 61.3s
Build succeeded in 64.5s
```

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