using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Part8_Serialization.Elements
{
    [Serializable]
    [XmlRoot("catalog", Namespace = ("http://library.by/catalog"))]
    public class Catalog
    {
        [XmlAttribute("date", DataType = "date")]
        public DateTime Date { get; set; }

        [XmlElement("book", Type = typeof(Book))]
        public List<Book> Books { get; set; }
    }
}
