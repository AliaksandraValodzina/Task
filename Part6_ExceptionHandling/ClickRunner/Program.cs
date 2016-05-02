using System;
using System.IO;
using System.Xml.Linq;
using Task1;

namespace ClickRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write($"Enter a path to config file\n");
            Console.Write($"This file must have a fields PageData and ButtonState with paths to files.\n");
            Console.Write($"(If you will not input path it will equal - \n{Environment.CurrentDirectory}\\Data\\Path.xml.)\n");
            string consol = Console.ReadLine();
            string path = String.IsNullOrEmpty(consol) ? $@"{Environment.CurrentDirectory}\\Data\\Path.xml" : consol;

            Page page = new Page();

            try
            {
                page.Path = XDocument.Load(path);
           
            // Path to page
            var pathToPage = page.pathPage();
            XDocument pathPage = XDocument.Load(pathToPage);

            // Path to file with button status
            var pathToButtonStatus = page.pathButtonStatus();
            XDocument pathButtonStatus = XDocument.Load(pathToButtonStatus);

            var buttons = page.buttonName(pathPage);

            foreach (var but in buttons) 
            {
                    Button button = new Button();
                    button.Name = but;

                    string status = page.buttonStatus(pathButtonStatus, but);

                    //if (!page.buttonList.Contains(button))
                    //{
                        try
                    {
                        button.Enabled = bool.Parse(status);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Invalid status of button \"{button.Name}\" - \"{status}\".");
                        Console.WriteLine($"Status will be changed on \"false\".\n");
                        button.Enabled = false;
                    }

                        page.buttonList.Add(button);
                    /*}
                    else
                    {
                        Console.WriteLine($"Page has a button \"{button.Name}\" already\n");
                    }*/
            }

            foreach (var but in page.buttonList)
            {
                Button button = but;

                try
                {
                    button.Click();
                    Console.Write($"You click on the button \"{button.Name}\".\n");
                }
                catch (EnabledStatusException)
                {
                    Console.Write($"You can not click on the button \"{button.Name}\". Button is disabled.\n");
                }
            }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Invalid path - \"{path}\". Try again");
            }

            Console.Read();
        }
    }
}
