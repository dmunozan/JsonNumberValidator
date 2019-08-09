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
            const string Valid = "Valid";
            const string Invalid = "Invalid";
            const int OnlyNumbers = 1;
            const string ValidNumberChars = ".0123456789";

            if (introducedNumber == null)
            {
                return Invalid;
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
                    return Invalid;
                }

                initialIndex++;
            }

            int incrementIndex = 1;

            for (int index = initialIndex; index < introducedNumber.Length; index += incrementIndex)
            {
                incrementIndex = 1;

                if (ValidNumberChars.IndexOf(introducedNumber[index]) == -1)
                {
                    return Invalid;
                }

                if (introducedNumber[index] == '.' && !IsValidPointFormat(introducedNumber, index, out incrementIndex))
                {
                    return Invalid;
                }
            }

            return Valid;
        }

        public static bool IsValidPointFormat(string introducedNumber, int index, out int incrementIndex)
        {
            const int OnlyNumbers = 1;
            const string ValidNumberChars = ".0123456789";
            incrementIndex = 1;

            if (introducedNumber == null || index == 0)
            {
                return false;
            }

            incrementIndex++;

            return introducedNumber.Length > index + 1 && ValidNumberChars.IndexOf(introducedNumber[index + 1], OnlyNumbers) >= 1;
        }
    }
}
