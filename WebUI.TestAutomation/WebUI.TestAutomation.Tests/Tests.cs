using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebUI.TestAutomation.Pages;

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
            var mainPage = new MainPage(driver);

            var careersPage = mainPage.Open().Careers();

            var jobListingsPage = careersPage
                .SetProgrammingLanguage(programmingLanguage)
                .SelectLocationFromDropDown(location)
                .SetRemote()
                .ClickFindButton();
            

            var jobDetailPage = jobListingsPage.ClickViewAndApplyButton();

            bool resultContainsProgrammingLanguage= jobDetailPage.ContainsProgrammingLanguage(programmingLanguage);

            Assert.True(resultContainsProgrammingLanguage);

        }

        [TestCase("BLOCKCHAIN")]
        [TestCase("Cloud")]
        [TestCase("Automation")]
        public void GlobalSearch_ReturnsRelevantLinks(string phrase)
        {

            var mainPage = new MainPage(driver);

            var searchPage = mainPage.Open().Search(phrase);

            var linkTexts = searchPage.GetLinkTextsFromResults();

            Assert.IsTrue(linkTexts.TrueForAll(x => x.Contains(phrase)));
        }

        [TearDown]
        protected void Teardown()
        {
            driver.Quit();
        }
    }
}