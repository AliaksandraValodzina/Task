using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Tests.Pages
{
    public class LoginSignInPage
    {
        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement InputLogin { get; set; }

        [FindsBy(How = How.Id, Using = "next")]
        public IWebElement ButtonSubmit { get; set; }

        private IWebDriver driver;

        public LoginSignInPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public PasswordSignInPage loginSignIn(string username)
        {
            InputLogin.SendKeys(username);
            ButtonSubmit.Click();
            return new PasswordSignInPage(driver);
        }
    }
}
