using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
