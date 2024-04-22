using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestAutomationFramework.Business.PageObjects
{
    public class MainPage : BasePage
    {

        private By careersLinkLocator => By.LinkText("Careers");
       
        private By searchIconLocator => By.ClassName("search-icon");
        private By searchInputLocator => By.Name("q");
        private By findButtonLocator => By.ClassName("custom-search-button");
        private By aboutLinkLocator => By.LinkText("About");
        private By insightsLinkLocator => By.LinkText("Insights");



        public MainPage(IWebDriver driver, string url) : base(driver)
        {
            PageUrl = url;
        }


        public MainPage Open()
        {
            driver.Navigate().GoToUrl(PageUrl);
            return this;
        }

        public CareersPage NavigateToCareersPage()
        {
            IWebElement careersLink = driver.FindElement(careersLinkLocator);
            careersLink.Click();
            return new CareersPage(driver);
        }

        public SearchResultsPage PerformSearch(string phrase)
        {
            IWebElement searchIcon = driver.FindElement(searchIconLocator);
            searchIcon.Click();

            IWebElement searchInput = driver.FindElement(searchInputLocator);

            var clickAndSendKeysActions = new Actions(driver);

            clickAndSendKeysActions.Click(searchInput)
                .Pause(TimeSpan.FromSeconds(1))
                .SendKeys(phrase)
                .Perform();

            IWebElement findButton = driver.FindElement(findButtonLocator);

            findButton.Click();

            return new SearchResultsPage(driver);
        }

        public AboutPage NavigateToAboutPage()
        {
            IWebElement aboutLink = driver.FindElement(aboutLinkLocator);
            aboutLink.Click();
            return new AboutPage(driver);
        }

        public InsightsPage NavigateToInsightsPage()
        {
            IWebElement insightsLink = driver.FindElement(insightsLinkLocator);
            insightsLink.Click();
            return new InsightsPage(driver);
        }
    }
}
