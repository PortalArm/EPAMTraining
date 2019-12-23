﻿using System;
using System.Globalization;
using System.Linq;

namespace ConsoleFormatting
{
    class Program
    {
        static void Main(string[] args)
        {
            //CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator = ",";
            CultureInfo inputCulture = CultureInfo.CreateSpecificCulture("en-us"),
                outputCulture = CultureInfo.CreateSpecificCulture("ru-ru");

            string inputString = "\0";

            while ((inputString = Console.ReadLine()) != string.Empty)
            { 
                var decimalStringValues = inputString.Split(',').Select(w => decimal.Parse(w, inputCulture).ToString(outputCulture)).ToArray();
                Console.WriteLine("X: {0} Y: {1}", decimalStringValues[0], decimalStringValues[1]);

            }

        }
    }
}
