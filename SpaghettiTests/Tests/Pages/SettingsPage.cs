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

        public void AddForwardingAddress(User user)
        {
            InsetForward.Click();
            ButtonAddForwardAddress.Click();
            FieldAddForwardAddress.SendKeys(user.Email + "@gmail.com");
            ButtonNext.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            ButtonProceed.Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }
    }
}
