﻿using System;
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
            Console.Write($"(If you will not input path it will equal - \n{Environment.CurrentDirectory}\\App.config.)\n");
            string consol = Console.ReadLine();
            string path = String.IsNullOrEmpty(consol) ? $@"{Environment.CurrentDirectory}\\App.config" : consol;

            Page page = new Page();
            PageWorker worker = new PageWorker();

            try
            {
                worker.Path = XDocument.Load(path);

                // Path to PageData
                var pathToPage = worker.PathToPageData();
                XDocument pathPage = XDocument.Load(pathToPage);

                // Path to file ButtonState
                var pathToButtonStatus = worker.PathButtonState();
                XDocument pathButtonStatus = XDocument.Load(pathToButtonStatus);

                // Buttons from file PageData
                var buttons = worker.ButtonName(pathPage);

                foreach (var but in buttons)
                {
                    Button button = new Button();
                    button.Name = but;

                    try
                    {
                        // Button state
                        string state = worker.ButtonState(pathButtonStatus, but);
                        button.Enabled = bool.Parse(state);
                        // Add button to page
                        page.Buttons.Add(button);
                    }
                    catch (InvalidOperationException)
                    {
                        Console.Write($"File ButtonState do not have a state for button \"{but}\".\n");
                        Console.WriteLine($"Or state of button is not a single.\n");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Invalid state of button \"{but}\".\n");
                    }
                }

                foreach (var but in page.Buttons)
                {
                    try
                    {
                        but.Click();
                        Console.Write($"You clicked on the button \"{but.Name}\".\n");
                    }
                    catch (EnabledStatusException)
                    {
                        Console.Write($"You can not click on the button \"{but.Name}\". Button is disabled.\n");
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
