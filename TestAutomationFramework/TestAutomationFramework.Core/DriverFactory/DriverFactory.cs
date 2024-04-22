using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationFramework.Core.Configuration;

namespace TestAutomationFramework.Core.DriverFactory
{
    public class DriverFactory
    {
        public static IWebDriver GetDriverInstance(DriverType driverType, BrowserConfigModel model)
        {
            switch (driverType)
            {
                case DriverType.Chrome:
                    return CreateChromeDriver(model);
                case DriverType.Edge:
                    return CreateEdgeDriver(model);
                default:
                    throw new ArgumentOutOfRangeException(nameof(driverType));
            }
        }

        public static IWebDriver CreateChromeDriver(BrowserConfigModel model)
        {
            var chromeOptions = new ChromeOptions();

            if (model.RunHeadlessMode)
            {
                chromeOptions.AddArgument("--headless=new");
            }

            if (!string.IsNullOrEmpty(model.DownloadDirectory))
            {
                chromeOptions.AddUserProfilePreference("download.default_directory", model.DownloadDirectory);
                chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            }

            return new ChromeDriver(chromeOptions);
        }

        public static IWebDriver CreateEdgeDriver(BrowserConfigModel model)
        {
            var edgeOptions = new EdgeOptions();

            if (model.RunHeadlessMode)
            {
                edgeOptions.AddArgument("--headless");
            }

            if (!string.IsNullOrEmpty(model.DownloadDirectory))
            {
                edgeOptions.AddUserProfilePreference("download.default_directory", model.DownloadDirectory);
                edgeOptions.AddUserProfilePreference("download.prompt_for_download", model.DownloadDirectory);

            }

            return new EdgeDriver(edgeOptions);
        }

    }
}
