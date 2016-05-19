using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Tests.Pages
{
    public class PasswordSignInPage
    {
        [FindsBy(How = How.Id, Using = "Passwd")]
        public IWebElement InputPassword { get; set; }

        [FindsBy(How = How.Name, Using = "signIn")]
        public IWebElement ButtonSubmit { get; set; }

        private IWebDriver driver;

        public PasswordSignInPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public HomePage signIn(string password)
        {
            InputPassword.SendKeys(password);
            ButtonSubmit.Click();
            return new HomePage(driver);
        }
    }
}