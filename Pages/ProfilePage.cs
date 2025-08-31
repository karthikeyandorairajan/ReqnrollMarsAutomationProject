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
        private readonly By SkillsTab = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]");
      
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

        public void NavigateToLanguageTab()
        {
            try
            {
                var LanguagesTabElement = _wait.Until(ExpectedConditions.ElementToBeClickable(LanguagesTab));
                LanguagesTabElement.Click();
            }
            catch(Exception e)//  Thread.Sleep(10000); // Wait for the language to be added
            {
                Assert.Fail("Failed to navigate to Language tab." + e);
            }

        }
      
        public void NavigateToSkillsTab()
        {
            try {
            var SkillTabElement = _wait.Until(ExpectedConditions.ElementToBeClickable(SkillsTab));
            SkillTabElement.Click();
            }
            catch(Exception e)//  Thread.Sleep(10000); // Wait for the language to be added
            {
                Assert.Fail("Failed to navigate to Skills tab." + e);
            }

        }      

    }

}