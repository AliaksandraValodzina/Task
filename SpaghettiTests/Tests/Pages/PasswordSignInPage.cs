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
    public class PasswordSignInPage
    {
        [FindsBy(How = How.Id, Using = "Passwd")]
        public IWebElement InputPassword { get; set; }

        [FindsBy(How = How.Id, Using = "signIn")]
        public IWebElement ButtonSubmit { get; set; }

        [FindsBy(How = How.Id, Using = "account-chooser-link")]
        public IWebElement ButtonToLoginPage { get; set; }

        private IWebDriver driver;
        WebDriverWait wait;

        public PasswordSignInPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            PageFactory.InitElements(driver, this);
        }

        public HomePage signIn(string password)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Passwd")));
            InputPassword.SendKeys(password);
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("signIn")));
            ButtonSubmit.Click();

            return new HomePage(driver);
        }

        public StartPage goToStartPage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("account-chooser-link")));
            ButtonToLoginPage.Click();
            return new StartPage(driver);
        }
    }
}