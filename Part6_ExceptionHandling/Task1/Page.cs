using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1
{
    public class Page
    {
        // Config file
        private XDocument path = XDocument.Load($@"{Environment.CurrentDirectory}\Data\Path.xml");

        // Page path
        public string pathPage()
        {
            var pagePath = path.Elements("paths").Elements("path")
            .Where(a => (string)a.Attribute("Name") == "PageData")
            .Select(a => (string)a)
            .First();   

            return pagePath;
        }

        // Path to ButtonStatus file
        public string pathButtonStatus()
        {
            var buttonStatusPath = path.Elements("paths").Elements("path")
                .Where(a => (string)a.Attribute("Name") == "ButtonState")
                .Select(a => (string)a)
                .First();

            return buttonStatusPath;
        }

        // Get all name of buttons
        public List<string> buttonName(XDocument pathPage)
        {
            /*var buttonStatus = (from page in pathPage.Elements("button")
                               from butState in pathButtonStatus.Elements("state")
                                where (string)page.Attribute("Name") == (string)butState.Attribute("Name")
                                select new
                               {
                                   Name = (string)page.Attribute("Name"),
                                   Value = bool.Parse(butState.Value)
                               }).ToDictionary(o => o.Name, o => o.Value);*/

            var button = pathPage.Element("page").Element("elements").Elements("buttons").Elements("button")
                                .Select(e => (string)e.Attribute("Name"))
                                .ToList();

            return button;
        }

        // Get a button status
        public bool buttonStatus(XDocument pathButtonStatus, string button)
        {
            var status = pathButtonStatus.Element("buttonstates").Elements("state")
                                .Where(e => (string)e.Attribute("Name") == button)
                                .Select(e => bool.Parse(e.Value))
                                .First();

            return status;
        }

        // Buttons on the page
        private List<Button> buttons = new List<Button>();

        public List<Button> buttonList
        {
            get { return buttons; }
            set { buttons = value; }
        }



    }

    [TestClass]
    public class Test
    {
        [TestMethod]
        public void Test_1()
        {
            Page page = new Page();
            XDocument pathPage = XDocument.Load($@"C:\Users\Aliaksandra_Valodzina@epam.com\Task\Part6_ExceptionHandling\ClickRunner\bin\Debug\Data\PageData.xml");
            XDocument pathButtonStatus = XDocument.Load($@"C:\Users\Aliaksandra_Valodzina@epam.com\Task\Part6_ExceptionHandling\ClickRunner\bin\Debug\Data\ButtonState.xml");

            var buttons = page.buttonName(pathPage);
            Assert.AreEqual(buttons.Contains("Ok"), true);
        }
    }
    }
