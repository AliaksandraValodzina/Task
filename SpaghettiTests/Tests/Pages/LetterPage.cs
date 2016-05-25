using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Tests.Pages
{
    public class LetterPage
    {
        private IWebDriver driver;

        public LetterPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'mail-settings.google.com')]")]
        private IWebElement PathConfirmForward { get; set; }

        [FindsBy(How = How.XPath, Using = "//p/input[@value = 'Confirm')]")]
        private IWebElement ButtonConfirm { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class = 'gb_b gb_8a gb_R']/span")]
        private IWebElement ButtonAccount { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Sign out')]")]
        private IWebElement ButtonExit { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'ar6 T-I-J3 J-J5-Ji']")]
        private IWebElement ButtonBackToInbox { get; set; }

        public void ConfirmForwardFromUser()
        {
            PathConfirmForward.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            ButtonConfirm.Click();
            driver.SwitchTo().Window(driver.WindowHandles.First());
            ButtonBackToInbox.Click();
        }
    }
}
