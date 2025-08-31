
using NUnit.Framework;
using ReqnrollMarsAutomationProject.Pages;

namespace ReqnrollMarsAutomationProject.StepDefinitions
{
    [Binding]
    public class LanguagesTabStepDefinitions
    {
        private readonly HomePage _homePage;
        private readonly ProfilePage _profilePage;
        private readonly LanguagePage _languagePage;
        private readonly SkillsPage _skillsPage;
        string popupMsgInv = "Please enter language and level";
        string popMsgSame = "This language is already exist in your language list.";
        string popMsgDup = "Duplicated data";
        string popMsgDelete = " has been deleted from your languages";

        public LanguagesTabStepDefinitions(HomePage homePage, ProfilePage profilePage, LanguagePage languagePage, SkillsPage skillsPage)
        {
            _homePage = homePage;
            _profilePage = profilePage;
            _languagePage = languagePage;           
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
        
        [Then("Enter (.*) and (.*)")]
        public void ThenAddEnglishAndBasic(string language, string level)
        {
            _profilePage.NavigateToLanguageTab();
            _languagePage.AddLanguage(language, level);
            // Thread.Sleep(6000);
        }

        [Then("Find added (.*) and (.*)")]
        public void ThenVerifyAddedEnglishAndBasic(string language, string level)
        {
            Thread.Sleep(2000);
            String Popup;
            String AddedLanguage;
            String AddedLevel;
            _languagePage.LanguageAndLevelVerification(language, level, out AddedLanguage, out AddedLevel,out Popup);
            Assert.That(Popup, Is.EqualTo(language + " has been added to your languages"));
            Assert.That(AddedLanguage, Is.EqualTo(language), "Language name should match the added language");
            Assert.That(AddedLevel, Is.EqualTo(level), "Language level should match the added level");
            _languagePage.ClearData();
        }

        [Then("Same (.*) and (.*) again")]
        public void ThenSameLanguageAndLevelAgain(string language, string level)
        {
            _languagePage.AddLanguage(language, level);
            //Thread.Sleep(3000);
        }

        [Then("Verify that duplicate language and level is not added")]
        public void ThenVerifyThatDuplicateLanguageAndLevelIsNotAdded()
        {
            Thread.Sleep(5000);
            String Popup;
            _languagePage.VerifyAlreadyExistLanguagePopup(out Popup);
            Assert.That(Popup, Is.EqualTo(popMsgSame), "Popup message should match the expected message");
            _languagePage.ClearData();
        }

        [Then("Verify that duplicate language is not added")]
        public void ThenVerifyThatDuplicateLanguageIsNotAdded()
        {
            Thread.Sleep(5000);
            String Popup;
            _languagePage.VerifyDuplicateLanguagePopup(out Popup);
            Assert.That(Popup, Is.EqualTo(popMsgDup), "Popup message should match the expected message");
            _languagePage.ClearData();
           
        }

        [Then("Verify that popup appears for empty language and level")]
        public void ThenVerifyThatPopupAppearsForEmptyLanguageAndLevel()
        {
            //Thread.Sleep(3000);
            String Popup;
            _languagePage.VerifyEmptyLanguageAndLevelPopup(out Popup);
            Assert.That(Popup, Is.EqualTo(popupMsgInv), "Popup message should match the expected message");
           
        }

        [Then("Delete (.*) and (.*)")]
        public void ThenDeleteLanguageAndLevel(String language, String level )
        {
            _languagePage.DeleteLanguageFromTable(language , level);    
        }
       

        [Then("Verify that (.*) and level is deleted")]
        public void ThenVerifyThatLanguageAndLevelIsDeleted(String language)
        {
            Thread.Sleep(2000);
            String Popup;
            _languagePage.VerifyDeletedLanguageFromTable(language, out Popup);
            Assert.That(Popup,Is.EqualTo(language + popMsgDelete), "Popup message should match the expected message");                    
        }

        
        [Then("Edit (.*) and (.*) to (.*) and (.*)")]
        public void ThenEditTamilAndBasic(string language, string level, string updatedLanguage, string updateLevel )
        {
            _languagePage.verfiyEditLanguageAndLevel(language, level, updatedLanguage, updateLevel);  
        }

        [Then("Verify that (.*) and (.*) is updated")]
        
        public void ThenVerifyThatLanguageAndLevelIsUpdated(String updatedLanguage, String updatedLevel)

        {
            Thread.Sleep(2000);
            String Popup;
            String AddedLanguage;
            String AddedLevel;
            _languagePage.LanguageAndLevelVerification(updatedLanguage, updatedLevel, out AddedLanguage, out AddedLevel, out Popup);
            Assert.That(Popup, Is.EqualTo(updatedLanguage + " has been updated to your languages"));
            Assert.That(AddedLanguage, Is.EqualTo(updatedLanguage), "Language name should match the updated language");
            Assert.That(AddedLevel, Is.EqualTo(updatedLevel), "Language level should match the updated level");
            _languagePage.ClearData();
                        
        }
        
        [Then("Add multiple {int} (.*) and (.*)  ")]
        public void ThenAddMultipleEnglishAndBasic(int p0,String language,String level)
        {
            for (int i = 0; i < p0; i++)
            {
                _languagePage.AddLanguage(language, level);
            }
           
        }

        [Then("Add multiple {int} English and Basic")]
        public void ThenAddMultipleEnglishAndBasic(int p0)
        {
            _languagePage.AddLanguage("English", "Basic");
        }


        [Then("Verify AddNewbutton is not available")]
        public void ThenVerifyAddNewbuttonIsNotAvailable()
        {
            _languagePage.verifyAddNewButtonNotDisplayed(out bool ActualResult);            
            Assert.That(ActualResult, Is.EqualTo(false), "AddNew button should not be displayed after adding 4 languages");
        }

        [Then("Clear the data")]
        public void ThenClearTheData()
        {
            _languagePage.ClearData();
        }

    }
}
