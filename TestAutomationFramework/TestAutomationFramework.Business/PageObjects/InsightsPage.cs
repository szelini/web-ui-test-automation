using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestAutomationFramework.Business.PageObjects
{
    public class InsightsPage : BasePage
    {
        private IWebElement carouselRightButton => wait.Until(driver => driver.FindElement(By.XPath("//button[@class=\"slider__right-arrow slider-navigation-arrow\"]")));
        private IWebElement articleName => wait.Until(driver => driver.FindElement(By.XPath("//main//div[@aria-hidden=\"false\"]//div[@class=\"single-slide__content-container\"]/div[@class=\"text\"]/div[@class=\"text-ui-23\"]//span")));

        private IWebElement readMoreLink => wait.Until(driver => driver.FindElement(By.LinkText("Read More")));

        public InsightsPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetArticleNameFromCarousel()
        {
            var carouselActions = new Actions(driver);
            carouselActions
                .Pause(TimeSpan.FromSeconds(2))
                .Click(carouselRightButton)
                .Pause(TimeSpan.FromSeconds(2))
                .Click(carouselRightButton)
                .Pause(TimeSpan.FromSeconds(2))
                .Perform();

            return articleName.Text;
        }

        public ArticlePage NavigateToArticlePage()
        {
            readMoreLink.Click();
            return new ArticlePage(driver);
        }

    }
}
