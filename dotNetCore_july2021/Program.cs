using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace dotNetCore_july2021
{
    class Program
    {
        private readonly String[] unitsMap = new[] { 
            "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", 
            "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", 
            "seventeen", "eighteen", "nineteen"
        };

        private readonly String[] tensArr = new string[] { 
            "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninty" };

        private readonly string[] suffixesArr = new string[] { "thousand", "million", "billion", 
            "trillion", "quadrillion", "quintillion", "sextillion", "septillion", "octillion", 
            "nonillion", "decillion", "undecillion", "duodecillion", "tredecillion", 
            "Quattuordecillion", "Quindecillion", "Sexdecillion", "Septdecillion", 
            "Octodecillion", "Novemdecillion", "Vigintillion" };

        static void ThreeToWords(string part)
        {
            part = part.PadLeft(3, '0'); 
            Console.WriteLine(part);
        }

        static void Main(string[] args)
        {
            char ch = 'a';

            Console.WriteLine((int)ch);

            string input = "18500000000000000000000000000000000";
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
