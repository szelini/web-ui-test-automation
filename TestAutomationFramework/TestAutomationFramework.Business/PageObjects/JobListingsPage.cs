using OpenQA.Selenium;

namespace TestAutomationFramework.Business.PageObjects
{
    public class JobListingsPage : BasePage
    {
        private By lastResultItemLocator => By.CssSelector(".search-result__item:last-child");

        private By viewAndApplyLocator => By.ClassName("search-result__item-apply-23");
        public JobListingsPage(IWebDriver driver) : base(driver)
        {

        }

        public JobDetailPage ClickViewAndApplyButton()
        {
            IWebElement lastResultItem = wait.Until(driver => driver.FindElement(lastResultItemLocator));
            IWebElement viewAndApply = wait.Until(driver => lastResultItem.FindElement(viewAndApplyLocator));

            viewAndApply.Click();
            return new JobDetailPage(driver);
        }
    }
}
