using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace WebUI.TestAutomation.Business.PageObjects
{
    public class ArticlePage : BasePage
    {
        private IWebElement articleName => wait.Until(driver => driver.FindElement(By.XPath("//div[@class=\"header_and_download\"]//span")));

        public ArticlePage(IWebDriver driver) : base(driver)
        {
        }

        public string GetArticleNameFromHeader()
        {
            return articleName.Text;
        }
    }
}