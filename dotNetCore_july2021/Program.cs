//using Newtonsoft.Json;
using dotNetCore_july2021.DbModels;
using Protector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using static System.Console;

namespace dotNetCore_july2021
{
    public class Customer
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("creditcard")]
        public string CardNumber { get; set; }
        [XmlElement("password")]
        public string Password { get; set; }
    }

    [XmlRoot("customers")]
    public class Customers
    {
        [XmlElement("customer")]
        public List<Customer> customers { get; set; }
    }


    [Serializable()]
    public class Employee : ISerializable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }

        public Employee() { }
        public Employee(SerializationInfo info, StreamingContext context)
        {
            Id = (int)info.GetValue("Id", typeof(int));
            FirstName = (string)info.GetValue("FirstName", typeof(string));
            LastName = (string)info.GetValue("LastName", typeof(string));
            Salary = (double)info.GetValue("Salary", typeof(double));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("FirstName", FirstName);
            info.AddValue("LastName", LastName);
            info.AddValue("Salary", Salary);
        }

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {Salary}";
        }
    }


    class Program
    {
        private static readonly salecoContext _context = new salecoContext();

        static void Main(string[] args)
        {
            var products = _context.Products;

            foreach (var p in products)
            {
                WriteLine($"{p.PCode} {p.PDescript} {p.PInDate} {p.PPrice}");
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
