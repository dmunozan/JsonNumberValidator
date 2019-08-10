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
            const string AllowedJsonNumberChars = ".e0123456789";

            if (string.IsNullOrEmpty(introducedNumber))
            {
                return Invalid;
            }

            string lowerCaseIntroducedNumber = introducedNumber.ToLower();

            int initialIndex = 0;

            if (lowerCaseIntroducedNumber[initialIndex] == '-' && !IsValidMinusSignFormat(lowerCaseIntroducedNumber, initialIndex, out initialIndex))
            {
                return Invalid;
            }

            if (lowerCaseIntroducedNumber[initialIndex] == '0' && !IsValidZeroFormat(lowerCaseIntroducedNumber, initialIndex, out initialIndex))
            {
                return Invalid;
            }

            int incrementIndex;

            for (int index = initialIndex; index < lowerCaseIntroducedNumber.Length; index += incrementIndex)
            {
                incrementIndex = 1;

                if (AllowedJsonNumberChars.IndexOf(lowerCaseIntroducedNumber[index]) == -1)
                {
                    return Invalid;
                }

                if (lowerCaseIntroducedNumber[index] == '.' && !IsValidPointFormat(lowerCaseIntroducedNumber, index, out incrementIndex))
                {
                    return Invalid;
                }
            }

            return Valid;
        }

        public static bool IsValidMinusSignFormat(string lowerCaseIntroducedNumber, int initialIndex, out int newIndex)
        {
            const string AllowedChars = "0123456789";
            newIndex = initialIndex;

            if (lowerCaseIntroducedNumber == null)
            {
                return false;
            }

            bool existNextChar = lowerCaseIntroducedNumber.Length > newIndex + 1;

            if (!existNextChar)
            {
                return false;
            }

            newIndex++;

            return AllowedChars.IndexOf(lowerCaseIntroducedNumber[initialIndex + 1]) >= 0;
        }

        public static bool IsValidZeroFormat(string lowerCaseIntroducedNumber, int initialIndex, out int newIndex)
        {
            const string AllowedChars = ".e";
            newIndex = initialIndex;

            if (lowerCaseIntroducedNumber == null)
            {
                return false;
            }

            bool existNextChar = lowerCaseIntroducedNumber.Length > newIndex + 1;

            if (!existNextChar)
            {
                return true;
            }

            newIndex++;

            return AllowedChars.IndexOf(lowerCaseIntroducedNumber[initialIndex + 1]) >= 0;
        }

        public static bool IsValidPointFormat(string lowerCaseIntroducedNumber, int index, out int incrementIndex)
        {
            const string AllowedChars = "0123456789";
            incrementIndex = 1;

            if (lowerCaseIntroducedNumber == null || index == 0)
            {
                return false;
            }

            bool existNextChar = lowerCaseIntroducedNumber.Length > index + 1;

            if (!existNextChar)
            {
                return false;
            }

            incrementIndex++;
            bool nextCharIsNumber = AllowedChars.IndexOf(lowerCaseIntroducedNumber[index + 1]) >= 0;
            bool noExistAnotherPoint = lowerCaseIntroducedNumber.IndexOf('.', index + 1) == -1;

            return nextCharIsNumber && noExistAnotherPoint;
        }
    }
}
