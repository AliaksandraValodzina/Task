using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.Messages;
using Tests.Pages;

namespace Tests.Steps
{
    public class Step
    {
        private IWebDriver driver;

        public Step(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Login as user
        public void Login(User user)
        {
            driver.Navigate().GoToUrl("http://gmail.com/");
            LoginSignInPage loginPage = new LoginSignInPage(driver);
            PasswordSignInPage passwordPage = loginPage.loginSignIn(user.Email);
            HomePage homePage = passwordPage.signIn(user.Password);
        }

        // Send message
        public void SendMessage(Message message)
        {
            HomePage homePage = new HomePage(driver);
            homePage.SendEmail(message);
        }

        // Exit from account
        public void Exit()
        {
            HomePage homePage = new HomePage(driver);
            PasswordSignInPage passwordPage = homePage.ExitFromAccount();
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

        // Forward to user(
        public void ForwardToUser(User user)
        {
            HomePage homePage = new HomePage(driver);
            SettingsPage settingsPage = homePage.GoToSettings();
            settingsPage.AddForwardingAddress(user);
        }

        // Accept forward
        public void AcceptForward()
        {
            HomePage homePage = new HomePage(driver);
            LetterPage letterPage = homePage.ChooseLastLetter();
            letterPage.ConfirmForwardFromUser();
        }

    




    }
}
