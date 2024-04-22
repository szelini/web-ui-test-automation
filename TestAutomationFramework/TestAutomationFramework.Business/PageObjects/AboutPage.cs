using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestAutomationFramework.Business.PageObjects
{
    public class AboutPage : BasePage
    {
        private By thirdSectionDivLocator => By.XPath("//div[@class=\"section\"][3]");
        private By downloadButtonLocator => By.XPath("//a[contains(@href, \".pdf\")]");
        
        public AboutPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickDownloadButton()
        {
            IWebElement thirdSectionDiv = wait.Until(driver => driver.FindElement(thirdSectionDivLocator));
            IWebElement downloadButton = wait.Until(driver => thirdSectionDiv.FindElement(downloadButtonLocator));

            var downloadActions = new Actions(driver);
           
            downloadActions
               .ScrollToElement(thirdSectionDiv)
               .Click(downloadButton)
               .Pause(TimeSpan.FromSeconds(5))
               .Perform();
        }
    }
}
