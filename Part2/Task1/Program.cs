using System;
using System.IO;

namespace FileOrString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a path to txt file.");
            String path = Console.ReadLine();

            if (File.Exists(path))
            {
                string[] readText = File.ReadAllLines(path);

                int indexOne = 0;
                while (indexOne < (readText.Length - 1))
                {
                    string textLine = readText[indexOne];
                    string data = String.Format("{0:dd.MM.yyyy HH:mm:ss.fff}", DateTime.Now);
                    if (textLine.Contains("."))
                    {
                        char[] separator = new char[] { '.' };
                        string[] lines = textLine.Split(separator);
                        int indexTwo = 0;
                        while (indexTwo < (lines.Length - 1))
                        {
                            string stringLine = data + " " + lines[indexTwo] + ".";
                            Console.WriteLine(stringLine.ToLower());
                            indexTwo++;
                        }
                    }
                    else
                    {
                        Console.WriteLine(data + " " + textLine.ToLower());
                    }
                    indexOne++;
                }

            }
            Console.ReadLine();
        }

        

        }
    }
