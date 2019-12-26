using System;
using System.Collections.Generic;

namespace HomeworkTwo
{
    /// <summary>
    /// Helper class 
    /// </summary>
    public static class NRootFinder
    {
        /// <summary>
        /// Maximum number of iterations of the method
        /// </summary>
        private const double _maxIterations = 10000;

        /// <summary>
        /// Used to find the value of <paramref name="number"/> to the power of 1/<paramref name="inversePower"/>.
        /// </summary>
        /// <param name="number">Number to be raised to a certain power.</param>
        /// <param name="inversePower">Integer number indicating which power to use. <example>If 2 is sent, the number will be raised in 1/2 power.</example> </param>
        /// <param name="eps">Value indicating how precise the method will work.</param>
        public static double FindRoot(double number, int inversePower, double eps = 0.0001)
        {
            if (number <= 0 || inversePower < 1)
                throw new InvalidOperationException("Число должно быть положительное, степень должна быть больше нуля");

            // Начальное приближение
            double current = number / inversePower, prev;
            int count = 0;
            do
            {
                prev = current;
                current = 1.0 / inversePower * ((inversePower - 1) * prev + number / FindPow(prev, inversePower - 1));
            }
            while (!IsEnough(prev, current, eps) && ++count < _maxIterations);
            return current;
        }

        /// <summary>
        /// Used to find the <paramref name="number"/> raised to a certain <paramref name="power"/>
        /// </summary>
        /// <param name="number"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        private static double FindPow(double number, int power)
        {
            double temp = number;
            double result = 1;
            while (power != 0)
            {
                if (power % 2 == 1)
                    result *= temp;

                temp *= temp;
                power /= 2;
            }
            return result;
        }

        /// <summary>
        /// Used to retrieve information about two methods of raising <paramref name="number"/> to the power of 1/<paramref name="inversePower"/>
        /// Following dictionary object is returned:
        /// <list type="table">
        /// <listheader>
        /// <term>Key name</term>
        /// <description>Value</description>
        /// </listheader>
        /// <item>
        /// <term> "NewtonPow" </term>
        /// <description> Result from Newton's method</description>
        /// </item>
        /// <item>
        /// <term> "MathPow" </term>
        /// <description> Result from Math.Pow method</description>
        /// </item>
        /// <item>
        /// <term> "Difference" </term>
        /// <description> Positive difference between the two results</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="number"></param>
        /// <param name="inversePower"></param>
        /// <param name="eps"></param>
        /// <returns></returns>
        public static Dictionary<string, double> CompareResults(double number, int inversePower, double eps = 0.0001)
        {
            double newtonPow = FindRoot(number, inversePower, eps),
                mathPow = Math.Pow(number, 1.0 / inversePower);

            return new Dictionary<string, double>() {
                { "NewtonPow" , newtonPow },
                { "MathPow", mathPow },
                { "Difference", Math.Abs(newtonPow - mathPow) }
            }; ;
        }

        /// <summary>
        /// Tells if the difference between <paramref name="x1"/> and <paramref name="x2"/> is less than <paramref name="eps"/>
        /// </summary>
        /// <param name="x1">First number</param>
        /// <param name="x2">Second number</param>
        /// <param name="eps">Threshold value</param>
        /// <returns>Returns if the difference between <paramref name="x1"/> and <paramref name="x2"/> is less than <paramref name="eps"/></returns>
        private static bool IsEnough(double x1, double x2, double eps) => ((x1 - x2) * (x1 - x2) < eps * eps);

    }
}
