using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task1
{
    class Page
    {
        // Config file
        private XDocument path;

        public Page() 
        {
            path = XDocument.Load($@"{Environment.CurrentDirectory}\Data\Path.xml");
        }

        // Page path
        public IEnumerable<string> pathPage()
        {
            var pagePath = from page in path.Elements("paths")
                            where page.Element("path").Name.Equals("PageData")
                            select page.Element("path").Value;

            return pagePath;
        }

        // Path to ButtonStatus file
        public IEnumerable<string> pathButtonStatus()
        {
            var buttonStatusPath = from button in path.Elements("paths")
                           where button.Element("path").Name.Equals("ButtonStatus")
                           select button.Element("path").Value;

            return buttonStatusPath;
        }

        // Get all name of buttons with status
        public IDictionary<string, bool> buttonStatus(XDocument pathPage, XDocument pathButtonStatus)
        {
            var buttonStatus = (from page in pathPage.Elements("page").Elements("elements").Elements("buttons")
                               from butState in pathButtonStatus.Elements("buttonstates")
                               where page.Element("button").Name.Equals(butState.Element("state").Name)
                               select new
                               {
                                   Name = page.Element("button").Name.LocalName,
                                   Value = bool.Parse(butState.Element("state").Value)
                               }).ToDictionary(o => o.Name, o => o.Value);

            return buttonStatus;
        }

        public IDictionary<Button, bool> buttons { get; set; }

    }
}
