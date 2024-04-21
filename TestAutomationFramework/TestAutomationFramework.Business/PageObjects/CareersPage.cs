using OpenQA.Selenium;

namespace TestAutomationFramework.Business.PageObjects
{
    public class CareersPage : BasePage
    {
        private IWebElement jobSearchForm => wait.Until(driver => driver.FindElement(By.Id("jobSearchFilterForm")));
        private IWebElement inputKeywords => jobSearchForm.FindElement(By.Id("new_form_job_search-keyword"));

        private IWebElement selectDiv => driver.FindElement(By.ClassName("recruiting-search__location"));

        private IWebElement remoteCheckboxLabel => driver.FindElement(By.XPath("//input[@id='id-93414a92-598f-316d-b965-9eb0dfefa42d-remote']/following-sibling::*"));

        private IWebElement findButton => driver.FindElement(By.XPath("//button[@type='submit']"));

        public CareersPage(IWebDriver driver) : base(driver)
        {

        }

        public CareersPage SetProgrammingLanguage(string language)
        {
            inputKeywords.SendKeys(language + Keys.Tab);
            return this;
        }

        public CareersPage SelectLocationFromDropDown(string location)
        {
            selectDiv.Click();
            IWebElement selectOption = wait.Until(d => driver.FindElement(By.XPath($"//li[@title='{location}']")));
            selectOption.Click();
            return this;
        }

        public CareersPage SetRemote()
        {
            remoteCheckboxLabel.Click();
            return this;
        }

        public JobListingsPage ClickFindButton()
        {
            findButton.Click();
            return new JobListingsPage(driver);
        }



    }
}
