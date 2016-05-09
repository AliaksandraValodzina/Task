using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Part8_Serialization
{
    class Run
    {
        static void Main(string[] args)
        {
            BookSerializer serializer = new BookSerializer();
            serializer.ReadXML();
            serializer.WriteXML();
        }
    }

    public class Catalog
    {
        public string xmlns;
        public string date;
        public BookType Book;
    }

    public enum BookType
    {
        isbn,
        author,
        title,
        genre,
        publisher,
        publish_date,
        description
    }

   public class BookSerializer
        {

         public void ReadXML()
    {
        // First write something so that there is something to read ...
        var b = new Book();
        var writer = new System.Xml.Serialization.XmlSerializer(typeof(Book));
        var wfile = new System.IO.StreamWriter(@"C:\Users\AlexandrVolodin\Task\Part8_Serialization\Part8_Serialization\XML Files\XMLFile1.xml");
        writer.Serialize(wfile, b);
        wfile.Close();

        // Now we can read the serialized book ...
        System.Xml.Serialization.XmlSerializer reader =
            new System.Xml.Serialization.XmlSerializer(typeof(Book));
        System.IO.StreamReader file = new System.IO.StreamReader(
            @"C:\Users\AlexandrVolodin\Task\Part8_Serialization\Part8_Serialization\XML Files\XMLFile1.xml");
        Book overview = (Book)reader.Deserialize(file);
        file.Close();

        Console.WriteLine(overview.id);

    }

    public void WriteXML()
    {
        Book overview = new Book();
        overview.id = "Serialization Overview";
        System.Xml.Serialization.XmlSerializer writer =
            new System.Xml.Serialization.XmlSerializer(typeof(Book));

        var path = @"C:\Users\AlexandrVolodin\Task\Part8_Serialization\Part8_Serialization\XML Files\XMLFile2.xml";
        System.IO.FileStream file = System.IO.File.Create(path);

        writer.Serialize(file, overview);
        file.Close();
    }
}
}