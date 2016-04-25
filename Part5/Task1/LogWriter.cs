using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class LogWriter
    {
        private string fileName = "C:/Log.txt";

        public void WriteToFile(string message)
        {
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }

            using (StreamWriter w = File.AppendText(fileName))
            {
                w.Write("Time: ");
                w.Write(message);
                w.Write("\r\n");
            }
        }

}
}
