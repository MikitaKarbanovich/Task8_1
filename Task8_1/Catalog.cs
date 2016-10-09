using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task8_1
{
    [Serializable]
    public class Catalog
    {
        public List<Book> Books { get; set; } = new List<Book>();
        string FileName = $@"{Environment.CurrentDirectory}\Books.xml";
        XDocument Document;
        public void ParseXML()
        {
            string Xmlns;
            Document = XDocument.Load(FileName);
            Xmlns = Document.Root.Attribute("xmlns").Value;
            XNamespace nameSpace = Xmlns;
            this.Books = Document
               .Descendants(nameSpace+"book")
               .Select(x => new Book
               {
                   Id = x.Attribute("id")?.Value,
                   Isbn = x.Element(nameSpace + "isbn")?.Value,
                   Author = x.Element(nameSpace + "author")?.Value,
                   Title = x.Element(nameSpace + "title")?.Value,
                   Genre = checkGenre(x.Element(nameSpace + "genre")?.Value),
                   Publisher = x.Element(nameSpace + "publisher")?.Value,
                   PublishDate = Convert.ToDateTime(x.Element(nameSpace + "publish_date")?.Value),
                   Description = x.Element(nameSpace + "description")?.Value,
                   RegistrationDate = Convert.ToDateTime(x.Element(nameSpace + "registration_date")?.Value),
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
