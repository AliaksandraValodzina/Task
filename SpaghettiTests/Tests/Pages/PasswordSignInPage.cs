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
        private WebDriverWait wait;

        public PasswordSignInPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public HomePage signIn(string password)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Passwd")));
            InputPassword.SendKeys(password);
            ButtonSubmit.Click();
            return new HomePage(driver);
        }

        public StartPage goToStartPage()
        {
            ButtonToLoginPage.Click();
            return new StartPage(driver);
        }
    }
}