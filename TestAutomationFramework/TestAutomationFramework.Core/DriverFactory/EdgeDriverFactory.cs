using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using TestAutomationFramework.Core.Configuration;

namespace TestAutomationFramework.Core.DriverFactory
{
    public class EdgeDriverFactory : BaseDriverFactory
    {
        public override IWebDriver CreateDriver(BrowserConfigModel model)
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
