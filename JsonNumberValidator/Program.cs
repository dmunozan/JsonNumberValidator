using System;
using System.Collections.Generic;

namespace JsonNumberValidator
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(Convert.ToInt32("012"));
        }

        public static string IsValidJsonNumber(string introducedNumber)
        {
            if (introducedNumber == null)
            {
                return "Invalid";
            }

            if (introducedNumber[0] == 'A')
            {
                return "Invalid";
            }

            return "Valid";
        }
    }
}
