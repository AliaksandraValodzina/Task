using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;

namespace Part10_Nuget_MSTest
{
    public class BrowserController
    {
        public string BrowserStatus { get; private set; }

        public IWebDriver Driver { get; set; }
        public string Path { get; set; }

        public void Setup()
        {
            Driver.Navigate().GoToUrl(Path);
            BrowserStatus = "on";
        }

        public void TearDown()
        {
            Thread.Sleep(2000);
            Driver.Quit();
            BrowserStatus = "off";
        }
    }
}
