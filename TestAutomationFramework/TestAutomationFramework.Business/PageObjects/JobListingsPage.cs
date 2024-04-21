using OpenQA.Selenium;

namespace TestAutomationFramework.Business.PageObjects
{
    public class JobListingsPage : BasePage
    {
        private IWebElement lastResultItem => wait.Until(driver => driver.FindElement(By.CssSelector(".search-result__item:last-child")));

        private IWebElement viewAndApply => lastResultItem.FindElement(By.ClassName("search-result__item-apply-23"));
        public JobListingsPage(IWebDriver driver) : base(driver)
        {

        }

        public JobDetailPage ClickViewAndApplyButton()
        {
            viewAndApply.Click();
            return new JobDetailPage(driver);
        }
    }
}
