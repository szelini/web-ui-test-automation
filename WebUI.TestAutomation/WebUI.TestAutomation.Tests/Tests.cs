using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebUI.TestAutomation.Business.PageObjects;


namespace WebUI.TestAutomation.Tests
{
    [TestFixture]
    public class Tests : BaseTest
    {
        [TestCase("C#", "All Locations")]
        public void SearchForPosition_ProgrammingLanguageLocationRemote(string programmingLanguage, string location) 
        {

            var mainPage = new MainPage(driver);

            var careersPage = mainPage.Open().NavigateToCareersPage();

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

            var searchPage = mainPage.Open().PerformSearch(phrase);

            var resultTextss = searchPage.GetTextFromResults();

            Assert.IsTrue(resultTextss.TrueForAll(x => x.Contains(phrase)));
        }

        [TestCase("C:\\SeleniumDownloads", "EPAM_Corporate_Overview_Q4_EOY.pdf")]
        public void FileDownloadWorks(string filepath, string filename)
        {
            

            var mainPage = new MainPage(driver);

           
            var aboutPage = mainPage.Open().NavigateToAboutPage();

            var fullDownloadPath = Path.Combine(filepath, filename);
            

            aboutPage.Download(fullDownloadPath);

           

            Assert.IsTrue(File.Exists(fullDownloadPath));
        }

        [Test]
        public void TitleOfArticleMatchesTitleInCarousel()
        {
            var mainPage = new MainPage(driver);
            var insightsPage = mainPage.Open().NavigateToInsightsPage();

            var articleNameFromCarousel = insightsPage.GetArticleNameFromCarousel();

            var articlePage = insightsPage.NavigateToArticlePage();

            var articleNameFromHeader = articlePage.GetArticleNameFromHeader();

            StringAssert.AreEqualIgnoringCase(articleNameFromCarousel, articleNameFromHeader);
        }

    }
}