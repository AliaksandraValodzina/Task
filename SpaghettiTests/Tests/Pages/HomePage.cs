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
    public class HomePage
    {
        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'НАПИСАТЬ')]")]
        public IWebElement ButtonNewEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class = 'vO']")]
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

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Спам')]")]
        public IWebElement OpenSpam { get; set; }

        private IWebDriver driver;
        WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            PageFactory.InitElements(driver, this);
        }

        public void sendEmail(string address, string theme, string message)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(), 'НАПИСАТЬ')]")));
            ButtonNewEmail.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class = 'T-I J-J5-Ji aoO T-I-atl L3']")));
            InputAddress.SendKeys(address);
            InputTheme.SendKeys(theme);
            InputMessage.SendKeys(message);
            ButtonSendEmail.Click();
        }

        public PasswordSignInPage exitFromAccount()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class = 'gb_2a gbii']")));
            ButtonAccount.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class = 'gb_Ea gb_Be gb_Je gb_qb']")));
            ButtonExit.Click();
            IAlert popUp = driver.SwitchTo().Alert();
            if (popUp.Text.Contains("Эта страница просит вас подтвердить, что вы хотите уйти — при этом введённые вами данные могут не сохраниться."))
            {
                popUp.Accept();
            }
            return new PasswordSignInPage(driver);
        }

        public EmailPage goToMessage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@email = 'user1spagetti@gmail.com']")));
            OpenMessage.Click();
            return new EmailPage(driver);
        }

        public SpamPage goToSpam()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(), 'Спам')]")));
            OpenSpam.Click();
            return new SpamPage(driver);

        }
    }
}
