﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using System.Linq;

namespace Task1
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void ButtonNameTest()
        {
            Page page = new Page();
            PageWorker worker = new PageWorker();
            worker.Path = XDocument.Load(@"C:\Users\Aliaksandra_Valodzina@epam.com\Task\Part6_ExceptionHandling\ClickRunner\App.config");

            var pathToPage = worker.PathToPageData();
            XDocument pathPage = XDocument.Load(pathToPage);

            var buttons = worker.ButtonName(pathPage);
            // Get expected result from file
            Assert.AreEqual(buttons.Contains("Next Page"), true);
        }

        [TestMethod]
        public void PathPageTest()
        {
            Page page = new Page();
            PageWorker worker = new PageWorker();
            worker.Path = XDocument.Load(@"C:\Users\Aliaksandra_Valodzina@epam.com\Task\Part6_ExceptionHandling\ClickRunner\App.config");
            var pathToPage = worker.PathToPageData();
            // Get expected result from file
            var expectedRes = $@"C:\Users\Aliaksandra_Valodzina@epam.com\Task\Part6_ExceptionHandling\ClickRunner\bin\Debug\Data\PageData.xml";
            Assert.AreEqual(pathToPage.Equals(expectedRes), true);
        }

        [TestMethod]
        public void PathButtonStateTest()
        {
            Page page = new Page();
            PageWorker worker = new PageWorker();
            worker.Path = XDocument.Load(@"C:\Users\Aliaksandra_Valodzina@epam.com\Task\Part6_ExceptionHandling\ClickRunner\App.config");
            var pathToPage = worker.PathButtonState();
            // Get expected result from file
            var expectedRes = $@"C:\Users\Aliaksandra_Valodzina@epam.com\Task\Part6_ExceptionHandling\ClickRunner\bin\Debug\Data\ButtonState.xml";
            Assert.AreEqual(pathToPage.Equals(expectedRes), true);
        }

        [TestMethod]
        public void ButtonStateTest()
        {
            PageWorker worker = new PageWorker();
            worker.Path = XDocument.Load(@"C:\Users\Aliaksandra_Valodzina@epam.com\Task\Part6_ExceptionHandling\ClickRunner\App.config");

            // Path to page
            var pathToPage = worker.PathToPageData();
            XDocument pathPage = XDocument.Load(pathToPage);

            var buttons = worker.ButtonName(pathPage);

            // Path to file with button status
            var pathToButtonState = worker.PathButtonState();
            XDocument pathButtonState = XDocument.Load(pathToButtonState);

            // Get expected result from file
            var state = bool.Parse(worker.ButtonState(pathButtonState, buttons.ElementAt(1)));
            Assert.IsFalse(state);
        }
    }
}
