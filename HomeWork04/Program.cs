using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork04
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = null;
            double[] doubles;

            //Проверка ввода: Если введены не числа, количество чисел не 3, то выведется ошибка
            //Далее, если действительно введены три числа, во второй части условия проверяется, может ли быть создан треугольник с такими длинами. 
            //Если все проверки соблюдены, выводится объект (вся информация о нем, переопределен метод ToString)
            while (!InputHandler.GetArrayInputFromConsoleOneLine("Введите 3 числа", out doubles, expectedSize: 3, errorMessage: (e) => $"Вы ввели неверные числа ({e.Message})") ||
                InputHandler.Catch<ArgumentException>(() => { triangle = new Triangle(doubles[0], doubles[1], doubles[2]); }, (e) => Console.WriteLine(e.Message)));
            Console.WriteLine(triangle);
            Console.ReadKey();
        }
    }
}
