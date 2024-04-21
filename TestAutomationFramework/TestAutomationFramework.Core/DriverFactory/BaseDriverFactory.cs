using OpenQA.Selenium;
using TestAutomationFramework.Core.Configuration;

namespace TestAutomationFramework.Core.DriverFactory
{
    public abstract class BaseDriverFactory
    {
        public abstract IWebDriver CreateDriver(BrowserConfigModel model);
    }
}
