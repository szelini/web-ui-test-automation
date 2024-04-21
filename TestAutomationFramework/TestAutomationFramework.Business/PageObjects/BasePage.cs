using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace TestAutomationFramework.Business.PageObjects
{
    public abstract class BasePage
    {
        public string PageUrl { get; protected set; }

        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2))
            {
                PollingInterval = TimeSpan.FromSeconds(0.25),
                Message = "Element has not been found"
            };
        }

    }
}
