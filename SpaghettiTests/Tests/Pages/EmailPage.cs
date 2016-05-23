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
    public class EmailPage
    {
        [FindsBy(How = How.XPath, Using = "//div[@class = 'asl T-I-J3 J-J5-Ji!']")]
        public IWebElement ButtonSpam { get; set; }

        private IWebDriver driver;
        WebDriverWait wait;

        public EmailPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            PageFactory.InitElements(driver, this);
        }

        public HomePage addLetterToSpam()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class = 'asl T-I-J3 J-J5-Ji']")));
            ButtonSpam.Click();
            return new HomePage(driver);
        }
    }
}
