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
            Letter message = new Letter(userOne.Email + "@gmail.com", userTwo.Email + "@gmail.com", "First message", "Hello!");
            step.SendLetter(message);
            step.Exit();

            step.Login(userTwo);
            step.AddToSpam();
            step.Exit();

            step.Login(userOne);
            message = new Letter(userOne.Email + "@gmail.com", userTwo.Email + "@gmail.com", "Second message", "Hello!");
            step.SendLetter(message);
            step.Exit();

            step.Login(userTwo);
            step.GoToSpam();
            Assert.IsTrue(step.CountMessagesByTheme(message) > 1);
        }

        [TestMethod]
        public void TestForward()
        {
            step.Login(userTwo);
            step.GoToSettings();
            step.ForwardToUser(userThree);
            step.Exit();

            step.Login(userThree);
            step.ConfirmForward();
            step.Exit();

            step.Login(userTwo);
            step.GoToSettings();
            step.CreateFilter(userOne);
            step.Exit();

            step.Login(userOne);
            Letter messageWithAttachFile = new Letter(userOne.Email + "@gmail.com", userTwo.Email + "@gmail.com", "Message with attache file", "", ConfigurationManager.AppSettings["attachFile"]);
            step.SendLetter(messageWithAttachFile);
            Letter message = new Letter(userOne.Email + "@gmail.com", userTwo.Email + "@gmail.com", "Message without attache file", "Hello!");
            step.SendLetter(message);
            step.Exit();

            step.Login(userTwo);
            // 18. Check a letter without attach
            Assert.IsTrue(step.CountMessagesByTheme(message) > 0);
            // 17. Check a letter with attach
            step.GoToTrash();
            Assert.IsTrue(step.CountMessagesByTheme(messageWithAttachFile) > 0);
            step.GoToImportant();
            Assert.IsTrue(step.CountMessagesByTheme(messageWithAttachFile) > 0);
            step.Exit();
        }
    }
}
