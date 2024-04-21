using OpenQA.Selenium;

namespace TestAutomationFramework.Business.PageObjects
{
    public class JobDetailPage : BasePage
    {
        public JobDetailPage(IWebDriver driver) : base(driver)
        {

        }

        public bool ContainsProgrammingLanguage(string language)
        {
            //var containsProgrammingLanguage = driver.FindElements(By.XPath($"//*[contains(text(), '{language}')]"));
            //return containsProgrammingLanguage.Any();
            try
            {
                driver.FindElements(By.XPath($"//*[contains(text(), '{language}')]"));
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
