
using ReqnrollMarsAutomationProject.Pages;

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
        [Then("Add language and level")]
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

        [Then("Enter (.*) and (.*)")]
        public void ThenAddEnglishAndBasic(string language, string level)
        {
            _profilePage.AddLanguage(language, level);
          //  Console.WriteLine(" I enter the language as "+language+ " and leve as" + leve);

        }

        [Then("Find added (.*) and (.*)")]
        public void ThenVerifyAddedEnglishAndBasic(string language, string level)
        {
            _profilePage.LanguageAndLevelVerification(language, level);

        }

        [Then("Same (.*) and (.*) again")]
        public void ThenSameLanguageAndLevelAgain(string language, string level)
        {
            _profilePage.AddLanguage(language, level);
        }

        [Then("Verify that duplicate language and level is not added")]
        public void ThenVerifyThatDuplicateLanguageAndLevelIsNotAdded()
        {
           _profilePage.VerifyAlreadyExistLanguagePopup();
        }

        [Then("Verify that duplicate language is not added")]
        public void ThenVerifyThatDuplicateLanguageIsNotAdded()
        {
            _profilePage.VerifyDuplicateLanguagePopup();
        }

        [Then("Verify that popup appears for empty language and level")]
        public void ThenVerifyThatPopupAppearsForEmptyLanguageAndLevel()
        {
            _profilePage.VerifyEmptyLanguageAndLevelPopup();
        }

        [Then("Delete (.*) and (.*)")]
        public void ThenDeleteLanguageAndLevel(String language, String level )
        {
            _profilePage.DeleteLanguageFromTable(language , level);    
        }
       

        [Then("Verify that (.*) and level is deleted")]
        public void ThenVerifyThatLanguageAndLevelIsDeleted(String language)
        {
            _profilePage.VerifyDeletedLanguageFromTable(language);
        }

        [Then("Edit (.*) and (.*) to (.*) and (.*)")]
        public void ThenEditTamilAndBasic(string language, string level, string updatedLanguage, string updateLevel )
        {
           _profilePage.verfiyEditLanguageAndLevel(language, level, updatedLanguage, updateLevel);  
        }

        [Then("Verify that (.*) and (.*) is updated")]
        public void ThenVerifyThatTamilAndBasicIsUpdated(String updatedLanguage, String updatedLevel)
        {
            _profilePage.verifyUpdateLanguageAndLevel(updatedLanguage, updatedLevel);    
        }

        [Then("Add multiple {int} (.*) and (.*)  ")]
        public void ThenAddMultipleEnglishAndBasic(int p0,String language,String level)
        {
            for (int i = 0; i < p0; i++)
            {
                _profilePage.AddLanguage(language, level);
            }
           
        }

        [Then("Add multiple {int} English and Basic")]
        public void ThenAddMultipleEnglishAndBasic(int p0)
        {
            _profilePage.AddLanguage("English", "Basic");
        }


        [Then("Verify AddNewbutton is not available")]
        public void ThenVerifyAddNewbuttonIsNotAvailable()
        {
            _profilePage.verifyAddNewButtonNotDisplayed();            
        }


        [Then("Add (.*) and (.*)")]
        public void ThenAddDanceAndBeginner(string skill, string level)
        {
            _profilePage.AddSkills(skill, level);
        }

        [Then("Findskill added (.*) and (.*)")]
        public void ThenFindskillAddedDanceAndBeginner(string skill, string level)
        {
            _profilePage.SkillsAndLevelVerification(skill, level );
        }
        
        [Then("Addsame (.*) and (.*) again")]
        public void ThenAddsameDanceAndBeginnerAgain(string skill, string level)
        {
           _profilePage.AddSkills(skill, level);
        }
        [Then("Verify that duplicate skill and level is not added")]
        public void ThenVerifyThatDuplicateSkillAndLevelIsNotAdded()
        {
            _profilePage.VerifyAlreadyExistSkillPopup();
        }

        [Then("Verify that duplicate skill is not added")]
        public void ThenVerifyThatDuplicateSkillIsNotAdded()
        {
            _profilePage.VerifyDuplicateSkillPopup();
        }

        [Then("Verify that popup appears for empty skill and level")]
        public void ThenVerifyThatPopupAppearsForEmptySkillAndLevel()
        {
            _profilePage.VerifyEmptySkillAndLevePopup();
        }

        [Then("Deleteadd (.*) and (.*)")]
        public void ThenDeleteaddSkillAndExpert(String skill, String level)
        {
            _profilePage.DeleteSkillFromTable(skill,level);
        }

        [Then("Verify Addskill that (.*) and level is deleted")]
        public void ThenVerifyAddskillThatSkillAndLevelIsDeleted(String skill)
        {
            _profilePage.VerifyDeletedSkillFromTable(skill);
        }

        [Then("Editskill (.*) and (.*) to (.*) and (.*)")]
        public void ThenEditskillEnglishAndFluentToTamilAndBasic(string skill, string level, string updatedSkill, string updateLevel)
        {
            _profilePage.verfiyEditSkillAndLevel(skill, level, updatedSkill, updateLevel);
        }

        [Then("Verify skill that (.*) and (.*) is updated")]
        public void ThenVerifySkillThatTamilAndBasicIsUpdated(String updatedSkill, String updatedLevel)
        {
            _profilePage.verifyUpdateSkillAndLevel(updatedSkill, updatedLevel);
        }

               
    }
}
