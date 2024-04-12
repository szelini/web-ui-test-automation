using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationFramework.Core.Configuration;
using OpenQA.Selenium.Interactions;

namespace TestAutomationFramework.Core.DriverFactory
{    
    public class ChromeDriverFactory : BaseDriverFactory
    {
        public override IWebDriver CreateDriver(ConfigModel model)
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

    }
}
