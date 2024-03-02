using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebUI.TestAutomation.Tests
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestCase("C#", "All Locations")]
        public void SearchForPosition_ProgrammingLanguageLocationRemote(string programmingLanguage, string location) 
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            driver.Navigate().GoToUrl(TestContext.Parameters["appUrl"]);
            
            var careersLink = driver.FindElement(By.LinkText("Careers"));
            careersLink.Click();
                      
            var jobSearchForm = driver.FindElement(By.Id("jobSearchFilterForm"));

            var inputKeywords = jobSearchForm.FindElement(By.Id("new_form_job_search-keyword"));
            inputKeywords.SendKeys(programmingLanguage + Keys.Tab);

            var selectDiv = driver.FindElement(By.ClassName("recruiting-search__location"));
            selectDiv.Click();
           
            var option =  driver.FindElement(By.XPath($"//li[@title='{location}']"));
            option.Click();

            var remoteCheckboxLabel =  driver.FindElement(By.XPath("//input[@id='id-93414a92-598f-316d-b965-9eb0dfefa42d-remote']/following-sibling::*"));
            remoteCheckboxLabel.Click();

            var findButton = driver.FindElement(By.XPath("//button[@type='submit']"));
            findButton.Click();

            var lastResultItem =  driver.FindElement(By.CssSelector(".search-result__item:last-child"));

            var viewAndApply = lastResultItem.FindElement(By.ClassName("search-result__item-apply-23"));

            viewAndApply.Click();

            var containsProgrammingLanguage =  driver.FindElement(By.XPath($"//*[contains(text(), '{programmingLanguage}')]"));

            Assert.IsNotNull(containsProgrammingLanguage);

        }

        [TestCase("BLOCKCHAIN")]
        [TestCase("Cloud")]
        [TestCase("Automation")]
        public void GlobalSearch_ReturnsRelevantLinks(string searchInput)
        {

            var elementWait = new WebDriverWait(driver, TimeSpan.FromSeconds(2))
            {
                PollingInterval = TimeSpan.FromSeconds(0.25),
                Message = "Element has not been found"
            };

            driver.Navigate().GoToUrl(TestContext.Parameters["appUrl"]);

            var searchIcon = elementWait.Until(driver => driver.FindElement(By.ClassName("search-icon")));
            searchIcon.Click();

            var searchInputField = elementWait.Until(driver => driver.FindElement(By.Name("q")));
            searchInputField.SendKeys(searchInput);

            var findButton = driver.FindElement(By.ClassName("custom-search-button"));
            findButton.Click();

            var resultListDiv = elementWait.Until(driver => driver.FindElement(By.ClassName("search-results__items")));

            var linkTexts = resultListDiv.FindElements(By.TagName("a")).Select(t => t.Text).ToList();

            Assert.IsTrue(linkTexts.TrueForAll(x => x.Contains(searchInput)));
        }

        [TearDown]
        protected void Teardown()
        {
            driver.Quit();
        }
    }
}