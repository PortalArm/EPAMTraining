using System;
using System.Globalization;
using System.Linq;

namespace ConsoleFormatting
{
    class Program
    {
        /// <summary>
        /// Программа, выполняющая форматирование координат и реализующая класс "Матрица"
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region Task1

            CultureInfo inputCulture = CultureInfo.CreateSpecificCulture("en-us"),
                outputCulture = CultureInfo.CreateSpecificCulture("ru-ru");

            string inputString = "\0";

            while (!string.IsNullOrEmpty(inputString = Console.ReadLine()))
            {
                var decimalStringValues = inputString.Split(',').Select(w => decimal.Parse(w, inputCulture).ToString(outputCulture)).ToArray();
                Console.WriteLine("X: {0} Y: {1}", decimalStringValues[0], decimalStringValues[1]);
            }

            #endregion

            #region Task2

            Matrix matr1 = new Matrix(2, 3); matr1.FillRandom();
            Matrix matr2 = new Matrix(3, 4); matr2.FillRandom();
            matr1.Print();
            Console.WriteLine();
            matr2.Print();
            Console.WriteLine();
            (matr1 * matr2).Print();

            #endregion
            Console.ReadLine();
        }
    }
}
