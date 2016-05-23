using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Tests.Pages
{
    public class LoginSignInPage
    {
        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement InputLogin { get; set; }

        [FindsBy(How = How.Id, Using = "next")]
        public IWebElement ButtonSubmit { get; set; }

        private IWebDriver driver;
        WebDriverWait wait;

        public LoginSignInPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            PageFactory.InitElements(driver, this);
        }

        public PasswordSignInPage loginSignIn(string username)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            InputLogin.SendKeys(username);
            ButtonSubmit.Click();
            return new PasswordSignInPage(driver);
        }
    }
}
