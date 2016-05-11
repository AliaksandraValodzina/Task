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

        public override string ToString()
        {
            return string.Format($"Book id = {Id},\r\n isbn - {Isbn},\r\n author - {Author},\r\n title - {Title},\r\n genre - {Genre},\r\n publisher - {Publish},\r\n publish date - {PublishDate},\r\n deskription - {Description}.");
        }
    }
}
