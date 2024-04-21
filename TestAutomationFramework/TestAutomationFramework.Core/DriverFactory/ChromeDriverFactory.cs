using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TestAutomationFramework.Core.Configuration;

namespace TestAutomationFramework.Core.DriverFactory
{    
    public class ChromeDriverFactory : BaseDriverFactory
    {
        public override IWebDriver CreateDriver(BrowserConfigModel model)
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
