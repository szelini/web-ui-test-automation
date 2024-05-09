
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V119.Debugger;
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
            configuration = new BrowserConfiguration();

            configuration.Model.AppUrl = TestContext.Parameters["appUrl"];
            configuration.Model.RunHeadlessMode = bool.Parse(TestContext.Parameters["runHeadlessMode"]);
            configuration.Model.Browser = TestContext.Parameters["browser"]; 
            configuration.Model.DownloadDirectory = TestContext.Parameters["downloadDirectory"];
            configuration.Model.ScreenshotDirectory = TestContext.Parameters["screenshotDirectory"];
            configuration.Model.LogDirectory = TestContext.Parameters["logDirectory"];
            configuration.Model.LogLevel = TestContext.Parameters["logLevel"];

            Logger.InitLogger(Path.Combine(Directory.GetCurrentDirectory(), configuration.Model.LogDirectory), configuration.Model.LogLevel);
        }

        [SetUp]
        public void Setup()
        {
            Logger.Info($"{TestContext.CurrentContext.Test.Name} started");

            var driverType = (DriverType)Enum.Parse(typeof(DriverType), configuration.Model.Browser, true);
            driver = DriverFactory.GetDriverInstance(driverType, configuration.Model);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Logger.Error($"{TestContext.CurrentContext.Test.Name} failed");
                var screenshotDir = Path.Combine(Directory.GetCurrentDirectory(), configuration.Model.ScreenshotDirectory, TestContext.CurrentContext.Test.MethodName, DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString());
                FolderMaintainer.DirectoryCreator(screenshotDir);
                string fileName = $"{TestContext.CurrentContext.Test.MethodName}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss.fffff}.png";
                ScreenShotTaker.TakeScreenShot(driver, fileName, screenshotDir);
                TestContext.AddTestAttachment(Path.Combine(Path.GetFullPath(screenshotDir), fileName));
            }
            
            Logger.Info($"{TestContext.CurrentContext.Test.Name} finished");
            driver.Quit();
        }
    }
}
