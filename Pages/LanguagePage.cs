using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ReqnrollMarsAutomationProject.Pages
{
    public class LanguagePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public IWebDriver Driver => _driver;

               
        private readonly By LanguagesTab = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]");
        private readonly By AddNewButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div ");
        private readonly By AddLanguageText = By.Name("name");
        private readonly By ChooseLanguageLevel = By.Name("level");
        private readonly By AddButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]");
        private readonly By LanguageInTableRow = By.XPath("//table[@class='ui fixed table']/tbody/tr/td[1]");
        private readonly By LevelInTableRow = By.XPath("//table[@class='ui fixed table']/tbody/tr/td[2]");
        private readonly By popupmsg = By.XPath("//div[@class='ns-box-inner']");
        private readonly By DeleteLanguage = By.XPath("//i[contains(@class,'remove')]");
        private readonly By UpdateButton = By.XPath("//input[@value='Update']");
        private readonly By DeleteLanguages = By.XPath("//table[@class='ui fixed table']/tbody/tr/td[1]/following-sibling :: td[2]/span/i[@class='remove icon']");

        public LanguagePage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
        }

        
        public void AddLanguage(string LanguageName, string LanguageLevel)
        {
            try
            {
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
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); 
            }
            catch(Exception e) // Wait for the language to be added
            {
                  Assert.Fail("Failed to add language: " + e);
            }

        }

        public void LanguageAndLevelVerification(string LanguageName, string LanguageLevel,out String ActualLanguageName, out String ActualLanguageLevel,out String ActualPopup)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            var popupmsgActual = _wait.Until(d => d.FindElement(popupmsg)).Text;
            var LanguageInTable = _wait.Until(d => d.FindElement(LanguageInTableRow)).Text;
            var LevelInTable = _wait.Until(d => d.FindElement(LevelInTableRow)).Text;
            ActualLanguageName = LanguageInTable;
            ActualLanguageLevel = LevelInTable;
            ActualPopup = popupmsgActual;
            
        }

        public void ClearData()
        {
            try {   
                var deleteButtons = _driver.FindElements(DeleteLanguages);
                foreach (var button in deleteButtons)
                {
                    button.Click();
                    Thread.Sleep(1000); // Wait for the deletion to process
                }
                Console.WriteLine("All languages deleted successfully.");
            }
            catch (Exception e)
            {
                Assert.Fail("Failed to clear data: " + e);
            }           
        }
        

        public void VerifyAlreadyExistLanguagePopup(out String ActualPopup)
        {           
                var popupmsgActual = _wait.Until(d => d.FindElement(popupmsg)).Text;
                ActualPopup = popupmsgActual;

        }

        public void VerifyDuplicateLanguagePopup(out String ActualPopup)
        {
            var popupmsgActual = _wait.Until(d => d.FindElement(popupmsg)).Text;
            ActualPopup = popupmsgActual;

        }
        public void VerifyEmptyLanguageAndLevelPopup(out String ActualPopup)
        {
            var popupmsgActual = _wait.Until(d => d.FindElement(popupmsg)).Text;
            ActualPopup = popupmsgActual;
            
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
        public void VerifyDeletedLanguageFromTable(String language, out String ActualPopup)
        {
            var popupmsgActual = _wait.Until(d => d.FindElement(popupmsg)).Text;
            ActualPopup = popupmsgActual;
                       
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
                Console.WriteLine("Language edited successfully.");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Failed to delete language from the table.");
            }

        }
      
        public void verifyAddNewButtonNotDisplayed(out bool result)
        {
            try
            {
                var AddNewButtonElement = _wait.Until(ExpectedConditions.ElementIsVisible(AddNewButton));
                bool isDisplayed = AddNewButtonElement.Displayed;
                result = isDisplayed;
            }
            catch (WebDriverTimeoutException)
            {
               result = false;
            }
            

        }


    }
}
