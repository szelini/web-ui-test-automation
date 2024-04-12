using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationFramework.Business.PageObjects
{
    public class SearchResultsPage : BasePage
    {
        private IWebElement resultListDiv => wait.Until(driver => driver.FindElement(By.ClassName("search-results__items")));

        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public List<string> GetTextFromResults()
        {
            return resultListDiv.FindElements(By.XPath("//*[@class='search-results__title-link' or @class='search-results__description']")).Select(t => t.Text).ToList();
        }

    }
}
