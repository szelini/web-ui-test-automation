
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using TestAutomationFramework.Core.Configuration;
using TestAutomationFramework.Core.DriverFactory;
using TestAutomationFramework.Core.Utilities;

namespace TestAutomationFramework.Tests
{
    public class WebUIBaseTest
    {
        protected IWebDriver driver;

        protected BrowserConfiguration configuration;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            configuration = new BrowserConfiguration("webuitest_config.json");
            Logger.InitLogger(configuration.Model.LogDirectory, configuration.Model.LogLevel);
        }

        [SetUp]
        public void Setup()
        {
            Logger.Info($"{TestContext.CurrentContext.Test.Name} started");

            var driverType = (DriverType)Enum.Parse(typeof(DriverType), configuration.Model.Browser);
            driver = DriverFactory.GetDriverInstance(driverType, configuration.Model);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Logger.Error($"{TestContext.CurrentContext.Test.Name} failed");
                var screenshotDir = Path.Combine(configuration.Model.ScreenshotDirectory, TestContext.CurrentContext.Test.MethodName, DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString());
                FolderMaintainer.DirectoryCreator(screenshotDir);
                ScreenShotTaker.TakeScreenShot(driver, TestContext.CurrentContext.Test.MethodName, screenshotDir);
            }
            
            Logger.Info($"{TestContext.CurrentContext.Test.Name} finished");
            driver.Quit();
        }
    }
}
