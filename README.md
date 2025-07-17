**Mars Automation using Reqnroll**
A .NET-based test automation framework using Reqnroll (Specflow for .NET), Selenium WebDriver, and NUnit. This framework
is designed to test web applications with a clean, maintainable structure.

**Overview**
This framework provides automated functional testing for web applications with the following features:


Reqnroll: Implements Cucumber's Gherkin syntax for readable tests

Selenium WebDriver: Handles browser interactions

NUnit: Manages test execution and assertions

ExtentReports: Generates HTML test reports

Page Object Model (POM): Separates test logic from page interactions

**Prerequisites**


.NET SDK: Version 8.0 or higher (install from dotnet.microsoft.com)

IDE: Visual Studio Code or Visual Studio (recommended)

Chrome Browser: Required for Selenium WebDriver (ChromeDriver version must match your browser version via
WebDriverManager)


**Project Structure**
├── Features/           # Gherkin feature files
├── Steps/              # C# step implementations
├── Pages/              # Page Object Model classes
├── Hooks/              # Setup and teardown logic
├── Config/             # Configuration classes
├── Tests/              # NUnit test runner
└── settings.json       # Configuration file

**Getting Started**

**Installation**


Clone the repository:
git clone <repository-url>
cd ReqnrollMarsAutomationProject


Restore dependencies:
dotnet restore



**Configuration**

Configure settings.json in the project root:
{
  "Browser": {
    "Type": "Chrome",
    "Headless": false,
    "TimeoutSeconds": 30
  },
  "Report": {
    "Path": "TestReport.html",
    "Title": "Test Automation Report"
  },
  "Environment": {
    "BaseUrl": "http://localhost:5003" 
  }
}
Note: Update BaseUrl to match your test environment.




**View results:**

Open TestReport.html in your browser to see the test report

.NET SDK: Version 8.0 or higher (install from dotnet.microsoft.com)

IDE: Visual Studio Code or Visual Studio (recommended)

Chrome Browser: Required for Selenium WebDriver (ChromeDriver version must match your browser version via
WebDriverManager)

