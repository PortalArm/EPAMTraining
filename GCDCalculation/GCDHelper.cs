using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDCalculation
{
    public enum GCDMethod { GCD, BinaryGCD }
    public static class GCDHelper
    {
        private static readonly Stopwatch _stopwatch = new Stopwatch();
        private const int _randomMin = 0, _randomMax = 1024, _defaultBatchSize = 128, _defaultArgumentCount = 2;
        private static readonly Random _rnd = new Random();
        private delegate uint HelperDelegate(params uint[] args);
        /// <summary>
        /// Вычисление НОД двух чисел методом Евклида
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>НОД двух чисел</returns>
        public static uint GCD(uint a, uint b)
        {
            if (a < 0 || b < 0)
                throw new ArgumentOutOfRangeException();

            while (b != 0)
                (a, b) = (b, a % b);

            return a;
        }
        /// <summary>
        /// Вычисление НОД двух чисел методом Стейна
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>НОД двух чисел</returns>
        public static uint BinaryGCD(uint a, uint b)
        {
            if (a < 0 || b < 0)
                throw new ArgumentOutOfRangeException();

            int shift = 0;
            if (a == 0)
                return b;

            if (b == 0)
                return a;

            while (((a | b) & 1) == 0)
            {
                shift++;
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
                a >>= 1;

            do
            {
                while ((b & 1) == 0)
                    b >>= 1;
                if (a > b)
                    (a, b) = (b, a);

                b -= a;
            } while (b != 0);
            return a << shift;
        }

        public static uint GCD(params uint[] values) => CalculateAll(GCD, values);
        public static uint BinaryGCD(params uint[] values) => CalculateAll(BinaryGCD, values);

        /// <summary>
        /// Вычисление НОД определенным методом для произвольного количества чисел
        /// </summary>
        /// <param name="func">Метод вычисления</param>
        /// <param name="values">Список чисел</param>
        /// <returns>НОД чисел</returns>
        private static uint CalculateAll(Func<uint, uint, uint> func, params uint[] values)
        {
            if (values.Length <= 1)
                throw new InvalidOperationException("Количество параметров должно быть больше одного.");

            uint result = values[0];
            for (int i = 1; i < values.Length; ++i)
                result = func(result, values[i]);

            return result;
        }

        /// <summary>
        /// Метод для определения времени работы выбранного алгоритма нахождения НОД(<paramref name="a"/>, <paramref name="b"/>) 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public static TimeSpan GetTime(uint a, uint b, GCDMethod method)
        {
            switch (method)
            {
                case GCDMethod.BinaryGCD:
                    _stopwatch.Start();
                    _ = BinaryGCD(a, b);
                    _stopwatch.Stop();
                    break;
                case GCDMethod.GCD:
                    _stopwatch.Start();
                    _ = GCD(a, b);
                    _stopwatch.Stop();
                    break;
            }

            TimeSpan elapsed = _stopwatch.Elapsed;
            _stopwatch.Reset();
            return elapsed;

        }

        /// <summary>
        /// Вычисление времени работы выбранного алгоритма 
        /// </summary>
        /// <param name="batchSize">Количество итераций</param>
        /// <param name="argumentCount">Количество аргументов</param>
        /// <param name="method">Алгоритм</param>
        /// <param name="randomMin">Минимальное значение чисел, использующихся в алгоритме</param>
        /// <param name="randomMax">Максимальное значение чисел, использующихся в алгоритме</param>
        /// <returns>Время, затраченное на вычисления</returns>
        public static TimeSpan GetRandomBatchTime(int batchSize = _defaultBatchSize, int argumentCount = _defaultArgumentCount, GCDMethod method = GCDMethod.GCD, int randomMin = _randomMin, int randomMax = _randomMax)
        {
            if (batchSize < 1 || argumentCount < 2 || randomMin < 0)
                throw new ArgumentOutOfRangeException();

            // (4 * batchSize * argumentCount) bytes if cached
            uint[][] values = new uint[batchSize][];
            for (int i = 0; i < batchSize; ++i)
                values[i] = (new uint[argumentCount]).Select(val => (uint)_rnd.Next(randomMin, randomMax)).ToArray();

            HelperDelegate helper = null;
            switch (method)
            {
                case GCDMethod.BinaryGCD:
                    helper = BinaryGCD;
                    break;
                case GCDMethod.GCD:
                    helper = GCD;
                    break;
            }
            _stopwatch.Start();
            for (int i = 0; i < batchSize; ++i)
                _ = helper(values[i]);
            _stopwatch.Stop();
            TimeSpan elapsed = _stopwatch.Elapsed;
            _stopwatch.Reset();
            return elapsed;
        }

    }
}
