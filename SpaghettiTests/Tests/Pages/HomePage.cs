using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Tests.Messages;

namespace Tests.Pages
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'COMPOSE')]")]
        private IWebElement ButtonNewEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class = 'vO']")]
        private IWebElement InputAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@name = 'subjectbox']")]
        private IWebElement InputTheme { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class = 'Am Al editable LW-avf']")]
        private IWebElement InputText { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class = 'T-I J-J5-Ji aoO T-I-atl L3']")]
        private IWebElement ButtonSendEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class = 'gb_b gb_8a gb_R']/span")]
        private IWebElement ButtonAccount { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Sign out')]")]
        private IWebElement ButtonExit { get; set; }

        /*[FindsBy(How = How.XPath, Using = "//*[@email = 'user1spagetti@gmail.com']")]
        private IWebElement OpenMessage { get; set; }*/

        [FindsBy(How = How.Id, Using = "gbqfq")]
        private IWebElement SearchField { get; set; }

        [FindsBy(How = How.Id, Using = "gbqfb")]
        private IWebElement ButtonFind { get; set; }

        [FindsBy(How = How.XPath, Using = "//tr[1]/td/div/div[@class = 'T-Jo-auh']")]
        private IWebElement PickOutMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'T-I J-J5-Ji nN T-I-ax7 T-I-Js-Gs T-I-Js-IF ar7']")]
        private IWebElement ButtonSpam { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'aos T-I-J3 J-J5-Ji']")]
        private IWebElement ButtonSetting { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id = 'ms']/div[contains(text(), 'Settings')]")]
        private IWebElement ItemSettingInMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "//tr[@class = 'zA zE'][1]")]
        private IWebElement LastLetter { get; set; }

        

        private IWebDriver driver;
        WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            PageFactory.InitElements(driver, this);
        }

        public void SendEmail(Message message)
        {
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(), 'COMPOSE')]")));
            ButtonNewEmail.Click();
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class = 'T-I J-J5-Ji aoO T-I-atl L3']")));
            InputAddress.SendKeys(message.Recipient);
            InputTheme.SendKeys(message.Theme);
            InputText.SendKeys(message.TextForRecipient);
            ButtonSendEmail.Click();
        }

        public PasswordSignInPage ExitFromAccount()
        {
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class = 'gb_b gb_8a gb_R']/span")));
            ButtonAccount.Click();
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(), 'Sign out')]")));
            ButtonExit.Click();

            this.AsseptAlertIfExist();

            return new PasswordSignInPage(driver);
        }

        public StartPage exitFromAccountToStartPage()
        {
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class = 'gb_b gb_8a gb_R']/span")));
            ButtonAccount.Click();
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(), 'Выйти')]")));
            ButtonExit.Click();

            this.AsseptAlertIfExist();

            return new StartPage(driver);
        }

        public void AsseptAlertIfExist()
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

        public HomePage AddToSpam()
        {
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[1]/td/div/div[@class = 'T-Jo-auh']")));
            PickOutMessage.Click();
            ButtonSpam.Click();
            return new HomePage(driver);
        }

        public HomePage GoToSpam()
        {
            SearchField.SendKeys("in:spam");
            ButtonFind.Click();
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(), 'Hello!')")));
            
            return new HomePage(driver);
        }

        public SettingsPage GoToSettings()
        {
            ButtonSetting.Click();
            ItemSettingInMenu.Click();
            return new SettingsPage(driver);
        }

        public LetterPage ChooseLastLetter()
        {
            LastLetter.Click();
            return new LetterPage(driver);
        }
    }
}
