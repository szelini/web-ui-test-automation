using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestAutomationFramework.Business.PageObjects
{
    public class InsightsPage : BasePage
    {
        private By carouselRightButtonLocator => By.XPath("//button[@class=\"slider__right-arrow slider-navigation-arrow\"]");
        private By articleNameLocator => By.XPath("//main//div[@aria-hidden=\"false\"]//div[@class=\"single-slide__content-container\"]/div[@class=\"text\"]/div[@class=\"text-ui-23\"]//span");

        private By readMoreLinkLocator => By.LinkText("Read More");

        public InsightsPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetArticleNameFromCarousel()
        {
            IWebElement carouselRightButton = wait.Until(driver => driver.FindElement(carouselRightButtonLocator));

            var carouselActions = new Actions(driver);
            carouselActions
                .Pause(TimeSpan.FromSeconds(2))
                .Click(carouselRightButton)
                .Pause(TimeSpan.FromSeconds(2))
                .Click(carouselRightButton)
                .Pause(TimeSpan.FromSeconds(2))
                .Perform();

            IWebElement articleName = wait.Until(driver => driver.FindElement(articleNameLocator));

            return articleName.Text.Trim();
        }

        public ArticlePage NavigateToArticlePage()
        {
            IWebElement readMoreLink = wait.Until(driver => driver.FindElement(readMoreLinkLocator));
            readMoreLink.Click();
            return new ArticlePage(driver);
        }
    }
}
