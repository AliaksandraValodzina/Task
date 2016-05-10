using Part8_Serialization.Elements;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Part8_Serialization
{
    public class Run
    {
        static void Main(string[] args)
        {
            //string xmlFile = $@"{Environment.CurrentDirectory}\\Books.xml";
            //string outFile = $@"{Environment.CurrentDirectory}\\RezultBooks.xml";

            string xmlFile = @"C:\Users\AlexandrVolodin\Task\Part8_Serialization\Part8_Serialization\XML Files\Books.xml";
            string outFile = @"C:\Users\AlexandrVolodin\Task\Part8_Serialization\Part8_Serialization\XML Files\RezultBooks.xml";
            string delimiter = "".PadRight(70, '-');

            var deSerializer = new XmlSerializer(typeof(Catalog));
            var catalog = deSerializer.Deserialize(new FileStream(xmlFile, FileMode.Open)) as Catalog;

            foreach (Book book in catalog.Books)
            {
                Console.WriteLine(book);
                Console.WriteLine(delimiter);
            }

            var serializer = new XmlSerializer(typeof(Catalog));
            var stream = new FileStream(outFile, FileMode.Create);
            serializer.Serialize(stream, catalog);
            stream.Close();

            Console.ReadLine();
        }
    }
}