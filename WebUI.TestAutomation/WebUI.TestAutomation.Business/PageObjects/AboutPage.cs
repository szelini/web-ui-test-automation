using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.TestAutomation.Business.PageObjects
{
    public class AboutPage : BasePage
    {
        private IWebElement thirdSectionDiv => wait.Until(driver => driver.FindElement(By.XPath("//div[@class=\"section\"][3]")));

        private IWebElement downloadButton => thirdSectionDiv.FindElement(By.XPath("//a[contains(@href, \".pdf\")]"));

        public AboutPage(IWebDriver driver) : base(driver)
        {
        }

        public void Download(string filepath, string filename)
        {
            if (File.Exists(Path.Combine(filepath, filename)))
            {
                File.Delete(Path.Combine(filepath, filename));
            }

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            var downloadActions = new Actions(driver);

            downloadActions
               .ScrollToElement(thirdSectionDiv)
               .Click(downloadButton)
               .Pause(TimeSpan.FromSeconds(5))
               .Perform();
        }
    }
}
