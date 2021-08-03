//using Newtonsoft.Json;
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
        static void Main(string[] args)
        {
            string binaryFile = "Employee.dat";

            List<Employee> employees = new List<Employee>
            {
                new Employee { Id = 101, FirstName = "Mark", LastName = "Johnson", Salary = 1850 },
                new Employee { Id = 102, FirstName = "Lucy", LastName = "Doe", Salary = 1900 },
                new Employee { Id = 103, FirstName = "Tracy", LastName = "Swanson", Salary = 2150 },
                new Employee { Id = 104, FirstName = "John", LastName = "Hill", Salary = 2200 },
            };

            using (Stream st = File.Open(binaryFile, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(st, employees);
            }


            using (Stream st = File.Open(binaryFile, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();

                var list = (List<Employee>)bf.Deserialize(st);

                foreach (var emp in list)
                {
                    WriteLine(emp);
                }
            }



                string xmlFile = "UnsecuredData.xml";
            Customers obj = FromXmlFile<Customers>(xmlFile);

            foreach (var c in obj.customers)
            {
                WriteLine(c.CardNumber + " " + c.Name);
            }


            List<Customer> custometsList = new List<Customer>
            {
                new Customer { Name = "Bob Smith", CardNumber = "1234-5678-9012-3456", Password = "Pa$$w0rd"},
                new Customer { Name = "Lucy Smith", CardNumber = "9876-6543-1234-6541", Password = "123456"},
            };

            Customers obj2 = new Customers { 
                customers = custometsList
            };

            ToXmlFile("customers2.xml", obj2);


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
