using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private readonly By SkillInTableRow = By.XPath("//div[@data-tab='second']/div/div[2]/div/table[@class='ui fixed table']/tbody[last()]/tr/td[1]");
        private readonly By SkillLevelInTableRow = By.XPath("//div[@data-tab='second']/div/div[2]/div/table[@class='ui fixed table']/tbody[last()]/tr/td[2]");

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
            var AddLanguageElement = _wait.Until(ExpectedConditions.ElementIsVisible(AddLanguageText));
            AddLanguageElement.SendKeys(LanguageName);
            var ChooseLanguageLevelElement = _wait.Until(ExpectedConditions.ElementIsVisible(ChooseLanguageLevel));
            ChooseLanguageLevelElement.Click();
           
            var selectElement = new SelectElement(ChooseLanguageLevelElement);
            selectElement.SelectByValue(LanguageLevel);
            var AddButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(AddButton));
            AddButtonElement.Click();

            }

        public void LanguageAndLevelVerification(string LanguageName, string LanguageLevel)
        {            
            var LanguageInTable = _wait.Until(d => d.FindElement(LanguageInTableRow)).Text;
            var LevelInTable = _wait.Until(d => d.FindElement(LevelInTableRow)).Text;
            Assert.That(LanguageInTable, Is.EqualTo(LanguageName), "Language name should match the added language");
            Assert.That(LevelInTable, Is.EqualTo(LanguageLevel), "Language level should match the added level");
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

        }
        public void SkillsAndLevelVerification(string SkillName, string SkillLevel)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // 10-second implicit wait
            var SkillInTable = _wait.Until(d => d.FindElement(SkillInTableRow)).Text;
            var SkillLevelInTable = _wait.Until(d => d.FindElement(SkillLevelInTableRow)).Text;
            Assert.That(SkillInTable, Is.EqualTo(SkillName), "Skill name should match the added Skill");
            Assert.That(SkillLevelInTable, Is.EqualTo(SkillLevel), "Skill level should match the added level");
        }



    }
}
