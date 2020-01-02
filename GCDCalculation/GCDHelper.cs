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
        public static long GCD(long a,long b)
        {
            while(b != 0)
                (a, b) = (b, a % b);

            return a;
        }
        public static long GCD(params long[] values)
        {

        }

    }
}
