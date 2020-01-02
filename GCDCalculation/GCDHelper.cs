using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDCalculation
{
    public static class GCDHelper
    {
        private static readonly Stopwatch _stopwatch = new Stopwatch();

        /// <summary>
        /// Вычисление НОД для двух чисел
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>НОД двух чисел</returns>
        public static long GCD(long a, long b)
        {
            if (a < 0 || b < 0)
                throw new ArgumentOutOfRangeException();

            while (b != 0)
                (a, b) = (b, a % b);

            return a;
        }

        /// <summary>
        /// Вычисление НОД для произвольного количества чисел
        /// </summary>
        /// <param name="values">Список чисел</param>
        /// <returns>НОД чисел</returns>
        public static long GCD(params long[] values)
        {
            if (values.Length <= 1)
                throw new InvalidOperationException("Количество параметров должно быть больше одного.");

            long result = values[0];
            for (int i = 1; i < values.Length; ++i)
                result = GCD(result, values[i]);

            return result;
        }

        public static long EfficientGCD()
        {
            return 0;
        }

    }
}
