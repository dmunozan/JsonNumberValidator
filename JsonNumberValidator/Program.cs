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

            int initialIndex = 0;

            if (introducedNumber[0] == '-')
            {
                initialIndex++;
            }

            for (int i = initialIndex; i < introducedNumber.Length; i++)
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
