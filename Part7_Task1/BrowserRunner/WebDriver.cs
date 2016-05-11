using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace BrowserRunner
{
    public class SingletonFactory
    {
        private static IWebDriver _driver = InitWebDriver();

        private SingletonFactory()
        {
        }

        public static IWebDriver InitWebDriver()
        {
            if (_driver == null)
            {
                switch (ConfigurationManager.AppSettings["browser"])
                {
                    case "firefox":
                        _driver = FirefoxDriverFactory.GetDriver();
                        break;
                    case "chrome":
                        _driver = ChromeDriverFactory.GetDriver();
                        break;
                    default:
                        _driver = FirefoxDriverFactory.GetDriver();
                        break;
                }
            }

            return _driver;
        }
    }

    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Test()
        {
            IWebDriver driver = SingletonFactory.InitWebDriver();
            driver.Navigate().GoToUrl("http://www.google.com/");
        }

        [TestMethod]
        public void TestClose()
        {
            IWebDriver driver = SingletonFactory.InitWebDriver();
            driver.Navigate().GoToUrl("http://www.google.com/");
            driver.Quit();

        }
    }
}
