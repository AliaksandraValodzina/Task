using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Tests.Pages
{
    public class SettingsPage : BasePage
    {
        private IWebDriver driver;

        public SettingsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@class = 'f0 ou']")]
        private IWebElement InsetForward { get; set; }

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

        public void GoToForwardPage()
        {
            InsetForward.Click();
        }

        public void AddForwardingAddress(User user)
        {
            ButtonAddForwardAddress.Click();
            FieldAddForwardAddress.SendKeys(user.Email + "@gmail.com");
            ButtonNext.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            ButtonProceed.Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        public void CreateFilter(User user)
        {
            RadioButtonForwardACopy.Click();
            ButtonNewFilter.Click();
            FieldAddForwardAddress.SendKeys(user.Email + "@gmail.com");
            CheckboxHasAttachment.Click();
            CreateFilterWithSearch.Click();
            CheckboxDeleteIt.Click();
            CheckboxMarkAsImportant.Click();
            ButtonCreateFilter.Click();
        }

        public void ExitFromAccount()
        {
            ButtonAccount.Click();
            ButtonExit.Click();
        }
    }
}
