using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            public string Isbn { get; set; } = "Not specified";

            [XmlElement("author")]
            public string Author { get; set; }

            [XmlElement("title")]
            public string Title { get; set; }

            [XmlElement("genre")]
            public Genre Genre { get; set; }

            [XmlElement("publisher")]
            public string Publish { get; set; }

            [XmlElement("publish_date")]
            public DateTime PublishDate { get; set; }

            [XmlElement("description")]
            public string Description { get; set; }

            [XmlElement("registration_date")]
            public DateTime RegistrationDate { get; set; }

            public Book() { }
            public Book(string id, string isbn, string author, string title, Genre genre, string publisher,
                DateTime publishDate, string description, DateTime registrationDate)
            {
                Id = id;
                Isbn = isbn;
                Author = author;
                Title = title;
                Genre = genre;
                Publish = publisher;
                PublishDate = publishDate;
                Description = description;
                RegistrationDate = registrationDate;
            }
            public override string ToString()
            {
                return string.Format($" Author: {Author} -  Title: {Title}\n\tId: {Id}\n\tIsbn: {Isbn}"
                    + $"\n\tGenre: {Genre}\n\tPublisher: {Publish}\n\tPublish date: {PublishDate.ToString("MMMM dd yyyy")}"
                    + $"\n\tDescription:{Description}\tRegistration date: {RegistrationDate.ToString("MMMM dd yyyy")}");
            }

        }
}
