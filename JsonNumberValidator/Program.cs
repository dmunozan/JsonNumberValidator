﻿using System;
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
            const string ValidNumberChars = ".0123456789";

            if (string.IsNullOrEmpty(introducedNumber))
            {
                return Invalid;
            }

            int initialIndex = 0;

            if (introducedNumber[initialIndex] == '-')
            {
                initialIndex++;
            }

            if (introducedNumber[initialIndex] == '0' && !IsValidZeroFormat(introducedNumber, initialIndex, out initialIndex))
            {
                return Invalid;
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

        public static bool IsValidZeroFormat(string introducedNumber, int initialIndex, out int newIndex)
        {
            const char Point = '.';
            newIndex = initialIndex;

            if (introducedNumber == null)
            {
                return false;
            }

            bool existNextChar = introducedNumber.Length > newIndex + 1;

            if (!existNextChar)
            {
                return true;
            }

            newIndex++;

            return introducedNumber[initialIndex + 1] == Point;
        }

        public static bool IsValidPointFormat(string introducedNumber, int index, out int incrementIndex)
        {
            const string ValidNumberChars = "0123456789";
            incrementIndex = 1;

            if (introducedNumber == null || index == 0)
            {
                return false;
            }

            bool existNextChar = introducedNumber.Length > index + 1;

            if (!existNextChar)
            {
                return false;
            }

            incrementIndex++;
            bool nextCharIsNumber = ValidNumberChars.IndexOf(introducedNumber[index + 1]) >= 1;
            bool noExistAnotherPoint = introducedNumber.IndexOf('.', index + 1) == -1;

            return nextCharIsNumber && noExistAnotherPoint;
        }
    }
}
