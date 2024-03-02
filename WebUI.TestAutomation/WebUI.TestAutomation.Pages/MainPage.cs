using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WebUI.TestAutomation.Pages
{
    public class MainPage : BasePage
    {

        private IWebElement careersLink => driver.FindElement(By.LinkText("Careers"));

        private IWebElement searchIcon => driver.FindElement(By.ClassName("search-icon"));
        private IWebElement searchInput => wait.Until(driver => driver.FindElement(By.Name("q")));
        private IWebElement findButton => driver.FindElement(By.ClassName("custom-search-button"));

        private IWebElement aboutLink => driver.FindElement(By.LinkText("About"));

        public MainPage(IWebDriver driver) : base(driver)
        {
            PageUrl = TestContext.Parameters["appUrl"];
        }
        

        public MainPage Open()
        {
            driver.Navigate().GoToUrl(PageUrl);
            return this;
        }

        public CareersPage ClickCareers()
        {
            careersLink.Click();
            return new CareersPage(driver);
        }

        public SearchResultsPage PerformSearch(string phrase)
        {
            searchIcon.Click();

            var clickAndSendKeysActions = new Actions(driver);

            clickAndSendKeysActions.Click(searchInput)
                .Pause(TimeSpan.FromSeconds(1))
                .SendKeys(phrase)
                .Perform();

            findButton.Click();

            return new SearchResultsPage(driver);
        }

        public AboutPage ClickAbout()
        {
            aboutLink.Click();
            return new AboutPage(driver);
        }


    }
}
