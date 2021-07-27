//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

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
            // File f;
            // Path p;

            string file = @"d:\temp\file.txt";

            Console.WriteLine(File.Exists(file));
            Console.WriteLine(Path.GetFileName(file));
            Console.WriteLine(Path.GetDirectoryName(file));
            Console.WriteLine(Path.GetFileNameWithoutExtension(file));
            Console.WriteLine(Path.GetExtension(file));

            for (int i = 0; i < 5; i++)
            {
                string res = Path.GetRandomFileName();
                Console.WriteLine("Temp path: " + res);
            }

            string file1 = @"d:\temp\file1.qwerty";

            using (FileStream fs = File.Create(file1))
            {
                AddText(fs, "Line #1\n");
                AddText(fs, "Line #2\n");
                AddText(fs, "Line #3\n");
                AddText(fs, "Line #4\n");
            }

            Console.WriteLine("----------------------------------------");

            using (FileStream fs = File.OpenRead(file1))
            {
                byte[] bArr = new byte[1024];
                var temp = new UTF8Encoding(true);

                while (fs.Read(bArr, 0, bArr.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(bArr));
                }
            }

            //if(File.Exists(file1))
            //{
            //    File.Delete(file1);
            //}

            Console.WriteLine("----------------------------------------");

            var arrStr = File.ReadAllLines(file1);

            foreach (var s in arrStr)
            {
                Console.WriteLine(s);
            }

            // File.WriteAllLines(file1, new string[] { "Hello", "Files" });
            File.AppendAllLines(file1, new string[] { "Hello", "Files" });
            */
        }

        private static void AddText(FileStream fs, string line)
        {
            byte[] arr = new UTF8Encoding(true).GetBytes(line);
            fs.Write(arr, 0, arr.Length);
        }
    }
}
