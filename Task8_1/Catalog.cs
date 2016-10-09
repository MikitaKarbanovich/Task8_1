using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task8_1
{
    public class Catalog
    {
        string FileName = $@"{Environment.CurrentDirectory}\Books.xml";
        XDocument Document;
        public void StartReading()
        {
            Document = XDocument.Load(FileName);
        }
        public List<Book> ParseXML()
        {
            List<Book> books = new List<Book>();
            return books = Document
               .Descendants("book")
               .Select(x => new Book
               {
                   //Id = x.Attribute("id")?.Value,
                   Isbn = x.Element("isbn")?.Value,
                   Author = x.Element("author")?.Value,
                   Title = x.Element("title")?.Value,
                   //Genre = checkGenre(x.Element("genre")?.Value),
                   Publisher = x.Element("publisher")?.Value,
                   //PublishDate = Convert.ToDateTime(x.Element("publish_date")?.Value),
                   Description = x.Element("description")?.Value,
                  // RegistrationDate = Convert.ToDateTime(x.Element("registration_date")?.Value),
               })
               .ToList();
        }
        public Genre checkGenre(string gener)
        {
            Genre genreType = Genre.Other;
            switch (gener)
            {
                case "Computer":
                    genreType = Genre.Computer;
                    break;
                case "Fantasy":
                    genreType = Genre.Fantasy;
                    break;
                case "Romance":
                    genreType = Genre.Romance;
                    break;
                case "Horror":
                    genreType = Genre.Horror;
                    break;
                case "ScienceFiction":
                    genreType = Genre.ScienceFiction;
                    break;
            }
            return genreType;
        }
    }
}
