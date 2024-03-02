using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.TestAutomation.Pages
{
    public class SearchResultsPage : BasePage
    {
        private IWebElement resultListDiv => wait.Until(driver => driver.FindElement(By.ClassName("search-results__items")));

        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public List<string> GetLinkTextsFromResults()
        {
            return resultListDiv.FindElements(By.TagName("a")).Select(t => t.Text).ToList();
        }
       
    }
}
