using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork04
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task 1
            //Triangle triangle = null;
            //double[] doubles;
            //Проверка ввода: Если введены не числа, количество чисел не 3, то выведется ошибка
            //Далее, если действительно введены три числа, во второй части условия проверяется, может ли быть создан треугольник с такими длинами. 
            //Если все проверки соблюдены, выводится объект (вся информация о нем, переопределен метод ToString)
            //while (!InputHandler.GetArrayInputFromConsoleOneLine("Введите 3 числа", out doubles, expectedSize: 3, errorMessage: (e) => $"Вы ввели неверные числа ({e.Message})") ||
            //    InputHandler.Catch<ArgumentException>(() => { triangle = new Triangle(doubles[0], doubles[1], doubles[2]); }, (e) => Console.WriteLine(e.Message)));
            //Console.WriteLine(triangle);
            #endregion

            #region Task 2
            //string[] name = null;
            //int year;
            //Gender gend;
            //Qualification qual;
            //while(!InputHandler.GetArrayInputFromConsoleOneLine("Введите ваше ФИО", out name, expectedSize: 3, _ => "Необходимо корректное ФИО"));
            //string fio = string.Join(" ", name);
            //while (!InputHandler.GetInputFromConsoleOneLine("Введите год рождения", out year, e => $"Введен некорректное значение ({e.Message})"));
            //while (!InputHandler.GetInputFromConsoleOneLine($"Введите пол ({string.Join(", ", Enum.GetNames(typeof(Gender)))})", out gend, e => $"Введен некорректное значение ({e.Message})")) ;
            //while (!InputHandler.GetInputFromConsoleOneLine($"Введите квалификацию ({string.Join(", ", Enum.GetNames(typeof(Qualification)))})", out qual, e => $"Введен некорректное значение ({e.Message})")) ;
            //Employee empl = new Employee(fio, year, gend, qual);
            //Console.WriteLine($"Зарплата работника {empl.Name}: {empl.Salary}");
            #endregion
            
            #region Task 3
            //TextInfo ti = null;
            //Console.WriteLine("Введите 'file', чтобы считать с файла, 'console', чтобы считать с консоли");
            //string input = Console.ReadLine();
            //switch (input.ToLower())
            //{
            //    case "file":
            //        Console.WriteLine("Введите имя файла");
            //        StreamReader sr = null;
            //        while (InputHandler.CatchAny(() => sr = new StreamReader(Console.ReadLine()), e => Console.WriteLine($"Попробуйте еще раз ({e.Message})"))) ;
            //        ti = new TextInfo(sr);
            //        sr.Close();
            //        break;
            //    case "console":
            //        Console.WriteLine("Вводите предложения. Нажмите Enter + Ctrl+Z + Enter, чтобы закончить.");
            //        ti = new TextInfo(Console.In);
            //        break;
            //}
            //Console.WriteLine(ti);
            #endregion
            Console.ReadKey();
        }
    }
}
