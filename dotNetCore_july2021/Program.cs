using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace dotNetCore_july2021
{
    class Program
    {
        static void ThreeToWords(string part)
        {

            Console.WriteLine(part);
        }

        static void Main(string[] args)
        {
            string input = "1850000000000000000000000000000000";
            BigInteger bi = BigInteger.Parse(input);

            string num = bi.ToString("N0");

            Console.WriteLine(num);

            string[] partsByThree = num.Split(",");

            foreach (var part in partsByThree)
            {
                ThreeToWords (part);
            }

            /*
            string str = "Hello .Net Core";
            
            string res = str.FlipFirstLetterCase();
            string res2 = Helper.FlipFirstLetterCase(str);

            Console.WriteLine(res2 + " " + res);

            BigInteger num = new BigInteger(123);
            num.ToWords();
            */
        }


    }
}
