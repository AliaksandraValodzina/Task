using System;
using System.IO;

namespace Task1
{
    public class LogWriter
    {
        public string fileName = "Log.txt";

        public void WriteToFile(string message)
        {
                if (!File.Exists(fileName))
                {
                    File.Create(fileName);
                }

                using (StreamWriter w = File.AppendText(fileName))
                {
                    w.Write(message);
                    w.Write("\r\n");
                }
        } 
}
}
