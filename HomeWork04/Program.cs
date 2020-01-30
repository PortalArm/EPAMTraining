using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using InputHandlerNS;
namespace HomeWork04
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task 1
            Triangle triangle = null;
            //Проверка ввода: Если введены не числа, количество чисел не 3, то выведется ошибка
            //Далее, если действительно введены три числа, во второй части условия проверяется, может ли быть создан треугольник с такими длинами. 
            //Если все проверки соблюдены, выводится объект (вся информация о нем, переопределен метод ToString)

            InputHandler.GetArrayInputFromConsole<double>("Введите 3 числа",
                expectedSize: 3,
                constraints: w => !InputHandler.HasException(() => { triangle = new Triangle(w[0], w[1], w[2]); }, (e) => Console.WriteLine($"{e.GetType()}, {e.Message}")),
                errorMessage: (e) => $"Вы ввели неверные числа ({e.Message})");

            Console.WriteLine(triangle);
            #endregion

            #region Task 2
            string[] name = null;
            int year;
            Gender gend;
            Qualification qual;

            //Новый формат чтения
            name = InputHandler.GetArrayInputFromConsole<string>("Введите ваше ФИО через пробел в одной строке", expectedSize: 3, errorMessage: _ => "Необходимо корректное ФИО");
            string fio = string.Join(" ", name);
            year = InputHandler.GetInputFromConsole<int>("Введите год рождения", errorMessage: e => $"Введено некорректное значение ({e.Message})");
            gend = InputHandler.GetInputFromConsole<Gender>($"Введите пол ({string.Join(", ", Enum.GetNames(typeof(Gender)))})", errorMessage: e => $"Введено некорректное значение ({e.Message})");
            qual = InputHandler.GetInputFromConsole<Qualification>($"Введите квалификацию ({string.Join(", ", Enum.GetNames(typeof(Qualification)))})", errorMessage: e => $"Введено некорректное значение ({e.Message})");

            Employee empl = new Employee(fio, year, gend, qual);
            Console.WriteLine($"Зарплата работника {empl.Name}: {empl.Salary}");
            #endregion

            #region Task 3
            //abc.txt - Случайный текст

            TextInfo ti = null;
            Console.WriteLine("Введите 'file', чтобы считать с файла, 'console', чтобы считать с консоли");
            string input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "file":
                    //Console.WriteLine("Введите имя файла");
                    StreamReader sr = null;
                    InputHandler.GetInputFromConsole<string>("Введите имя файла (либо полный путь, либо относительный путь (abc.txt - случайный текст))", s => !InputHandler.HasException(() => sr = new StreamReader(s), e => Console.WriteLine($"Попробуйте еще раз ({e.Message})")));

                    ti = new TextInfo(sr);
                    sr.Close();
                    break;
                case "console":
                    Console.WriteLine("Вводите предложения. Нажмите Enter + Ctrl+Z + Enter, чтобы закончить.");
                    ti = new TextInfo(Console.In);
                    break;
            }
            Console.WriteLine(ti);
            #endregion

            Console.ReadKey();
        }
    }
}
