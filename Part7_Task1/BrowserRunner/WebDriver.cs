using System;
using System.Configuration;

namespace BrowserRunner
{
    class WebDriver : IWebDriver
    {
        private static InitWebDriver _driver = new InitWebDriver();


        public static InitWebDriver GetDriver()
        {
            return _driver;
        }

        static InitWebDriver InitWD()
        {
            switch (ConfigurationManager.AppSettings["browser"])
            {

            }
            return _driver;
        }
    }
}
