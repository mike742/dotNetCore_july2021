//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using static System.Console;

namespace dotNetCore_july2021
{
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Circle))]
    public class Shape
    {
        public virtual string Color { get; set; }
        public virtual double Area { get; }
    }

    public interface IShape
    {
        string Color { get; set; }
        double Area { get; }
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public override string Color { get; set; }
        public override double Area => Width * Height;
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override string Color { get; set; }
        public override double Area => Math.PI * Math.Pow(Radius, 2);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var listOfShapes = new List<Shape>
            {
                new Circle { Color = "Red", Radius = 2.5 },
                new Rectangle { Color = "Blue", Height = 20.0, Width = 10.0 },
                new Circle { Color = "Green", Radius = 8 },
                new Circle { Color = "Purple", Radius = 12.3 },
                new Rectangle { Color = "Blue", Height = 45.0, Width = 18.0 }
            };

            string xmlFile = "shapes.xml";

            ToXmlFile(xmlFile, listOfShapes);


            foreach (Shape item in listOfShapes)
            {
                WriteLine($"{item.GetType().Name} is {item.Color} and has an area of { item.Area}");
            }
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
