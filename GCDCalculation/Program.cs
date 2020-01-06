using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GCDCalculation
{
    class Program
    {

        static void Main(string[] args)
        {
            (uint a, uint b) = ProcessInput("Введите два числа");

            Console.WriteLine($"НОД чисел {a} и {b} методом Евклида: {GCDHelper.GCD(a,b)}");
            Console.WriteLine($"НОД чисел {a} и {b} методом Стейна: {GCDHelper.BinaryGCD(a,b)}");
            int batch = 2048, 
                argCount = 2,
                randMax = 2 << 7;
            TimeSpan gcd = GCDHelper.GetRandomBatchTime(batchSize: batch, argumentCount: argCount, method: GCDMethod.GCD, randomMax: randMax),
                bingcd = GCDHelper.GetRandomBatchTime(batchSize: batch, argumentCount: argCount, method: GCDMethod.BinaryGCD, randomMax: randMax);

            Console.WriteLine($@"Время, затраченное на вычисление {batch} случайных НОД {argCount} аргументов:
Метод Евклида: {gcd.TotalMilliseconds}
Метод Стейна: {bingcd.TotalMilliseconds}");

            var renderer = new ChartRenderer();
            renderer.SetDataLegend("GCD", "Binary GCD");
            renderer.Render(gcd, bingcd, Orientation.Vertical);

            Console.ReadKey();
            renderer.TerminateThread();
        }
        static (uint, uint) ProcessInput(string welcomeString)
        {
            Console.WriteLine(welcomeString);
            var inputTokens = Console.ReadLine().Split().Select(w => Convert.ToUInt32(w)).ToList();
            return (inputTokens[0], inputTokens[1]);
        }
    }
}
