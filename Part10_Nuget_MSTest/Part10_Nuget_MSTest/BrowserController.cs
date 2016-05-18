using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Part10_Nuget_MSTest
{
    public class BrowserController
    {
        public IWebDriver Driver { get; set; }
        public string Path { get; set; }

        public void Setup()
        {
            Driver.Navigate().GoToUrl(Path);
        }

        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
