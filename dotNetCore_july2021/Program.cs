using System;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace dotNetCore_july2021
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello"; // "Hello"
            str += " "; // "Hello" "Hello "
            str += "Word"; // "Hello" "Hello " "Hello Word"

            Console.WriteLine(str);

            StringBuilder sb = new StringBuilder("Hello");
            sb.Append(" ");
            sb.Append("Word");

            // 2147483647
            Console.WriteLine(sb.MaxCapacity);

            string passage = @"I do not like them
In a house.
I do not like them
With a mouse.
I do not like them
Here or there.
I do not like them
Anywhere.
I do not like green eggs and ham.
I do not like them, Sam - I - am.";

            StringBuilder sbp = new StringBuilder(passage);
            sbp.Replace("not ", null);

            Console.WriteLine(sbp.ToString());

        }
    }
}
