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
            const int Zero = 48;
            const int OnlyNumbers = 1;
            const string ValidNumberChars = ".0123456789";

            if (introducedNumber == null)
            {
                return "Invalid";
            }

            int initialIndex = 0;

            if (introducedNumber[0] == '-')
            {
                initialIndex++;
            }

            for (int index = initialIndex; index < introducedNumber.Length; index++)
            {
                if (ValidNumberChars.IndexOf(introducedNumber[index]) == -1)
                {
                    return "Invalid";
                }

                if (introducedNumber[index] == Zero && index == initialIndex && introducedNumber.Length > index + 1 && ValidNumberChars.IndexOf(introducedNumber[index + 1], OnlyNumbers) >= 1)
                {
                    return "Invalid";
                }
            }

            return "Valid";
        }
    }
}
