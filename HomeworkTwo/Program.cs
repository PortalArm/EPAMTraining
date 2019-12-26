using System;
using System.Collections.Generic;

namespace HomeworkTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(NRootFinder.FindRoot(2, 2, 0));
            bool failedInput = true;
            while (failedInput)
            {
                Console.WriteLine("Введите через пробел положительное число, положительную целочисленную степень корня и точность*. (* - опционально)");
                var inputTokens = Console.ReadLine().Split();
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
                }
                else
                    Console.WriteLine("Введены некорректные значения, попробуйте снова.");
            }
            Console.ReadLine();
        }
    }
}
