using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Tests.Pages
{
    public class HomePage
    {
        [FindsBy(How = How.ClassName, Using = "T-I J-J5-Ji T-I-KE L3")]
        public IWebElement ButtonNewEmail { get; set; }

        [FindsBy(How = How.ClassName, Using = "vO")]
        public IWebElement InputAddress { get; set; }

        [FindsBy(How = How.ClassName, Using = "aoT")]
        public IWebElement InputTheme { get; set; }

        [FindsBy(How = How.ClassName, Using = "Am Al editable LW-avf")]
        public IWebElement InputMessage { get; set; }

        [FindsBy(How = How.ClassName, Using = "T-I J-J5-Ji aoO T-I-atl L3")]
        public IWebElement ButtonSendEmail { get; set; }

        [FindsBy(How = How.ClassName, Using = "gb_Ea gb_te gb_Ae gb_qb")]
        public IWebElement ButtonExit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@email = 'user1spagetti@gmail.com']")]
        public IWebElement OpenMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@title = 'Спам']")]
        public IWebElement OpenSpam { get; set; }

        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void sendEmail(string address, string theme, string message)
        {
            ButtonNewEmail.Click();
            InputAddress.SendKeys(address);
            InputTheme.SendKeys(theme);
            InputMessage.SendKeys(message);
            ButtonSendEmail.Click();
        }

        public StartPage exitFromAccount()
        {
            ButtonExit.Click();
            return new StartPage(driver);
        }

        public EmailPage goToMessage()
        {
            OpenMessage.Click();
            return new EmailPage(driver);
        }

        public SpamPage goToSpam()
        {
            OpenSpam.Click();
            return new SpamPage(driver);

        }
    }
}
