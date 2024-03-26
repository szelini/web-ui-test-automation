using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.TestAutomation.Core.Configuration;
using WebUI.TestAutomation.Core.DriverFactory;

namespace WebUI.TestAutomation.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var browser = (Drivers)Enum.Parse(typeof(Drivers), Configuration.Model.Browser);
            driver = DriverProvider.GetDriverFactory(browser).CreateDriver(Configuration.Model.Options);
            driver.Manage().Window.Maximize();
        }


        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                var screenshotDir = Configuration.Model.ScreenshotDirectory;
                if (!Directory.Exists(screenshotDir))
                {
                    Directory.CreateDirectory(screenshotDir);
                }
                screenshot.SaveAsFile(Path.Combine(Path.GetFullPath(screenshotDir), $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss.fffff}.png"));
            }
            driver.Quit();

        }
    }
}
