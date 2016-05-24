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

        [FindsBy(How = How.XPath, Using = "//a[@class = 'gb_b gb_8a gb_R']/span")]
        public IWebElement ButtonAccount { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Выйти')]")]
        public IWebElement ButtonExit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@email = 'user1spagetti@gmail.com']")]
        public IWebElement OpenMessage { get; set; }

        [FindsBy(How = How.Id, Using = "gbqfq")]
        public IWebElement SearchField { get; set; }

        [FindsBy(How = How.Id, Using = "gbqfb")]
        public IWebElement ButtonFind { get; set; }

        [FindsBy(How = How.XPath, Using = "//tr[1]/td/div/div[@class = 'T-Jo-auh']")]
        public IWebElement PickOutMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'T-I J-J5-Ji nN T-I-ax7 T-I-Js-Gs T-I-Js-IF ar7']")]
        public IWebElement ButtonSpam { get; set; }

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
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class = 'gb_b gb_8a gb_R']/span")));
            ButtonAccount.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(), 'Выйти')]")));
            ButtonExit.Click();

            this.checkAlert();

            return new PasswordSignInPage(driver);
        }

        public StartPage exitFromAccountToStartPage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class = 'gb_b gb_8a gb_R']/span")));
            ButtonAccount.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(), 'Выйти')]")));
            ButtonExit.Click();

            this.checkAlert();

            return new StartPage(driver);
        }

        public void checkAlert()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public HomePage addToSpam()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[1]/td/div/div[@class = 'T-Jo-auh']")));
            PickOutMessage.Click();
            ButtonSpam.Click();
            return new HomePage(driver);
        }

        public SpamPage goToSpam()
        {
            SearchField.SendKeys("in:spam");
            ButtonFind.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(), 'Hello!')")));
            
            return new SpamPage(driver);
        }
    }
}
