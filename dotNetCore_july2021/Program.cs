using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace dotNetCore_july2021
{
    class Program
    {
        private static readonly String[] unitsMap = new[] { 
            "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", 
            "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", 
            "seventeen", "eighteen", "nineteen"
        };

        private static readonly String[] tensArr = new string[] {
            "", "ten", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninty" };

        private static readonly string[] suffixesArr = new string[] { "", "thousand", "million", "billion", 
            "trillion", "quadrillion", "quintillion", "sextillion", "septillion", "octillion", 
            "nonillion", "decillion", "undecillion", "duodecillion", "tredecillion", 
            "Quattuordecillion", "Quindecillion", "Sexdecillion", "Septdecillion", 
            "Octodecillion", "Novemdecillion", "Vigintillion" };

        static string ThreeToWords(string part)
        {
            part = part.PadLeft(3, '0');
            string res = string.Empty;

            if(part[0] != '0') // 1-9
            {
                res += unitsMap[Convert.ToInt32(part[0].ToString())] 
                    + " hundred";
            }

            if (part[1] == '1')
            {
                int ind = Convert.ToInt32(part[1].ToString() + part[2].ToString());
                string teen = unitsMap[ind];

                res += string.IsNullOrEmpty(res) ? teen : " and " + teen;
            }
            else
            {
                int ind = Convert.ToInt32(part[1].ToString());
                int ind2 = Convert.ToInt32(part[2].ToString());
                string tens = tensArr[ind];
                string single = unitsMap[ind2];

                res += string.IsNullOrEmpty(res) ? tens : " and " + tens + " " + single;
            }

            return res;
        }

        static void Main(string[] args)
        {
            char ch = 'a';

            Console.WriteLine((int)ch);

            string input = "829000000000000000000000000000000000";
            BigInteger bi = BigInteger.Parse(input);

            string num = bi.ToString("N0");

            Console.WriteLine(num);

            string[] partsByThree = num.Split(",");

            for(var i = 0;  i < partsByThree.Length; ++i)
            {
                //Console.WriteLine($"{ThreeToWords(partsByThree[i])} - {suffixesArr[partsByThree.Length - i - 1]}");
                Console.WriteLine($"{partsByThree[i]} {ThreeToWords(partsByThree[i])}");
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
