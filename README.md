# csharp-automation-framework-playwright

## 🚀 Overview
This repository was created to get more familiar with `Playwright` in combintaion with BDD using `Reqnroll` and showcases a basic test automation framework in `C#` and `NUnit`:

- **.NET 8** for the core framework
- **Playwright** for UI automation

### In Progress
- **RestSharp** for API testing
- **Extent Reports** for generating HTML reports
- **MySQL** for executing SQL test cases

---

## 📂 Current Project Structure
```bash
├───AutomationFrameworkRepo_v03.csproj
├───AutomationFrameworkRepo_v03.sln
├───Config
│   └───Portal
├───Features
├───Src
│   ├───Fixtures
│   └───Lib
└───Tests

```

---

## ⚙️ Configuration
- **`Config/`**: Houses configuration files for MySQL, Selenium locators, and docker setup.

---

## 📁 Source Code Overview
### `Base`
- Initializes the environment and Playwright setup.

### `Fixtures`
- Manages test environment setup and teardown for configuration.

### `Tests`
- NUnit tests, categorized into API, UI, and SQL.

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
3. If both are unset, defaults to `local`.

### Using Visual Studio 2022
1. Open `AutomationFrameworkRepo_v03.sln`
2. Build the solution via `Build > Build Solution`
3. Run all tests via `Tests > Run All Tests`

### Using Command Line (dotnet CLI)
Run all tests with default environment:
```bash
$ dotnet test --filter "TestCategory=Smoke"
```

### Sample Result Output
```bash
$ dotnet test --filter "TestCategory=Smoke"
Restore complete (0.9s)
  AutomationFrameworkRepo_v03 succeeded (1.3s) → bin\Debug\net8.0\AutomationFrameworkRepo_v03.dll
NUnit Adapter 5.0.0.0: Test execution started

Given the user navigates to the form page
-> done: SubmitForm.GivenUserNavigatesToLoginPage() (0.9s)
When they enter a name, message and submit
-> done: SubmitForm.WhenUserEntersValidCredentials() (1.4s)
Then the from is processed with a thank you message
-> done: SubmitForm.ThenUserIsRedirectedToDashboard() (2.0s)

NUnit Adapter 5.0.0.0: Test execution complete
  AutomationFrameworkRepo_v03 test succeeded (8.7s)

Test summary: total: 1, failed: 0, succeeded: 1, skipped: 0, duration: 8.7s
Build succeeded in 11.5s
```

---

## 📄 Additional Notes
 **Locators**: Defined in `Config/UserInterface/locators.json` for UI tests.

---

## 🛠 Troubleshooting
- **Environment Variable Issues**: Verify `testEnvironment` is correctly set for dynamic environment selection.

---