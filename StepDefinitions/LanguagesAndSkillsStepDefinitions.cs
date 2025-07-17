using OpenQA.Selenium.Chrome;
using Reqnroll;
using ReqnrollMarsAutomationProject.Pages;
using ReqnrollProjectTMPage.Utilities;
using System;

namespace ReqnrollMarsAutomationProject.StepDefinitions
{
    [Binding]
    public class LanguagesAndSkillsStepDefinitions
    {
        private readonly HomePage _homePage;
        private readonly ProfilePage _profilePage;
        private readonly NavigationHelper _navigationHelper;
        public LanguagesAndSkillsStepDefinitions(NavigationHelper navigationHelper,HomePage homePage,ProfilePage profilePage)
        {
            _navigationHelper = navigationHelper;
            _homePage = homePage;
            _profilePage = profilePage;
            
        }

      

        [Given("I am on the Sign in page")]
        public void GivenIAmOnTheSignInPage()
        {
           _homePage.ClickSignIn();
        }

        [When("I enter valid credentials")]
        public void WhenIEnterValidCredentials()
        {
            _homePage.Login("karthikeyandorairajan@gmail.com", "Karthikeyan_IC");
        }

        [Then("I should see the Profile page")]
        public void ThenIShouldSeeTheProfilePage()
        {
           _profilePage.VerifyProfileMenu();
        }
        [Then("Add Language and level")]
        public void ThenAddLanguageAndLevel()
        {
           _profilePage.AddLanguage("English", "Basic");
        }
        [Then("Verify added language and level")]
        public void ThenVerifyAddedLanguageAndLevel()
        {
            _profilePage.LanguageAndLevelVerification("English", "Basic");
        }

        [Then("Add Skills")]
        public void ThenAddSkills()
        { 
            _profilePage.AddSkills("dance", "Beginner");
        }
        [Then("Verify added Skills")]
        public void ThenVerifyAddedSkills()
        {
            _profilePage.SkillsAndLevelVerification("dance", "Beginner");
        }



    }
}
