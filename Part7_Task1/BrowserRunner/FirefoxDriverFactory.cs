using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace BrowserRunner
{
    class FirefoxDriverFactory
    {
        private static IWebDriver driver = null;

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = new FirefoxDriver();
            }
            return driver;
        }
    }
}
