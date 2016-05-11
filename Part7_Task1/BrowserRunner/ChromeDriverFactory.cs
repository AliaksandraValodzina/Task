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
        private static IWebDriver driver = null;

        public static IWebDriver GetDriver() 
        {
            if(driver == null)
            {
                driver = new ChromeDriver();
            }
            return driver;
        }
    }
}
