using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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

        [FindsBy(How = How.XPath, Using = "//div[@class = 'a1 aaA aMZ']")]
        private IWebElement AddAttachFile { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'T-I J-J5-Ji aoO T-I-atl L3']")]
        private IWebElement ButtonSendEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class = 'gb_b gb_8a gb_R']/span")]
        private IWebElement ButtonAccount { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Sign out')]")]
        private IWebElement ButtonExit { get; set; }

        [FindsBy(How = How.Id, Using = "gbqfq")]
        private IWebElement SearchField { get; set; }

        [FindsBy(How = How.Id, Using = "gbqfb")]
        private IWebElement ButtonFind { get; set; }

        [FindsBy(How = How.XPath, Using = "//tr[1]/td/div/div[@class = 'T-Jo-auh']")]
        private IWebElement PickOutMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'T-I J-J5-Ji nN T-I-ax7 T-I-Js-Gs T-I-Js-IF ar7']")]
        private IWebElement ButtonSpam { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'T-I J-J5-Ji ash T-I-ax7 L3']")]
        private IWebElement ButtonSetting { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id = 'ms']")]
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

        public void SendEmail(Letter letter)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(), 'COMPOSE')]")));
            ButtonNewEmail.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class = 'vO']")));
            InputAddress.SendKeys(letter.Recipient);
            InputTheme.SendKeys(letter.Theme);
            InputText.SendKeys(letter.TextForRecipient);

            if(!letter.PathToAttachFile.Equals("NoPath"))
            {
                AddAttachFile.Click();
                SendKeys.SendWait(ConfigurationManager.AppSettings["attachFile"]);
                SendKeys.SendWait("{Enter}");
            }

            ButtonSendEmail.Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//*[@class = 'T-I J-J5-Ji aoO T-I-atl L3']")));
        }

        public PasswordSignInPage ExitFromAccount()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class = 'gb_b gb_8a gb_R']/span")));
            ButtonAccount.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(), 'Sign out')]")));
            ButtonExit.Click();

            this.AsseptAlertIfExist();

            return new PasswordSignInPage(driver);
        }

        public StartPage exitFromAccountToStartPage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class = 'gb_b gb_8a gb_R']/span")));
            ButtonAccount.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(), 'Выйти')]")));
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
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[1]/td/div/div[@class = 'T-Jo-auh']")));
            PickOutMessage.Click();
            ButtonSpam.Click();
            return new HomePage(driver);
        }

        public HomePage GoToTrash()
        {
            SearchField.SendKeys("in:trash");
            ButtonFind.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), 'Empty Bin now')]")));
            return new HomePage(driver);
        }

        public HomePage GoToImportant()
        {
            SearchField.SendKeys("is:important");
            ButtonFind.Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//*[contains(text(), 'Empty Bin now')]")));
            return new HomePage(driver);
        }

        public HomePage GoToSpam()
        {
            SearchField.SendKeys("in:spam");
            ButtonFind.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(), 'Hello!')]")));
            return new HomePage(driver);
        }

        public SettingsPage GoToSettings()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class = 'T-I J-J5-Ji ash T-I-ax7 L3']")));
            new Actions(driver).MoveToElement(ButtonSetting).ClickAndHold().MoveToElement(ItemSettingInMenu).Release().Perform();
            return new SettingsPage(driver);
        }

        public LetterPage ChooseLastLetter()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@class = 'zA zE'][1]")));
            LastLetter.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class = 'a3s aXjCH m154f247995ab133c']/a][4]")));
            return new LetterPage(driver);
        }
    }
}
