using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.TestAutomation.Core.Configuration;

namespace WebUI.TestAutomation.Core.DriverFactory
{
    public class EdgeDriverFactory : BaseDriverFactory
    {
        public override IWebDriver CreateDriver(ConfigModel model)
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
