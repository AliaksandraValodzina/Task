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
    public class StartPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "account-chooser-add-account")]
        private IWebElement ButtonGoToAccount { get; set; }

        private IWebDriver driver;
        WebDriverWait wait;

        public StartPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            PageFactory.InitElements(driver, this);
        }

        public LoginSignInPage goToLoginForm()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("account-chooser-add-account")));
            ButtonGoToAccount.Click();
            return new LoginSignInPage(driver);
        }
    }
}
