using NUnit.Framework;
using OpenQA.Selenium;
using ReqnrollMarsAutomationProject.Pages;
using ReqnrollProjectTMPage.Utilities;

namespace ReqnrollMarsAutomationProject.StepDefinitions
{
    [Binding]
    public class SkillsTabStepDefinitions 
    {
        private readonly ProfilePage _profilePage;
        private readonly SkillsPage _skillsPage;
        string popupMsgInv = "Please enter skill and experience level";
        string popMsgSame = "This skill is already exist in your skill list.";
        string popMsgDup = "Duplicated data";
        string popMsgDelete = " has been deleted";

        public SkillsTabStepDefinitions( ProfilePage profilePage,  SkillsPage skillsPage)
        {
            _profilePage = profilePage;
            _skillsPage = skillsPage;
        }

             
        [Then("Add (.*) and (.*)")]
        public void ThenAddDanceAndBeginner(string skill, string level)
        {
            _profilePage.NavigateToSkillsTab();
            _skillsPage.AddSkills(skill, level);
        }
              
        [Then("Findskill added (.*) and (.*)")]
        public void ThenFindskillAddedDanceAndBeginner(string skill, string level)
        {
            Thread.Sleep(2000);
            String Popup;
            String AddedSkill;
            String AddedLevel;
            _skillsPage.SkillsAndLevelVerification(skill, level, out AddedSkill, out AddedLevel, out Popup);
            Assert.That(Popup, Is.EqualTo(skill + " has been added to your skills"));
            Assert.That(AddedSkill, Is.EqualTo(skill), "Skill name should match the added skill");
            Assert.That(AddedLevel, Is.EqualTo(level), "Skill level should match the added level");
            _skillsPage.ClearData();


        }

        [Then("Addsame (.*) and (.*) again")]
        public void ThenAddsameDanceAndBeginnerAgain(string skill, string level)
        {
            Thread.Sleep(5000);
            _skillsPage.AddSkills(skill, level);
        }
               
        [Then("Verify that duplicate skill and level is not added")]
        public void ThenVerifyThatDuplicateSkillAndLevelIsNotAdded()
            {
            Thread.Sleep(2000);
            String Popup;
            _skillsPage.VerifyAlreadyExistSkillPopup(out Popup);
            Assert.That(Popup, Is.EqualTo(popMsgSame), "Popup message should match the expected message");
            _skillsPage.ClearData();
        }
      
        [Then("Verify that duplicate skill is not added")]
        public void ThenVerifyThatDuplicateSkillIsNotAdded()
        {
            Thread.Sleep(3000);
            String Popup;
            _skillsPage.VerifyDuplicateSkillPopup(out Popup);
            Assert.That(Popup, Is.EqualTo(popMsgDup), "Popup message should match the expected message");
            _skillsPage.ClearData();
                       
        }

        
        [Then("Verify that popup appears for empty skill and level")]
        public void ThenVerifyThatPopupAppearsForEmptySkillAndLevel()
        {
            String Popup;
            _skillsPage.VerifyEmptySkillAndLevePopup(out Popup);
            Assert.That(Popup, Is.EqualTo(popupMsgInv), "Popup message should match the expected message");
            _skillsPage.ClearData();

        }

        [Then("Deleteadd (.*) and (.*)")]
        public void ThenDeleteaddSkillAndExpert(String skill, String level)
        {
            _skillsPage.DeleteSkillFromTable(skill, level);
        }
       

        [Then("Verify Addskill that (.*) and level is deleted")]
        public void ThenVerifyAddskillThatSkillAndLevelIsDeleted(String skill)
        {
            //Thread.Sleep(1000);
            String Popup;
            _skillsPage.VerifyDeletedSkillFromTable(skill, out Popup);
            Assert.That(Popup, Is.EqualTo(skill + popMsgDelete), "Popup message should match the expected message");
                        
        }

        [Then("Editskill (.*) and (.*) to (.*) and (.*)")]
        public void ThenEditskillEnglishAndFluentToTamilAndBasic(string skill, string level, string updatedSkill, string updateLevel)
        {
            _skillsPage.verfiyEditSkillAndLevel(skill, level, updatedSkill, updateLevel);
        }
        
        [Then("Verify skill that (.*) and (.*) is updated")]
        public void ThenVerifySkillThatTamilAndBasicIsUpdated(String updatedSkill, String updatedLevel)
        {
            Thread.Sleep(2000);
            String Popup;
            String AddedSkill;
            String AddedLevel;
            _skillsPage.SkillsAndLevelVerification(updatedSkill, updatedLevel, out AddedSkill, out AddedLevel, out Popup);
            Assert.That(Popup, Is.EqualTo(updatedSkill + " has been updated to your skills"));
            Assert.That(AddedSkill, Is.EqualTo(updatedSkill), "Skill name should match the updated skill");
            Assert.That(AddedLevel, Is.EqualTo(updatedLevel), "Skill level should match the updated level");
            _skillsPage.ClearData();
                        
        }
        [Then("Clear the data in Skills tab")]
        public void ThenClearTheDataInSkillsTab()
        {
            _skillsPage.ClearData();
        }


    }
}
