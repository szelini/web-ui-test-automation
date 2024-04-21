using TestAutomationFramework.Business.PageObjects;


namespace TestAutomationFramework.Tests
{
    [TestFixture]
    public class WebUITests : WebUIBaseTest
    {
        [TestCase("C#", "All Locations")]
        public void SearchForPosition_ProgrammingLanguageLocationRemote(string programmingLanguage, string location)
        {

            var mainPage = new MainPage(driver, configuration.Model.AppUrl);

            var careersPage = mainPage.Open().NavigateToCareersPage();

            var jobListingsPage = careersPage
                .SetProgrammingLanguage(programmingLanguage)
                .SelectLocationFromDropDown(location)
                .SetRemote()
                .ClickFindButton();

            var jobDetailPage = jobListingsPage.ClickViewAndApplyButton();

            bool resultContainsProgrammingLanguage = jobDetailPage.ContainsProgrammingLanguage(programmingLanguage);

            Assert.True(resultContainsProgrammingLanguage);

        }

        [TestCase("BLOCKCHAIN")]
        [TestCase("Cloud")]
        [TestCase("Automation")]
        public void GlobalSearch_ReturnsRelevantLinks(string phrase)
        {

            var mainPage = new MainPage(driver, configuration.Model.AppUrl);

            var searchPage = mainPage.Open().PerformSearch(phrase);

            var resultTextss = searchPage.GetTextFromResults();

            Assert.IsTrue(resultTextss.TrueForAll(x => x.Contains(phrase)));
        }

        [TestCase("C:\\SeleniumDownloads", "EPAM_Corporate_Overview_Q4_EOY.pdf")]
        public void FileDownloadWorks(string filepath, string filename)
        {
            var mainPage = new MainPage(driver, configuration.Model.AppUrl);

            var aboutPage = mainPage.Open().NavigateToAboutPage();


            aboutPage.Download(filepath, filename);

            var fullDownloadPath = Path.Combine(filepath, filename);

            Assert.IsTrue(File.Exists(fullDownloadPath));
        }

        [Test]
        public void TitleOfArticleMatchesTitleInCarousel()
        {
            var mainPage = new MainPage(driver, configuration.Model.AppUrl);
            var insightsPage = mainPage.Open().NavigateToInsightsPage();

            var articleNameFromCarousel = insightsPage.GetArticleNameFromCarousel();

            var articlePage = insightsPage.NavigateToArticlePage();

            var articleNameFromHeader = articlePage.GetArticleNameFromHeader();

            StringAssert.AreEqualIgnoringCase(articleNameFromCarousel, articleNameFromHeader);
        }

    }
}