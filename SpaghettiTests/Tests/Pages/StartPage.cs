using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Tests.Pages
{
    public class StartPage
    {
        [FindsBy(How = How.Id, Using = "account-chooser-add-account")]
        public IWebElement ButtonGoToAccount { get; set; }

        private IWebDriver driver;

        public StartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public LoginSignInPage goToLoginForm()
        {
            ButtonGoToAccount.Click();
            return new LoginSignInPage(driver);
        }
    }
}
