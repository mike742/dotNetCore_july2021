using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace dotNetCore_july2021
{
    static class Helper
    {
        public static string FlipFirstLetterCase(this string input)
        {
            if (input.Length > 0)
            {
                var charArr = input.ToCharArray();

                charArr[0] = char.IsLower(charArr[0]) ?
                    char.ToUpper(charArr[0]) : char.ToLower(charArr[0]);

                return new string(charArr);
            }

            return input;
        }

        public static void ToWords(this BigInteger bi)
        {
            Console.WriteLine("BigInteger ToWords has been invoked!");
        }
    }
}
