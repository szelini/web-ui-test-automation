using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.TestAutomation.Core.Configuration;
using WebUI.TestAutomation.Core.DriverFactory;
using WebUI.TestAutomation.Core.Utilities;

namespace WebUI.TestAutomation.BDD.StepDefinitions
{
    [Binding]
    public class BaseStepDefinitions
    {
        protected static IWebDriver driver;
        protected static Configuration configuration;

        [BeforeFeature()]
        public static void OneTimeSetUp()
        {
            configuration = new Configuration("config.json");
            Logger.InitLogger(configuration.Model.LogDirectory, configuration.Model.LogLevel);
        }

        [BeforeScenario()]
        public static void Setup()
        {
            Logger.Info($"{TestContext.CurrentContext.Test.Name} started");

            var browser = (Drivers)Enum.Parse(typeof(Drivers), configuration.Model.Browser);

            driver = DriverProvider.GetDriverFactory(browser).CreateDriver(configuration.Model);
            driver.Manage().Window.Maximize();
        }


        [AfterScenario()]
        public static void TearDown()
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
