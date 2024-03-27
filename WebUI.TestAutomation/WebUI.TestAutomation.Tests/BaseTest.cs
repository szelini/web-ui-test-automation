
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WebUI.TestAutomation.Core.Configuration;
using WebUI.TestAutomation.Core.DriverFactory;
using WebUI.TestAutomation.Core.Utilities;

namespace WebUI.TestAutomation.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        protected Configuration configuration;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            configuration = new Configuration("config.json"); 
            Logger.InitLogger(configuration.Model.LogDirectory, configuration.Model.LogLevel);
        }

        [SetUp]
        public void Setup()
        {
            Logger.Info($"{TestContext.CurrentContext.Test.Name} started");

            var browser = (Drivers)Enum.Parse(typeof(Drivers), configuration.Model.Browser);

            driver = DriverProvider.GetDriverFactory(browser).CreateDriver(configuration.Model);
            driver.Manage().Window.Maximize();
        }


        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Logger.Error($"{TestContext.CurrentContext.Test.Name} failed");
                ScreenShotTaker.TakeScreenShot(driver, TestContext.CurrentContext.Test.MethodName, configuration.Model.ScreenshotDirectory);
            }

            Logger.Info($"{TestContext.CurrentContext.Test.Name} finished");
            driver.Quit();

        }
    }
}
