using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace BrowserRunner
{
    public class WebDriver
    {
        private static IWebDriver _driver = InitWebDriver();

        private WebDriver()
        {
        }

        public static IWebDriver GetDriver()
        {
            return _driver;
        }

        public static IWebDriver InitWebDriver()
        {
                switch (ConfigurationManager.AppSettings["browser"])
                {
                    case "firefox":
                        return FirefoxDriverFactory.CreateDriver();
                        break;
                    case "chrome":
                        return ChromeDriverFactory.CreateDriver();
                        break;
                    default:
                        return FirefoxDriverFactory.CreateDriver();
                        break;
                }
        }

    }

    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Test()
        {
            IWebDriver driver = WebDriver.InitWebDriver();
            driver.Navigate().GoToUrl("http://www.google.com/");
        }

        [TestMethod]
        public void TestClose()
        {
            IWebDriver driver = WebDriver.InitWebDriver();
            driver.Navigate().GoToUrl("http://www.google.com/");
            driver.Quit();

        }
    }
}
