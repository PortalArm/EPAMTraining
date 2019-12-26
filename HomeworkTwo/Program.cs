using System;
using System.Collections.Generic;

namespace HomeworkTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            //StringBuilder sb = new StringBuilder(string.Empty); 
            //string w = string.Empty;
            //GC.Collect();
            //Console.WriteLine(GC.GetTotalMemory(false));
            //for (int i = 0; i < 10000; ++i)
            //w = "0" + w;
            //sb.Insert(0,'0');
            //Console.WriteLine(GC.GetTotalMemory(false));

            bool failedInput = true;
            #region Task1

            while (failedInput)
            {
                Console.WriteLine("Введите через пробел положительное число, положительную целочисленную степень корня и точность*. (* - опционально)");
                var inputTokens = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                double eps = double.NaN;
                if (double.TryParse(inputTokens[0], out double num) && int.TryParse(inputTokens[1], out int power) &&
                    (inputTokens.Length < 3 || double.TryParse(inputTokens[2], out eps)))
                {
                    Dictionary<string, double> results = inputTokens.Length == 2 ? NRootFinder.CompareResults(num, power) : NRootFinder.CompareResults(num, power, eps);
                    Console.WriteLine($"{num}^(1/{power}) = {results["NewtonPow"]}");
                    Console.WriteLine("Сравнение с методом Math.Pow:");
                    foreach (var kv in results)
                        Console.WriteLine(kv);

                    failedInput = false;
                } else
                    Console.WriteLine("Введены некорректные значения, попробуйте снова.");
            }
            #endregion

            #region Task2
            failedInput = true;

            while (failedInput)
            {
                Console.WriteLine("Введите положительное целочисленное число, которое нужно перевести в двоичную систему.");
                if (uint.TryParse(Console.ReadLine(), out uint result))
                {
                    BinaryUInt bu1 = new BinaryUInt(result), bu2 = new BinaryUInt(result, ConversionMethod.ImplementedMethod);
                    Console.WriteLine($@"Число {result} в двоичной системе:
Стандартный метод:  {bu1.BinaryValue}
Свой метод:         {bu2.BinaryValue}");
                    failedInput = false;
                } else
                    Console.WriteLine("Введено некорректное значение, попробуйте снова.");
            }
            #endregion
            Console.ReadLine();
        }
    }
}