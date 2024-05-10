using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using TestAutomationFramework.Core.Configuration;
using TestAutomationFramework.Core.DriverFactory;
using TestAutomationFramework.Core.Utilities;

namespace TestAutomationFramework.BDD.StepDefinitions
{
    [Binding]
    public class BaseStepDefinitions
    {
        protected static IWebDriver driver;
        protected static BrowserConfiguration configuration;

        [BeforeFeature()]
        public static void OneTimeSetUp()
        {
            configuration = new BrowserConfiguration();

            configuration.Model.AppUrl = TestContext.Parameters["appUrl"];
            configuration.Model.RunHeadlessMode = bool.Parse(TestContext.Parameters["runHeadlessMode"]);
            configuration.Model.Browser = TestContext.Parameters["browser"];
            configuration.Model.DownloadDirectory = TestContext.Parameters["downloadDirectory"];
            configuration.Model.ScreenshotDirectory = TestContext.Parameters["screenshotDirectory"];
            configuration.Model.LogDirectory = TestContext.Parameters["logDirectory"];
            configuration.Model.LogLevel = TestContext.Parameters["logLevel"];

            Logger.InitLogger(configuration.Model.LogDirectory, "log_bddtests.txt", configuration.Model.LogLevel);
        }

        [BeforeScenario()]
        public static void Setup()
        {
            Logger.Info($"Browser: {configuration.Model.Browser} {TestContext.CurrentContext.Test.Name} started");

            var driverType = (DriverType)Enum.Parse(typeof(DriverType), configuration.Model.Browser, true);
            driver = DriverFactory.GetDriverInstance(driverType, configuration.Model);
            driver.Manage().Window.Maximize();
        }

        [AfterScenario()]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Logger.Error($"Browser: {configuration.Model.Browser} {TestContext.CurrentContext.Test.Name} failed");
                var screenshotDir = Path.Combine(configuration.Model.ScreenshotDirectory, TestContext.CurrentContext.Test.Name,  DateTime.Now.ToShortDateString());
                FolderMaintainer.DirectoryCreator(screenshotDir);
                ScreenShotTaker.TakeScreenShot(driver, TestContext.CurrentContext.Test.MethodName, screenshotDir);
            }

            Logger.Info($"Browser: {configuration.Model.Browser} {TestContext.CurrentContext.Test.Name} finished");
            driver.Quit();
        }
    }
}
