using NUnit.Framework;
using OpenQA.Selenium;
using TestAutomationFramework.Business.PageObjects;

namespace TestAutomationFramework.BDD.StepDefinitions
{
    [Binding]
    public class JobSearchStepDefinitions : BaseStepDefinitions
    {
        MainPage mainPage;
        CareersPage careersPage;
        JobListingsPage jobListingsPage;
        JobDetailPage jobDetailPage;

        public JobSearchStepDefinitions()
        {
            mainPage = new MainPage(driver, configuration.Model.AppUrl);
        }


        [Given(@"I open Epam website")]
        public void GivenIOpenEpamWebsite()
        {
            mainPage.Open();
        }

        [Given(@"I click Careers link")]
        public void GivenIClickCareersLink()
        {
            careersPage = mainPage.NavigateToCareersPage();
        }

        [When(@"I enter '(.*)' in Keyword field")]
        public void WhenIEnterInKeywordField(string programming_language)
        {
            careersPage.SetProgrammingLanguage(programming_language);
        }

        [When(@"I select '(.*)' in Location dropdown")]
        public void WhenISelectInLocationDropdown(string location)
        {
            careersPage.SelectLocationFromDropDown(location);
        }

        [When(@"I select Remote checkbox")]
        public void WhenISelectRemoteCheckbox()
        {
            careersPage.SetRemote();
        }

        [When(@"I click Find button")]
        public void WhenIClickFindButton()
        {
            jobListingsPage = careersPage.ClickFindButton();
        }

        [When(@"I click View and apply button of the latest element in the list of results")]
        public void WhenIWhenIClickViewAndApplyOfTheLatestElementInResultList()
        {
            jobDetailPage = jobListingsPage.ClickViewAndApplyButton();
        }


        [Then(@"'(.*)' should be mentioned on the page")]
        public void ThenShouldBeMentionedOnThePage(string programming_language)
        {
            bool resultContainsProgrammingLanguage = jobDetailPage.ContainsProgrammingLanguage(programming_language);

            Assert.True(resultContainsProgrammingLanguage);
        }
    }
}
