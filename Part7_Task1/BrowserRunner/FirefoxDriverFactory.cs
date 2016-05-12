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
        public static IWebDriver CreateDriver()
        {
            return new FirefoxDriver();
        }
    }
}
