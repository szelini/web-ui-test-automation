using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.TestAutomation.Core.Configuration;

namespace WebUI.TestAutomation.Core.DriverFactory
{    
    public class ChromeDriverFactory : BaseDriverFactory
    {
        public override IWebDriver CreateDriver(Options options)
        {
            var chromeOptions = new ChromeOptions();

            if (options.RunHeadlessMode)
            {
                chromeOptions.AddArgument("--headless=new");
            }

            if (!string.IsNullOrEmpty(options.DownloadDirectory))
            {
                chromeOptions.AddUserProfilePreference("download.default_directory", options.DownloadDirectory);

            }

            return new ChromeDriver(chromeOptions);
        }

    }
}
