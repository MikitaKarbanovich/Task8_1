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
            //catalog.Fill();
            catalog.ParseXML();
            XmlSerializer formatter = new XmlSerializer(typeof(Catalog));
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("catalog.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, catalog);
                Console.WriteLine("Объект сериализован");
            }

            // десериализация
            using (FileStream fs = new FileStream("catalog.xml", FileMode.OpenOrCreate))
            {
                Catalog newCatalog = (Catalog)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Object: {newCatalog.Books}");
                foreach (var item in newCatalog.Books)
                {
                    Console.WriteLine($"Id: {item.Id}");

                }
            }
            Console.ReadLine();
        }
    }
}
