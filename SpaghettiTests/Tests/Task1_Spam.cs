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

namespace Tests
{
    [TestClass]
    public class Task1_Spam
    {
        IWebDriver driver;

        public string userNameOne = ConfigurationManager.AppSettings["user1"];
        public string passwordOne = ConfigurationManager.AppSettings["password1"];

        public string userNameTwo = ConfigurationManager.AppSettings["user2"];
        public string passwordTwo = ConfigurationManager.AppSettings["password2"];


        [TestInitialize]
        public void Setup()
        {
            driver = new FirefoxDriver();
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void test_Spam()
        {
            driver.Navigate().GoToUrl("http://gmail.com/");
            LoginSignInPage loginPage = new LoginSignInPage(driver);

            // 1.Login as registred user1
            PasswordSignInPage passwordPage = loginPage.loginSignIn(userNameOne);
            HomePage homePage = passwordPage.signIn(passwordOne);

            // 2. Send message to user2
            string email = userNameTwo + "@gmail.com";
            homePage.sendEmail(email, "Hello!", "Hello world!");
            passwordPage = homePage.exitFromAccount();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // 3. Login as registred user2
            StartPage startPage = passwordPage.goToStartPage();
            loginPage = startPage.goToLoginForm();
            passwordPage = loginPage.loginSignIn(userNameTwo);
            homePage = passwordPage.signIn(passwordTwo);

            // 4. Mark letter as spam 
            EmailPage emailPage = homePage.goToMessage();
            homePage = emailPage.addLetterToSpam();
            passwordPage = homePage.exitFromAccount();

            // 5. Login user1
            loginPage = startPage.goToLoginForm();
            passwordPage = loginPage.loginSignIn(userNameOne);
            homePage = passwordPage.signIn(passwordOne);

            // 6. Send letter to user2
            /*homePage.sendEmail(userNameTwo + "@gmail.com", "Hello two!", "Two : Hello man!");
            startPage = homePage.exitFromAccount();

            // 7. Login user2
            loginPage = startPage.goToLoginForm();
            passwordPage = loginPage.loginSignIn(userNameTwo);
            homePage = passwordPage.signIn(passwordTwo);

            // 8. Go to folder: Spam
            SpamPage spamPage = homePage.goToSpam();*/

        }
    }
}
