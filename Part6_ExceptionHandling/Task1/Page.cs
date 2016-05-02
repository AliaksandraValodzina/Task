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
        public XDocument Path { get; set; }

        //private XDocument path = XDocument.Load($@"{Environment.CurrentDirectory}\Data\Path.xml");

        // Page path
        public string pathPage()
        {
            var pagePath = Path.Elements("paths").Elements("path")
            .Where(a => (string)a.Attribute("Name") == "PageData")
            .Select(a => (string)a)
            .First();   

            return pagePath;
        }

        // Path to ButtonStatus file
        public string pathButtonStatus()
        {
            var buttonStatusPath = Path.Elements("paths").Elements("path")
                .Where(a => (string)a.Attribute("Name") == "ButtonState")
                .Select(a => (string)a)
                .First();

            return buttonStatusPath;
        }

        // Get all name of buttons
        public List<string> buttonName(XDocument pathPage)
        {
            var button = pathPage.Element("page").Element("elements").Elements("buttons").Elements("button")
                                .Select(e => (string)e.Attribute("Name"))
                                .ToList();

            return button;
        }

        // Get a button status
        public string buttonStatus(XDocument pathButtonStatus, string button)
        {
                var status = pathButtonStatus.Element("buttonstates").Elements("state")
                                    .Where(e => (string)e.Attribute("Name") == button)
                                    .Select(e => e.Value)
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
            page.Path = XDocument.Load($@"{Environment.CurrentDirectory}\\Data\\Path.xml");

            var pathToPage = page.pathPage();
            XDocument pathPage = XDocument.Load(pathToPage);

            var buttons = page.buttonName(pathPage);
            Assert.AreEqual(buttons.Contains("Next Page"), true);
        }
    }
    }
