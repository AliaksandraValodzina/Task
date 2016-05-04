﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Task1
{
    public class PageWorker
    {
        // Config xml
        public XDocument Path { get; set; }

        // Page path
        public string PathPage()
        {
            var pagePath = Path.Elements("paths").Elements("path")
            .Where(a => (string)a.Attribute("Name") == "PageData")
            .Select(a => (string)a)
            .First();

            return pagePath;
        }

        // Path to ButtonState file
        public string PathButtonState()
        {
            var buttonStatePath = Path.Elements("paths").Elements("path")
                .Where(a => (string)a.Attribute("Name") == "ButtonState")
                .Select(a => (string)a)
                .First();

            return buttonStatePath;
        }

        // Get all name of buttons
        public List<string> ButtonName(XDocument pathPage)
        {
            var button = pathPage.Element("page").Element("elements").Elements("buttons").Elements("button")
                                .Select(e => (string)e.Value)
                                .ToList();

            return button;
        }

        // Button is single or not
        public string ButtonSingle(XDocument pathPage, string name)
        {
            var button = pathPage.Element("page").Element("elements").Elements("buttons").Elements("button")
                                .Where(e => (string)e.Attribute("Name") == name)
                                .Select(e => (string)e.Value)
                                .Single();

            return button;
        }

        // Get a button status
        public string ButtonState(XDocument pathButtonState, string button)
        {
            var status = pathButtonState.Element("buttonstates").Elements("state")
                                .Where(e => (string)e.Attribute("Name") == button)
                                .Select(e => e.Value)
                                .Single();
            return status;
        }

    }
}