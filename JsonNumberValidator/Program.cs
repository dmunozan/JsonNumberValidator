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

            if (!IsValidMinusSignFormat(lowerCaseIntroducedNumber, initialIndex, out initialIndex))
            {
                return Invalid;
            }

            if (!IsValidZeroFormat(lowerCaseIntroducedNumber, initialIndex, out initialIndex))
            {
                return Invalid;
            }

            int incrementIndex;

            for (int index = initialIndex; index < lowerCaseIntroducedNumber.Length; index += incrementIndex)
            {
                if (AllowedJsonNumberChars.IndexOf(lowerCaseIntroducedNumber[index]) == -1)
                {
                    return Invalid;
                }

                if (!IsValidPointFormat(lowerCaseIntroducedNumber, index, out incrementIndex))
                {
                    return Invalid;
                }

                if (!IsValidEFormat(lowerCaseIntroducedNumber, index, out incrementIndex))
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

            if (lowerCaseIntroducedNumber[initialIndex] != '-')
            {
                return true;
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

            if (lowerCaseIntroducedNumber[initialIndex] != '0')
            {
                return true;
            }

            newIndex++;

            bool existNextChar = lowerCaseIntroducedNumber.Length > newIndex;

            if (!existNextChar)
            {
                return true;
            }

            return AllowedChars.IndexOf(lowerCaseIntroducedNumber[initialIndex + 1]) >= 0;
        }

        public static bool IsValidPointFormat(string lowerCaseIntroducedNumber, int index, out int incrementIndex)
        {
            const string AllowedChars = "0123456789";
            incrementIndex = 1;

            if (lowerCaseIntroducedNumber == null)
            {
                return false;
            }

            if (lowerCaseIntroducedNumber[index] != '.')
            {
                return true;
            }

            bool pointOnFirstPosition = index == 0;
            bool existNextChar = lowerCaseIntroducedNumber.Length > index + 1;

            if (pointOnFirstPosition || !existNextChar)
            {
                return false;
            }

            incrementIndex++;

            bool nextCharIsNumber = AllowedChars.IndexOf(lowerCaseIntroducedNumber[index + 1]) >= 0;
            bool noExistAnotherPoint = lowerCaseIntroducedNumber.IndexOf('.', index + 1) == -1;

            return nextCharIsNumber && noExistAnotherPoint;
        }

        public static bool IsValidEFormat(string lowerCaseIntroducedNumber, int index, out int incrementIndex)
        {
            const string AllowedChars = "-+0123456789";
            incrementIndex = 1;

            if (lowerCaseIntroducedNumber == null)
            {
                return false;
            }

            if (lowerCaseIntroducedNumber[index] != 'e')
            {
                return true;
            }

            bool existNextChar = lowerCaseIntroducedNumber.Length > index + 1;

            if (!existNextChar)
            {
                return false;
            }

            incrementIndex++;

            return AllowedChars.IndexOf(lowerCaseIntroducedNumber[index + 1]) >= 0;
        }
    }
}
