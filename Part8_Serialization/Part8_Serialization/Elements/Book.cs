using System;
using System.Xml.Serialization;

namespace Part8_Serialization.Elements
{
        public enum Genre
        {
            [XmlEnum("Computer")]
            Computer,
            [XmlEnum("Fantasy")]
            Fantasy,
            [XmlEnum("Romance")]
            Romance,
            [XmlEnum("Horror")]
            Horror,
            [XmlEnum("Science Fiction")]
            ScienceFiction,
        }

        [Serializable]
        public class Book
        {
            [XmlAttribute("id")]
            public string Id { get; set; }

            [XmlElement("isbn")]
            public string Isbn { get; set; }

            [XmlElement("author")]
            public string Author { get; set; }

            [XmlElement("title")]
            public string Title { get; set; }

            [XmlElement("genre")]
            public Genre Genre { get; set; }

            [XmlElement("publisher")]
            public string Publish { get; set; }

            [XmlElement("publish_date", DataType = "date")]
            public DateTime PublishDate { get; set; }

            [XmlElement("description")]
            public string Description { get; set; }

            [XmlElement("registration_date", DataType = "date")]
            public DateTime RegistrationDate { get; set; }
        }
}
