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
        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'НАПИСАТЬ')]")]
        public IWebElement ButtonNewEmail { get; set; }

        [FindsBy(How = How.ClassName, Using = "vO")]
        public IWebElement InputAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@name = 'subjectbox']")]
        public IWebElement InputTheme { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class = 'Am Al editable LW-avf']")]
        public IWebElement InputMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class = 'T-I J-J5-Ji aoO T-I-atl L3']")]
        public IWebElement ButtonSendEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class = 'gb_2a gbii']")]
        public IWebElement ButtonAccount { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Выйти')]")]
        public IWebElement ButtonExit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@email = 'user1spagetti@gmail.com']")]
        public IWebElement OpenMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id = ':5']/div[2]/div[1]/div/div[2]/div[2]/div/div")]
        public IWebElement OpenSpam { get; set; }

        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /*public HomePage newEmail()
        {
            
        }*/

        public void sendEmail(string address, string theme, string message)
        {
            ButtonNewEmail.Click();
            InputAddress.SendKeys(address);
            InputTheme.SendKeys(theme);
            InputMessage.SendKeys(message);
            ButtonSendEmail.Click();
        }

        public PasswordSignInPage exitFromAccount()
        {
            ButtonAccount.Click();
            ButtonExit.Click();
            return new PasswordSignInPage(driver);
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
