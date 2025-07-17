using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace ReqnrollMarsAutomationProject.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public IWebDriver Driver => _driver;

        // Locators
        
             
        private readonly By SignInButton = By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a");
        private readonly By UserNameTextBox = By.Name("email");
        private readonly By PasswordTextBox = By.Name("password");
        private readonly By LoginButton = By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button");


        public HomePage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
        }

        public void ClickSignIn()
        {
           
            var signInElement = _wait.Until(ExpectedConditions.ElementIsVisible(SignInButton));
            signInElement.Click();
        }

        public void Login(String username, string password)
        {
            var usernameElement = _wait.Until(ExpectedConditions.ElementIsVisible(UserNameTextBox));
            usernameElement.SendKeys(username);
            var passwordElement = _wait.Until(ExpectedConditions.ElementIsVisible(PasswordTextBox));
            passwordElement.SendKeys(password);
            var loginElement = _wait.Until(ExpectedConditions.ElementIsVisible(LoginButton));
            loginElement.Click();


        }
    }
         
    
}
