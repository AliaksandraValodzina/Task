using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Task1;

namespace ClickRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to config file
            Console.Write($"Enter a path to config file\n");
            Console.Write($"This file must have a fields PageData and ButtonState with paths to files.\n");
            Console.Write($"(If you will not input path it will equal - \n{Environment.CurrentDirectory}\\Data\\Path.xml.)\n");
            string consol = Console.ReadLine();
            string path = String.IsNullOrEmpty(consol) ? $@"{Environment.CurrentDirectory}\\Data\\Path.xml" : consol;

            Page page = new Page();
            PageWorker worker = new PageWorker();

            try
            {
                worker.Path = XDocument.Load(path);
           
            // Path to page
            var pathToPage = worker.PathPage();
            XDocument pathPage = XDocument.Load(pathToPage);

            // Path to file with button status
            var pathToButtonStatus = worker.PathButtonState();
            XDocument pathButtonStatus = XDocument.Load(pathToButtonStatus);

            var buttons = worker.ButtonName(pathPage);

            foreach (var but in buttons) 
            {
                    /*try
                    {
                        var butIsSingle = worker.ButtonSingleOrNot(pathPage, but);*/
                        Button button = new Button();
                        button.Name = but;
                        string status;

                        try
                        {
                            status = worker.ButtonState(pathButtonStatus, but);
                        }
                        catch (InvalidOperationException)
                        {
                            Console.Write($"File ButtonState do not have a status for button \"{but}\".\n");
                            Console.WriteLine($"Or status of button is not a single, or do not have a value");
                            Console.Write("Status will be changed on \"false\".\n\n");
                            status = "false";
                        }

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

                        page.Buttons.Add(button);
                    /*} catch (InvalidOperationException)
                    {
                        Console.WriteLine($"The button \"{but}\" is not a single on the page");
                        Console.WriteLine("You can not click on this button");
                    }*/

                }

                foreach (var but in page.Buttons)
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
