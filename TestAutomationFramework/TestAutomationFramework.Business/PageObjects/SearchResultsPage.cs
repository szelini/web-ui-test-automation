using OpenQA.Selenium;

namespace TestAutomationFramework.Business.PageObjects
{
    public class SearchResultsPage : BasePage
    {
        private By resultListDivLocator => By.ClassName("search-results__items");

        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public List<string> GetTextFromResults()
        {
            IWebElement resultListDiv = wait.Until(driver => driver.FindElement(resultListDivLocator));
            return resultListDiv.FindElements(By.XPath("//*[@class='search-results__title-link' or @class='search-results__description']")).Select(t => t.Text).ToList();
        }
    }
}
