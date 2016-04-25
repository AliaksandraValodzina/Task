using System.IO;

namespace Task1
{
    class LogWriter
    {
        public string fileName = "C:/Log.txt";

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
