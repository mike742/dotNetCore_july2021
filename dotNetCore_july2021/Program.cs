//using Newtonsoft.Json;
using dotNetCore_july2021.DbModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using static System.Console;
using System.Linq;

namespace dotNetCore_july2021
{
    class Program
    {
        private static readonly salecoContext _context = new salecoContext();

        static void Main(string[] args)
        {
            var customers = _context.Customers.ToList();
            int? areaCode = 615;
            List<Customer> filteredCustomers = new List<Customer>();

            foreach (var cus in customers)
            {
                if (cus.CusAreaCode == areaCode)
                {
                    filteredCustomers.Add(cus);
                }
            }

            foreach (var cus in filteredCustomers)
            {
                WriteLine($"{cus.CusCode} {cus.CusFName} {cus.CusLName} {cus.CusAreaCode}");
            }


            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            long[] numbers2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var res2 = numbers2.Where(c => c % 2 == 0);

            WriteLine(string.Join(", ", res2));

            IEnumerable<int> res3 = from n in numbers
                       where n % 2 != 0
                       select n;

            WriteLine(string.Join(", ", res3));


            //var filteredCustomers2 = customers.Where(TakeByAreaCode);
            //var filteredCustomers2 = 
            //    customers.Where( delegate(Customer c) { return c.CusAreaCode == 615;  } );
            // var filteredCustomers2 = customers.Where((Customer c) => c.CusAreaCode == 615);
            var filteredCustomers2 = customers.Where(c => c.CusAreaCode == areaCode);

            foreach (var cus in filteredCustomers2)
            {
                WriteLine($"{cus.CusCode} {cus.CusFName} {cus.CusLName} {cus.CusAreaCode}");
            }
        }

        public static bool TakeByAreaCode(Customer c)
        {
            return c.CusAreaCode == 615;
        }

        public static void ToBinaryFile<T>(string file, T obj)
        {
            using (Stream st = File.Open(file, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(st, obj);
            }
        }

        public static void ToJsonFile<T>(string file, T obj)
        {
            string json = JsonSerializer.Serialize(obj);
            File.WriteAllText(file, json);
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
                new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(T));
                xmls.Serialize(sw, obj);
                File.WriteAllText(file, sw.ToString());
            }
        }

    }
}
