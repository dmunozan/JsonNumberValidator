using System;
using System.Collections.Generic;

namespace JsonNumberValidator
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(IsValidJsonNumber(Console.ReadLine()));
            Console.Read();
        }

        public static string IsValidJsonNumber(string introducedNumber)
        {
            const int OnlyNumbers = 1;
            const string ValidNumberChars = ".0123456789";

            if (introducedNumber == null)
            {
                return "Invalid";
            }

            int initialIndex = 0;

            if (introducedNumber[initialIndex] == '-')
            {
                initialIndex++;
            }

            if (introducedNumber[initialIndex] == '0' && introducedNumber.Length > initialIndex + 1)
            {
                if (ValidNumberChars.IndexOf(introducedNumber[initialIndex + 1], OnlyNumbers) >= 1)
                {
                    return "Invalid";
                }

                initialIndex++;
            }

            int incrementIndex = 1;

            for (int index = initialIndex; index < introducedNumber.Length; index += incrementIndex)
            {
                incrementIndex = 1;

                if (ValidNumberChars.IndexOf(introducedNumber[index]) == -1)
                {
                    return "Invalid";
                }
            }

            return "Valid";
        }
    }
}
