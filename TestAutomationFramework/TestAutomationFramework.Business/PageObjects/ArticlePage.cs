using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestAutomationFramework.Business.PageObjects
{
    public class ArticlePage : BasePage
    {
        private By articleNameLocator => By.XPath("//*[@id=\"main\"]/div[1]/div[2]/section/div[3]/div[3]/div/div[1]/div/div/div/p/span/span");
        public ArticlePage(IWebDriver driver) : base(driver)
        {
        }
        public string GetArticleNameFromHeader()
        {
            IWebElement articleName = wait.Until(driver => driver.FindElement(articleNameLocator));
            return articleName.Text.Trim();
        }
    }
}