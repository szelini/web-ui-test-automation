using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.TestAutomation.Pages
{
    public class JobDetailPage : BasePage
    {
        public JobDetailPage(IWebDriver driver) : base(driver)
        {

        }

        public bool ContainsProgrammingLanguage(string language)
        {
            var containsProgrammingLanguage = driver.FindElements(By.XPath($"//*[contains(text(), '{language}')]"));
            return containsProgrammingLanguage.Any();
        }
    }
}
