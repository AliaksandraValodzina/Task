using System;
using System.Collections.Generic;
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

        }
    }

    public class Book
    {
        public string id;
        public BookType Type;
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

    public XmlSerializer CreateOverrider()
    {
        XmlAttributeOverrides xOver = new XmlAttributeOverrides();
        XmlAttributes xAttrs = new XmlAttributes();

        // Add an XmlEnumAttribute for the FoodType.Low enumeration.
    }
}
