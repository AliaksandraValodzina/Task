using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Tests.Pages;

namespace Tests.Pages
{
    public class SettingsPage : BasePage
    {
        private IWebDriver driver;
        WebDriverWait wait;

        public SettingsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Forwarding and POP/IMAP')]")]
        private IWebElement InsetForward { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Filters and Blocked Addresses')]")]
        private IWebElement FiltersAndBlockedAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value = 'Add a forwarding address']")]
        private IWebElement ButtonAddForwardAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'PN']/input")]
        private IWebElement FieldAddForwardAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class = 'J-at1-auR']")]
        private IWebElement ButtonNext { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value = 'Proceed']")]
        private IWebElement ButtonProceed { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name = 'sx_em'][@value = '1']")]
        private IWebElement RadioButtonForwardACopy { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class = 'sA'][contains(text(), 'Create a new filter')]")]
        private IWebElement ButtonNewFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class = 'ZH nr aQa']")]
        private IWebElement FieldFilterFrom { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class = 'w-Pv ZG']/input")]
        private IWebElement CheckboxHasAttachment { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'acM']")]
        private IWebElement CreateFilterWithSearch { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Delete it')]")]
        private IWebElement CheckboxDeleteIt { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Always mark it as important')]")]
        private IWebElement CheckboxMarkAsImportant { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'Create filter')]")]
        private IWebElement ButtonCreateFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class = 'gb_b gb_8a gb_R']/span")]
        private IWebElement ButtonAccount { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Sign out')]")]
        private IWebElement ButtonExit { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class = 'J-at1-auR']")]
        private IWebElement ButtonOk { get; set; }

        public void AddForwardingAddress(User user)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(), 'Forwarding and POP/IMAP')]")));
            InsetForward.Click();
            ButtonAddForwardAddress.Click();
            FieldAddForwardAddress.SendKeys(user.Email + "@gmail.com");
            ButtonNext.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@value = 'Proceed']")));
            ButtonProceed.Click();
            driver.SwitchTo().Window(driver.WindowHandles.First());
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@class = 'J-at1-auR']")));
            ButtonOk.Click();
        }

        public void CreateFilter(User user)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(), 'Forwarding and POP/IMAP')]")));
            FiltersAndBlockedAddress.Click();
            ButtonNewFilter.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@class = 'ZH nr aQa']")));
            FieldFilterFrom.SendKeys(user.Email + "@gmail.com");
            CheckboxHasAttachment.Click();
            CreateFilterWithSearch.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[contains(text(), 'Delete it')]")));
            CheckboxDeleteIt.Click();
            CheckboxMarkAsImportant.Click();
            ButtonCreateFilter.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class = 'gb_b gb_8a gb_R']/span")));
        }

        public void ExitFromAccount()
        {
            ButtonAccount.Click();
            ButtonExit.Click();
        }
    }
}
