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
            const int Zero = 48;
            const int Nine = 57;

            if (introducedNumber == null)
            {
                return "Invalid";
            }

            for (int i = 0; i < introducedNumber.Length; i++)
            {
                if (introducedNumber[i] < Zero || introducedNumber[i] > Nine)
                {
                    return "Invalid";
                }
            }

            return "Valid";
        }
    }
}
