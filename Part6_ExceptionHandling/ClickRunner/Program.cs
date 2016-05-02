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

            var buttonList = page.buttonName(pathPage);

            foreach (var but in buttonList) 
            {
                if (page.buttonStatus(pathButtonStatus, but) == true)
                {
                    Button button = new Button();
                    button.Name = but;
                    button.Enabled = true;
                    page.buttonList.Add(button);
                }
                else
                {
                    throw new EnabledStatusException();
                }
            }

            var a = page.buttonList;

            foreach (var but in a)
            {
                Console.Write($"but = {but.Name} {but.Enabled}\n");
            }

            Console.Write($"path = {pathToPage}");

            Console.Read();
        }
    }
}
