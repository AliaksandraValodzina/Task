using System;
using System.Configuration;
using OpenQA.Selenium;

namespace BrowserRunner
{
    class WebDriver : IWebDriver
    {
        private static IWebDriver _driver;


        public static IWebDriver GetDriver()
        {
            return _driver;
        }

        static InitWebDriver InitWD()
        {
            switch (ConfigurationManager.AppSettings["browser"])
            {
                case "chrome":
                    _driver = new FirefoxDriver();
                    break;
                case "firefox":
                    _driver = new ChromeDriver();
                    break;
                default:
                    Console.WriteLine("Do not valid value in config file");
            }
            return _driver;
        }
    }
}
