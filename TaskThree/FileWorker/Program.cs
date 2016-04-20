using System;
using System.IO;
using System.Text;

namespace FileWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Enter a folder name
            Console.Write("Plese enter a folder name.");
            string folderName = Console.ReadLine();
            string folderPath = "c:/" + folderName;

            // Create a directory
            bool exists = Directory.Exists(folderPath);

            if (!exists)
            {
                Directory.CreateDirectory(folderPath);
            }
            else
            {
                Console.Write("Folder name " + folderName + " is exists");
            }

            // Read from existing file
            string existingFile = "C:/123.txt";
            string[] lines = new string[20];

            using (var sr = new StreamReader(existingFile))
            {
                for (int i = 1; i < lines.Length; i++)
                    lines[i] = sr.ReadLine();
            }

            // Create .txt file
            string filePath = folderPath + "/WriteLines.txt";

            File.WriteAllLines(filePath, lines);
        }
    }
}
