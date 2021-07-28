//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace dotNetCore_july2021
{
    public class Item
    {
        public string id { get; set; }
        public string label { get; set; }
    }

    public class Menu
    {
        public string header { get; set; }
        [XmlElement]
        public List<Item> items { get; set; }
    }

    public class Top
    {
        public Menu menu { get; set; }

        public void Print()
        {
            Console.WriteLine(menu.header);
            foreach (var i in menu.items)
            {
                if (i != null)
                {
                    if (i.id != null)
                        Console.WriteLine(i.id);
                    if (i.label != null)
                        Console.WriteLine(" " + i.label);
                }
                else
                    Console.WriteLine("null");

            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // string json = Console.ReadLine();
            string file = @"data.json";

            string jsonString = File.ReadAllText(file);

            // Console.WriteLine(json);

            Top obj = JsonSerializer.Deserialize<Top>(jsonString);
            //Top obj = JsonConvert.DeserializeObject<Top>(jsonString);


            obj.Print();

            /*
            var xs = new XmlSerializer(typeof(Top));
            string xmlFile = @"data.xml";

            using (FileStream fs = File.Create(xmlFile))
            {
                xs.Serialize(fs, obj);
            }
            */

            ToXmlFile("sample1.xml", obj);

            Console.WriteLine("==================================");

            var resObj = FromXmlFile<Top>("sample1.xml");
            resObj.Print();

        }

        public static T FromXmlFile<T>(string file)
        {
            XmlSerializer xmls = new XmlSerializer(typeof(T));
            var xmlContent = File.ReadAllText(file);

            using (StringReader sr = new StringReader(xmlContent))
            {
                return (T)xmls.Deserialize(sr);
            }
        }

        public static void ToXmlFile<T>(string file, T obj)
        {
            using (StringWriter sw = 
                new StringWriter( new StringBuilder() ))
            { 
                XmlSerializer xmls = new XmlSerializer(typeof(T));
                xmls.Serialize(sw, obj);
                File.WriteAllText(file, sw.ToString());
            }
        }

    }
}
