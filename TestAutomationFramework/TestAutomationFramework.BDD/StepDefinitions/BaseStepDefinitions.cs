﻿using NUnit.Framework.Interfaces;
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
            configuration = new BrowserConfiguration("config.json");
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
