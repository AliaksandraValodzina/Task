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
    public class LetterPage
    {
        private IWebDriver driver;
        WebDriverWait wait;

        public LetterPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'ii gt adP adO']/div/a[4]")]
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
            string currentWindow = driver.CurrentWindowHandle;
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class = 'ii gt adP adO']/div/a[4]")));
            PathConfirmForward.Click();
            foreach (String window in driver.WindowHandles)
            {
                if (window.Contains("Confirmation"))
                {
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p/input[@value = 'Confirm')]")));
                    ButtonConfirm.Click();
                }
            }
            driver.SwitchTo().Window(currentWindow);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class = 'ar6 T-I-J3 J-J5-Ji']")));
            ButtonBackToInbox.Click();
        }
    }
}
