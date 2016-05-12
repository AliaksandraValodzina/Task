using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BrowserRunner
{
    public class ChromeDriverFactory
    {
        public static IWebDriver CreateDriver() 
        {
            return new ChromeDriver();
        }
    }
}
