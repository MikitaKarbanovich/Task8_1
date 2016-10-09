using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();
            XmlSerializer formatter = new XmlSerializer(typeof(Book));
            catalog.ParseXML();
            //    // получаем поток, куда будем записывать сериализованный объект
            //    using (FileStream fs = new FileStream("newbook.xml", FileMode.OpenOrCreate))
            //    {
            //        formatter.Serialize(fs, catalog.ParseXML());
            //        Console.WriteLine("Объект сериализован");
            //    }

            //    // десериализация
            //    using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            //    {
            //        Book newBook = (Book)formatter.Deserialize(fs);

            //        Console.WriteLine("Объект десериализован");
            //        Console.WriteLine($"Id: {newBook.Id} --- Isbn: {newBook.Isbn}");
            //    }
            //     Console.ReadLine();
            //}
        }
    }
}
