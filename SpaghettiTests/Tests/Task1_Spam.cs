using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System.Configuration;
using Tests.Pages;

namespace Tests
{
    public class Task1_Spam
    {
        private readonly string userNameOne = ConfigurationManager.AppSettings["user1"];
        private readonly string passwordOne = ConfigurationManager.AppSettings["password1"];

        private readonly string userNameTwo = ConfigurationManager.AppSettings["user2"];
        private readonly string passwordTwo = ConfigurationManager.AppSettings["password2"];

        [Test]
        public void test_Spam()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            StartPage startPage = new StartPage(driver);

            // 1.
            // Go to the login form
            LoginSignInPage loginPage = startPage.goToLoginForm();

            // Input login user1 ang go to the next page
            PasswordSignInPage passwordPage = loginPage.loginSignIn(userNameOne);
            
            // Input password user1 ang go to the home page
            HomePage homePage = passwordPage.signIn(passwordOne);

            // 2.
            // Send message to user2
            homePage.sendEmail(userNameTwo + "@gmail.com", "Hello!", "Hello man!");

            // Exit from user1 account
            startPage = homePage.exitFromAccount();

            // 3.
            // Go to the login form
            loginPage = startPage.goToLoginForm();

            // Input login user2 ang go to the next page
            passwordPage = loginPage.loginSignIn(userNameTwo);

            // Input password user2 ang go to the home page
            homePage = passwordPage.signIn(passwordTwo);

            // 4.
            // Mark letter as spam and exit from account
            EmailPage emailPage = homePage.goToMessage();
            homePage = emailPage.addLetterToSpam();
            startPage = homePage.exitFromAccount();

            // 5. 
            // Login user1
            loginPage = startPage.goToLoginForm();
            passwordPage = loginPage.loginSignIn(userNameOne);
            homePage = passwordPage.signIn(passwordOne);

            // 6.
            // Send letter to user2
            homePage.sendEmail(userNameTwo + "@gmail.com", "Hello two!", "Two : Hello man!");
            startPage = homePage.exitFromAccount();

            // 7. Login user2
            loginPage = startPage.goToLoginForm();
            passwordPage = loginPage.loginSignIn(userNameTwo);
            homePage = passwordPage.signIn(passwordTwo);

            // 8. Go to folder: Spam
            SpamPage spamPage = homePage.goToSpam();

        }
    }
}
