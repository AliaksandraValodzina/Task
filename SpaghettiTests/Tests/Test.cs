using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using Tests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using Tests.Messages;
using Tests.Steps;

namespace Tests
{
    [TestClass]
    public class Test
    {
        IWebDriver driver;
        Step step;

        /*private string userNameOne = ConfigurationManager.AppSettings["user1"];
        private string passwordOne = ConfigurationManager.AppSettings["password1"];

        private string userNameTwo = ConfigurationManager.AppSettings["user2"];
        private string passwordTwo = ConfigurationManager.AppSettings["password2"];*/

        User userOne = new User(ConfigurationManager.AppSettings["user1"], ConfigurationManager.AppSettings["password1"]);
        User userTwo = new User(ConfigurationManager.AppSettings["user2"], ConfigurationManager.AppSettings["password2"]);
        User userThree = new User(ConfigurationManager.AppSettings["user3"], ConfigurationManager.AppSettings["password3"]);

        [TestInitialize]
        public void Setup()
        {
            /*driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(20));
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(30));
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));*/

            driver = new FirefoxDriver();
            step = new Step(driver);
            driver.Navigate().GoToUrl("http://gmail.com/");
        }

        [TestCleanup]
        public void Teardown()
        {
            //driver.Quit();
        }

        [TestMethod]
        [Ignore]
        public void TestSpam()
        {
            step.Login(userOne);
            Letter message = new Letter(userTwo.Email + "gmail.com", "First message", "Hello!");
            step.SendMessage(message);
            step.Exit();

            step.Login(userTwo);
            step.AddToSpam();
            step.Exit();

            step.Login(userOne);
            message = new Letter(userTwo.Email + "gmail.com", "Second message", "Hello!");
            step.SendMessage(message);
            step.Exit();

            step.Login(userTwo);
            step.GoToSpam();
            Assert.IsTrue(step.CountMessagesByOneEmail(userOne) > 1);

            /*driver.Navigate().GoToUrl("http://gmail.com/");
            LoginSignInPage loginPage = new LoginSignInPage(driver);

            // 1.Login as registred user1
            PasswordSignInPage passwordPage = loginPage.loginSignIn(userNameOne);
            HomePage homePage = passwordPage.signIn(passwordOne);

            // 2. Send message to user2
            string email = userNameTwo + "@gmail.com";
            homePage.sendEmail(email, "Hello!", "Hello world!");
            passwordPage = homePage.exitFromAccount();

            // 3. Login as registred user2
            StartPage startPage = passwordPage.goToStartPage();
            loginPage = startPage.goToLoginForm();
            passwordPage = loginPage.loginSignIn(userNameTwo);
            homePage = passwordPage.signIn(passwordTwo);

            // 4. Mark letter as spam 
            homePage = homePage.addToSpam();
            startPage = homePage.exitFromAccountToStartPage();

            // 5. Login user1
            //startPage = passwordPage.goToStartPage();
            loginPage = startPage.goToLoginForm();
            passwordPage = loginPage.loginSignIn(userNameOne);
            homePage = passwordPage.signIn(passwordOne);

            // 6. Send letter to user2
            Message message = new Message();
            homePage.sendEmail(userNameTwo + "@gmail.com", "Hello two!", "Two : Hello man!");
            startPage = homePage.exitFromAccountToStartPage();

            // 7. Login user2
            loginPage = startPage.goToLoginForm();
            passwordPage = loginPage.loginSignIn(userNameTwo);
            homePage = passwordPage.signIn(passwordTwo);

            // 8. Go to folder: Spam
            homePage = homePage.goToSpam();
            var spamMessages = driver.FindElements(By.XPath("//*[contains(text(), 'Вова Макаров')]"));
            Assert.IsTrue(spamMessages.Count > 1);*/
        }

        [TestMethod]
        public void TestForward()
        {
            /*step.Login(userTwo);
            step.GoToSettings();
            step.ForwardToUser(userThree);
            step.Exit();

            step.Login(userThree);
            step.ConfirmForward();
            step.Exit();

            step.Login(userTwo);
            step.GoToSettings();
            step.CreateFilter(userOne);
            step.Exit();*/

            step.Login(userOne);
            Letter messageWithAttachFile = new Letter(userTwo.Email + "gmail.com", "Message with attache file", "", ConfigurationManager.AppSettings["attachFile"]);
            step.SendMessage(messageWithAttachFile);
            Letter message = new Letter(userTwo.Email + "gmail.com", "Message without attache file", "Hello!");
            step.SendMessage(message);
            step.Exit();
        }
    }
}
