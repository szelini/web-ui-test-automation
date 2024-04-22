using OpenQA.Selenium;

namespace TestAutomationFramework.Business.PageObjects
{
    public class CareersPage : BasePage
    {
        private By jobSearchFormLocator =>  By.Id("jobSearchFilterForm");
        private By inputKeywordsLocator => By.Id("new_form_job_search-keyword");

        private By selectDivLocator = By.ClassName("recruiting-search__location");

        private By remoteCheckboxLocator = By.Id("id-93414a92-598f-316d-b965-9eb0dfefa42d-remote");

        private By remoteCheckboxLabelLocator = By.XPath("//input[@id='id-93414a92-598f-316d-b965-9eb0dfefa42d-remote']/following-sibling::*");

        private By findButtonLocator => By.XPath("//button[@type='submit']");

        public CareersPage(IWebDriver driver) : base(driver)
        {

        }

        public CareersPage SetProgrammingLanguage(string language)
        {
            IWebElement jobSearchForm = wait.Until(driver => driver.FindElement(jobSearchFormLocator));

            IWebElement inputKeywords = wait.Until(driver => jobSearchForm.FindElement(inputKeywordsLocator));

            inputKeywords.SendKeys(language + Keys.Tab);

            return this;
        }

        public CareersPage SelectLocationFromDropDown(string location)
        {

            IWebElement selectDiv = wait.Until(driver => driver.FindElement(selectDivLocator));
            selectDiv.Click();
            IWebElement selectOption = wait.Until(driver => driver.FindElement(By.XPath($"//li[@title='{location}']")));
            selectOption.Click();
            return this;
        }

        public CareersPage SetRemote()
        {
            IWebElement remoteCheckboxLabel = wait.Until(driver => driver.FindElement(remoteCheckboxLabelLocator));
            IWebElement remoteCheckbox = wait.Until(driver => driver.FindElement(remoteCheckboxLocator));

            if (!remoteCheckbox.Selected)
            {
                remoteCheckboxLabel.Click();
                
            }

            return this;

        }

        public JobListingsPage ClickFindButton()
        {
            IWebElement findButton = wait.Until(driver => driver.FindElement(findButtonLocator));

            findButton.Click();
            return new JobListingsPage(driver);
        }

    }
}
