using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using Part10_Nuget_MSTest;

namespace MsTest
{
    [TestClass]
    public class MsTest
    {
        private static BrowserController controller;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            controller = new BrowserController();
            controller.Driver = new FirefoxDriver();
            controller.Path = "http://www.google.com/";
        }

        [TestMethod]
        public void TestMethodSetUp()
        {
            controller.Setup();
        }

        [TestMethod]
        public void TestMethodTearDown()
        {
            controller.TearDown();
        }
    }

    
}
