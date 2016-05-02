using System;
using System.Xml.Linq;
using Task1;

namespace ClickRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Page page = new Page();

            // Path to page
            var pathToPage = page.pathPage();
            XDocument pathPage = XDocument.Load(pathToPage);

            // Path to file with button status
            var pathToButtonStatus = page.pathButtonStatus();
            XDocument pathButtonStatus = XDocument.Load(pathToButtonStatus);

            var buttonWithStatus = page.buttonStatus(pathPage, pathButtonStatus);

            foreach (var but in buttonWithStatus) 
            {
                Button button = new Button();
                button.Name = but.Key;
                button.Enabled = but.Value;
                page.buttonList.Add(button);
            }

            var a = page.buttonList;

            foreach (var but in a)
            {
                Console.Write($"but = {but.Name} {but.Enabled}");
            }

            Console.Write($"path = {pathToPage}");

            Console.Read();
        }
    }
}
