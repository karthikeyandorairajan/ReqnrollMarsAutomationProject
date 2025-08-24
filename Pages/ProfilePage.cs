using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ReqnrollMarsAutomationProject.Pages
{
    public class ProfilePage
    {

        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public IWebDriver Driver => _driver;

        // Locators
        private readonly By ProfileMenu = By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]");
        private readonly By LanguagesTab = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]");
        private readonly By AddNewButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div ");
        private readonly By AddLanguageText = By.Name("name");
        private readonly By ChooseLanguageLevel = By.Name("level");
        private readonly By AddButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]");
        private readonly By LanguageInTableRow = By.XPath("//table[@class='ui fixed table']/tbody/tr/td[1]");
        private readonly By LevelInTableRow = By.XPath("//table[@class='ui fixed table']/tbody/tr/td[2]");

        private readonly By SkillsTab = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]");
        private readonly By SkillsAddNewButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div");
        private readonly By AddSkillText = By.Name("name");
        private readonly By ChooseSkillLevel = By.XPath("//select[@name='level']");
        private readonly By AddSkillButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]");
        //private readonly By SkillInTableRow = By.XPath("//div[@data-tab='second']/div/div[2]/div/table[@class='ui fixed table']/tbody[last()]/tr/td[1]");
        private readonly By SkillInTableRow = By.XPath("//table[@class='ui fixed table']/tbody[last()]/tr/td[1]");
        private readonly By SkillLevelInTableRow = By.XPath("//div[@data-tab='second']/div/div[2]/div/table[@class='ui fixed table']/tbody[last()]/tr/td[2]");
        private readonly By DeleteLanguage = By.XPath("//i[contains(@class,'remove')]");
        private readonly By AlreadyExistLanguagePopup = By.XPath("//div[text()='This language is already exist in your language list.']");
        private readonly By DuplicateLanguagePopup = By.XPath("//div[text()='Duplicated data']");
        private readonly By EmptyLanguageAndLevelPopup = By.XPath("//div[text()='Please enter language and level']");
        //  private readonly By EditLanguageAndLevel = By.XPath("//i[contains(@class,'outline')]");");
        private readonly By UpdateButton = By.XPath("//input[@value='Update']");
        private readonly By AlreadyExistSkillPopup = By.XPath("//div[text()='This skill is already exist in your skill list.']");
        private readonly By DuplicateSkillPopup = By.XPath("//div[text()='Duplicated data']");
        private readonly By EmptySkillAndLevePopup = By.XPath("//div[text()='Please enter skill and experience level']");
        private readonly By DeleteSkill = By.XPath("//i[contains(@class,\"remove\")]");
        private readonly By DeleteLanguages = By.XPath("//table[@class='ui fixed table']/tbody/tr/td[1]/following-sibling :: td[2]/span/i[@class='remove icon']");

        public ProfilePage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
        }

        public void VerifyProfileMenu()
        {
            var ProfileElement = _wait.Until(ExpectedConditions.ElementIsVisible(ProfileMenu));
            // Assert.That(ProfileElement, Is.Not.Null);
            if (ProfileElement.Displayed)
            {
                Console.WriteLine("Logged in successfully");
            }
            else
            {
                Console.WriteLine("Logged error");
            }

        }
        public void AddLanguage(string LanguageName, string LanguageLevel)
        {

            var LanguagesTabElement = _wait.Until(ExpectedConditions.ElementToBeClickable(LanguagesTab));
            LanguagesTabElement.Click();
            var AddNewButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(AddNewButton));
            AddNewButtonElement.Click();
            Thread.Sleep(1000); // Wait for the Add Language form to appear
            var AddLanguageElement = _wait.Until(ExpectedConditions.ElementIsVisible(AddLanguageText));
            AddLanguageElement.SendKeys(LanguageName);
            var ChooseLanguageLevelElement = _wait.Until(ExpectedConditions.ElementIsVisible(ChooseLanguageLevel));
            ChooseLanguageLevelElement.Click();

            var selectElement = new SelectElement(ChooseLanguageLevelElement);
            selectElement.SelectByValue(LanguageLevel);
            var AddButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(AddButton));
            AddButtonElement.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // 10-second implicit wait
                                                                                //  Thread.Sleep(10000); // Wait for the language to be added

        }

        public void LanguageAndLevelVerification(string LanguageName, string LanguageLevel)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            var LanguageInTable = _wait.Until(d => d.FindElement(LanguageInTableRow)).Text;
            var LevelInTable = _wait.Until(d => d.FindElement(LevelInTableRow)).Text;
            Assert.That(LanguageInTable, Is.EqualTo(LanguageName), "Language name should match the added language");
            Assert.That(LevelInTable, Is.EqualTo(LanguageLevel), "Language level should match the added level");
            var DeleteLanguageElement = _wait.Until(ExpectedConditions.ElementToBeClickable(DeleteLanguage));
            DeleteLanguageElement.Click();
        }

        public void AddSkills(string SkillName, string SkillLevel)
        {

            var SkillTabElement = _wait.Until(ExpectedConditions.ElementToBeClickable(SkillsTab));
            SkillTabElement.Click();
            var SkillsAddNewButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(SkillsAddNewButton));
            SkillsAddNewButtonElement.Click();
            var AddSkillElement = _wait.Until(ExpectedConditions.ElementIsVisible(AddSkillText));
            AddSkillElement.SendKeys(SkillName);
            var ChooseSkillLevelElement = _wait.Until(ExpectedConditions.ElementIsVisible(ChooseSkillLevel));
            ChooseSkillLevelElement.Click();

            var selectElement = new SelectElement(ChooseSkillLevelElement);
            selectElement.SelectByValue(SkillLevel);
            var AddSkillButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(AddSkillButton));
            AddSkillButtonElement.Click();
            Thread.Sleep(5000);

        }
        public void AddSkillsAndLevelVerification(string SkillName, string SkillLevel)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // 10-second implicit wait
            var SkillInTable = _wait.Until(d => d.FindElement(SkillInTableRow)).Text;
            var SkillLevelInTable = _wait.Until(d => d.FindElement(SkillLevelInTableRow)).Text;
            Assert.That(SkillInTable, Is.EqualTo(SkillName), "Skill name should match the added Skill");
            Assert.That(SkillLevelInTable, Is.EqualTo(SkillLevel), "Skill level should match the added level");
        }

        
        public void SkillsAndLevelVerification(string SkillName, string SkillLevel)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // 10-second implicit wait
            var SkillInTable = _wait.Until(d => d.FindElement(SkillInTableRow)).Text;
            var SkillLevelInTable = _wait.Until(d => d.FindElement(SkillLevelInTableRow)).Text;
            Assert.That(SkillInTable, Is.EqualTo(SkillName), "Skill name should match the added Skill");
            Assert.That(SkillLevelInTable, Is.EqualTo(SkillLevel), "Skill level should match the added level");
            var DeleteSkillElement = _wait.Until(ExpectedConditions.ElementToBeClickable(DeleteSkill));
            DeleteSkillElement.Click();
        }

        public void VerifyAlreadyExistLanguagePopup()
        {
            try
            {
                var popupElement = _wait.Until(ExpectedConditions.ElementIsVisible(AlreadyExistLanguagePopup));
                Assert.That(popupElement.Displayed, "Already exist language popup should be displayed");
                Console.WriteLine("Already exist language popup is displayed: " + popupElement.Text);
                var DeleteLanguageElement = _wait.Until(ExpectedConditions.ElementToBeClickable(DeleteLanguage));
                DeleteLanguageElement.Click();
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Already exist language popup did not appear as expected.");
            }

        }

        public void VerifyDuplicateLanguagePopup()
        {
            try
            {
                var popupElement = _wait.Until(ExpectedConditions.ElementIsVisible(DuplicateLanguagePopup));
                Assert.That(popupElement.Displayed, "Duplicate language popup should be displayed");
                Console.WriteLine("Duplicate language popup is displayed: " + popupElement.Text);
                var DeleteLanguageElement = _wait.Until(ExpectedConditions.ElementToBeClickable(DeleteLanguage));
                DeleteLanguageElement.Click();
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Duplicate language popup did not appear as expected.");
            }

        }
        public void VerifyEmptyLanguageAndLevelPopup()
        {
            try
            {
                var popupElement = _wait.Until(ExpectedConditions.ElementIsVisible(EmptyLanguageAndLevelPopup));
                Assert.That(popupElement.Displayed, "Empty language and level popup should be displayed");
                Console.WriteLine("Empty language and level popup is displayed: " + popupElement.Text);
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Empty language and level popup did not appear as expected.");
            }
        }

        public void DeleteLanguageFromTable(String language, String level)
        {
            try
            {
                IWebElement DeleteElementForAddedLanguage = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//td[text()='{language}']")));
                var deleteLanguageElementForAddedLanguage = _wait.Until(ExpectedConditions.ElementToBeClickable(DeleteLanguage));
                deleteLanguageElementForAddedLanguage.Click();
                Console.WriteLine("Language deleted successfully.");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Failed to delete language from the table.");
            }

        }
        public void VerifyDeletedLanguageFromTable(String language)
        {
            try
            {
                String xpath = $"//div[text()='{language} has been deleted from your languages']";
                IWebElement LanguageDeletePopup = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                Assert.That(LanguageDeletePopup.Displayed, "Delete Language popup should be displayed");
                Console.WriteLine("Empty language and level popup is displayed: " + LanguageDeletePopup.Text);

                
            }
            catch (Exception e)
            {
                Assert.Fail("Failed to verify deleted language from the table." + e);
            }
        }

        public void verfiyEditLanguageAndLevel(String language, String level, String updatedLanguage, String updatedLevel)
        {
            try
            {
                IWebElement EditElementForAddedLanguage = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//td[text()='{language}']/following-sibling::td[2]/span/i[contains(@class,'outline')]")));
                var editLanguageElementForAddedLanguage = _wait.Until(ExpectedConditions.ElementToBeClickable(EditElementForAddedLanguage));
                editLanguageElementForAddedLanguage.Click();

                var AddLanguageElement = _wait.Until(ExpectedConditions.ElementIsVisible(AddLanguageText));
                AddLanguageElement.Clear(); // Clear the existing text before sending new text
                AddLanguageElement.SendKeys(updatedLanguage);
                var ChooseLanguageLevelElement = _wait.Until(ExpectedConditions.ElementIsVisible(ChooseLanguageLevel));
                ChooseLanguageLevelElement.Click();

                var selectElement = new SelectElement(ChooseLanguageLevelElement);
                selectElement.SelectByValue(updatedLevel);
                var UpdateButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(UpdateButton));
                UpdateButtonElement.Click();
                //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15); // 10-second implicit wait
                //Thread.Sleep(10000);
                Console.WriteLine("Language edited successfully.");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Failed to delete language from the table.");
            }

        }
        public void verifyUpdateLanguageAndLevel(String language, String level)
        {
            try
            {
                String xpath = $"//div[text()='{language} has been updated to your languages']";
                IWebElement LanguageUpdatePopup = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                Assert.That(LanguageUpdatePopup.Displayed, "Update Language popup should be displayed");
                Console.WriteLine("Empty language and level popup is displayed: " + LanguageUpdatePopup.Text);

                var LanguageInTable = _wait.Until(d => d.FindElement(LanguageInTableRow)).Text;

                Assert.That(LanguageInTable, Is.EqualTo(language), "Updated language should be present in the table");
                var DeleteLanguageElement = _wait.Until(ExpectedConditions.ElementToBeClickable(DeleteLanguage));
                DeleteLanguageElement.Click();

            }
            catch (Exception e)
            {
                Assert.Fail("Failed to verify Updated language from the table." + e);
            }

        }

        public void verifyAddNewButtonNotDisplayed()
        {
            try
            {
                var AddNewButtonElement = _wait.Until(ExpectedConditions.ElementIsVisible(AddNewButton));
                Assert.That(AddNewButtonElement.Displayed, Is.False, "Add New button should not be displayed when no languages are added.");
                Console.WriteLine("Add New button is not displayed as expected.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Add New button is not displayed as expected.");
            }
        }

   
        public void VerifyAlreadyExistSkillPopup()
        {
            try
            {
                var popupElement = _wait.Until(ExpectedConditions.ElementIsVisible(AlreadyExistSkillPopup));
                Assert.That(popupElement.Displayed, "Already exist skill popup should be displayed");
                Console.WriteLine("Already exist skill popup is displayed: " + popupElement.Text);
                var DeleteSkillElement = _wait.Until(ExpectedConditions.ElementToBeClickable(DeleteSkill));
                DeleteSkillElement.Click();

            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Already exist skill popup did not appear as expected.");
            }

        }

        public void VerifyDuplicateSkillPopup()
        {
            try
            {
                var popupElement = _wait.Until(ExpectedConditions.ElementIsVisible(DuplicateSkillPopup));
                Assert.That(popupElement.Displayed, "Duplicate skill popup should be displayed");
                Console.WriteLine("Duplicate skill popup is displayed: " + popupElement.Text);
                var DeleteSkillElement = _wait.Until(ExpectedConditions.ElementToBeClickable(DeleteSkill));
                DeleteSkillElement.Click();

            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Duplicate skill popup did not appear as expected.");
            }


        }

        public void VerifyEmptySkillAndLevePopup()
        {
            try
            {
                var popupElement = _wait.Until(ExpectedConditions.ElementIsVisible(EmptySkillAndLevePopup));
                Assert.That(popupElement.Displayed, "Empty skill and level popup should be displayed");
                Console.WriteLine("Empty skill and level popup is displayed: " + popupElement.Text);
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Empty skill and level popup did not appear as expected.");
            }
        }

        public void DeleteSkillFromTable(String skill, String level)
        {
            try
            {
                IWebElement DeleteElementForAddedSkill = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//td[text()='{skill}']")));
                var deleteSkillElementForAddedSkill = _wait.Until(ExpectedConditions.ElementToBeClickable(DeleteSkill));
                deleteSkillElementForAddedSkill.Click();
                Console.WriteLine("Skill deleted successfully.");

            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Failed to delete skill from the table.");
            }

        }
        public void VerifyDeletedSkillFromTable(String skill)
        {
            try
            {
                String xpath = $"//div[text()='{skill} has been deleted']";
                IWebElement SkillDeletePopup = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                Assert.That(SkillDeletePopup.Displayed, "Delete Skill popup should be displayed");
                Console.WriteLine("Empty skill and level popup is displayed: " + SkillDeletePopup.Text);
                
            }
            catch (Exception e)
            {
                Assert.Fail("Failed to verify deleted skill from the table." + e);
            }
        }

        public void verfiyEditSkillAndLevel(String skill, String level, String updatedSkill, String updatedLevel)
            {
            try
            {
                IWebElement EditElementForAddedSkill = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//td[text()='{skill}']/following-sibling::td[2]/span/i[contains(@class,'outline')]")));
                var editSkillElementForAddedSkill = _wait.Until(ExpectedConditions.ElementToBeClickable(EditElementForAddedSkill));
                editSkillElementForAddedSkill.Click();
                var AddSkillElement = _wait.Until(ExpectedConditions.ElementIsVisible(AddSkillText));
                AddSkillElement.Clear(); // Clear the existing text before sending new text
                AddSkillElement.SendKeys(updatedSkill);
                var ChooseSkillLevelElement = _wait.Until(ExpectedConditions.ElementIsVisible(ChooseSkillLevel));
                ChooseSkillLevelElement.Click();
                var selectElement = new SelectElement(ChooseSkillLevelElement);
                selectElement.SelectByValue(updatedLevel);
                var UpdateButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(UpdateButton));
                UpdateButtonElement.Click();
                //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15); // 10-second implicit wait
                //Thread.Sleep(10000);
                Console.WriteLine("Skill edited successfully.");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Failed to delete skill from the table.");
            }
        }

        public void verifyUpdateSkillAndLevel(String skill, String level)
            {
            try
            {
                String xpath = $"//div[text()='{skill} has been updated to your skills']";
                IWebElement SkillUpdatePopup = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                Assert.That(SkillUpdatePopup.Displayed, "Update Skill popup should be displayed");
                Console.WriteLine("Empty skill and level popup is displayed: " + SkillUpdatePopup.Text);
                var SkillInTable = _wait.Until(d => d.FindElement(SkillInTableRow)).Text;
                Assert.That(SkillInTable, Is.EqualTo(skill), "Updated skill should be present in the table");
                var DeleteSkillElement = _wait.Until(ExpectedConditions.ElementToBeClickable(DeleteSkill));
                DeleteSkillElement.Click();
            }
            catch (Exception e)
            {
                Assert.Fail("Failed to verify Updated skill from the table." + e);
            }
        }

    }

}