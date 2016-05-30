using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Tests.Messages;
using Tests.Pages;

namespace Tests.Steps
{
    public class Step
    {
        private IWebDriver driver;
        WebDriverWait wait;

        public Step(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            PageFactory.InitElements(driver, this);
        }

        // Login as user
        public void Login(User user)
        {
            PasswordSignInPage passwordPage;
            StartPage startPage = new StartPage(driver);
            LoginSignInPage loginPage = new LoginSignInPage(driver);

            if (driver.FindElements(By.Id("account-chooser-link")).Count > 0)
            {
                passwordPage = new PasswordSignInPage(driver);
                startPage = passwordPage.goToStartPage();
            }
            if (driver.FindElements(By.Id("account-chooser-add-account")).Count > 0)
            {
                loginPage =  startPage.goToLoginForm();
            }

            passwordPage = loginPage.loginSignIn(user.Email);
            HomePage homePage = passwordPage.signIn(user.Password);
        }

        // Send message
        public void SendMessage(Letter message)
        {
            HomePage homePage = new HomePage(driver);
            homePage.SendEmail(message);
        }

        // Exit from account
        public void Exit()
        {
            if (driver.FindElements(By.XPath("//*[@class = 'aKz']")).Count > 0)
            {
                HomePage homePage = new HomePage(driver);
                PasswordSignInPage passwordPage = homePage.ExitFromAccount();
            } 
            if (driver.FindElements(By.XPath("//a[contains(text(), 'Forwarding and POP/IMAP')]")).Count > 0)
            {
                SettingsPage settingPage = new SettingsPage(driver);
                settingPage.ExitFromAccount();
            }
        }

        // Add message to spam
        public void AddToSpam()
        {
            HomePage homePage = new HomePage(driver);
            homePage = homePage.AddToSpam();
        }

        // Go to spam
        public void GoToSpam()
        {
            HomePage homePage = new HomePage(driver);
            homePage = homePage.GoToSpam();
        }

        // Find message
        public int CountMessagesByOneEmail(User user)
        {
            var spamMessages = driver.FindElements(By.XPath($"//div/span[@email = '{user.Email}@gmail.com')]"));
            var countMessages = spamMessages.Count;
            return countMessages;
        }

        // Go to forward page
        public void GoToSettings()
        {
            HomePage homePage = new HomePage(driver);
            SettingsPage settingsPage = homePage.GoToSettings();
            //settingsPage.GoToForwardPage();
        }

        // Forward to user
        public void ForwardToUser(User user)
        {
            SettingsPage settingsPage = new SettingsPage(driver);
            settingsPage.AddForwardingAddress(user);
        }

        // Accept forward
        public void ConfirmForward()
        {
            HomePage homePage = new HomePage(driver);
            LetterPage letterPage = homePage.ChooseLastLetter();
            letterPage.ConfirmForwardFromUser();
        }

        // Create Filter
        public void CreateFilter(User user)
        {
            SettingsPage settingsPage = new SettingsPage(driver);
            settingsPage.CreateFilter(user);
        }
    }
}
