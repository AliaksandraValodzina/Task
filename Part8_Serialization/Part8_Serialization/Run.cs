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
            string xmlFile = $@"{Environment.CurrentDirectory}\XML Files\Books.xml";
            string outFile = $@"{Environment.CurrentDirectory}\XML Files\RezultBooks.xml";

            var deserializer = new XmlSerializer(typeof(Catalog));
            var catalog = deserializer.Deserialize(new FileStream(xmlFile, FileMode.Open)) as Catalog;

            foreach (var book in catalog.Books)
            {
                Console.WriteLine(book);
                Console.WriteLine("");
            }

            var serializer = new XmlSerializer(typeof(Catalog));
            var stream = new FileStream(outFile, FileMode.Create);
            serializer.Serialize(stream, catalog);
            stream.Close();

            Console.Read();
        }
    }
}