using System;
using System.Text.RegularExpressions;

namespace dotNetCore_july2021
{
    class Program
    {
        static void Main(string[] args)
        {
            var t =
                Tuple.Create(101, "Mark", "mark@gmail.com", "123-45678");
            Console.WriteLine($"{nameof(t)} : {t.Item1} {t.Item2} {t.Item3} {t.Item4}");
            Console.WriteLine(t.ToString());

            (double, int, string) t2 = (3.14, 7, "Hello");
            Console.WriteLine($"{t2.Item1} {t2.Item2} {t2.Item3}");

            (int id, string name, string email) t3 =
                (102, "Lucy", "lucy@gmail.com");
            Console.WriteLine($"{t3.id} {t3.name} {t3.email}");

            (int a, byte b) l = (5, 7);
            (long a, int b) r = (5, 7);
            Console.WriteLine( l == r );
            Console.WriteLine( l != r );

            (string a, string b) l1 = ("5", "7");
            (string a, string b) r1 = ("5", "7");
            Console.WriteLine(l1 == r1);

            // [] {-1, -1, -1, -1, -1, -1, -1, -1, -1} => (-1, -1)
            // [] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} => (0, 0)
            var arr = new[] { -7, 0, 75, 100, 95 };
            var (min, max) = minMaxValues(arr);
            
            Console.WriteLine($"min = {min}, max = {max}");


            var obj = new { id = 103, name = "Tracy", email = "tracy@gmail.com"};
            var arrObj = new[] {
                new { id = 104, name = "John", email = "john@gmail.com"},
                new { id = 105, name = "Mary", email = "mary@gmail.com"}
            };

            Console.WriteLine($"{obj.id} {obj.name} {obj.email}");

            foreach(var o in arrObj)
                Console.WriteLine($"{o.id} {o.name} {o.email}");

            Console.WriteLine(arrObj[1].name);
        }

        public static (int min, int max) minMaxValues(int[] input)
        {
            // '==' vs 'is' with null
            if(input is null || input.Length == 0)
            {
                throw new ArgumentException("Cannot find min/max ...");
            }

            var min = int.MaxValue;
            var max = int.MinValue;

            foreach (var i in input)
            {
                if (i < min) min = i;
                if (i > max) max = i;
            }

            return (min, max);
        }
    }
}
