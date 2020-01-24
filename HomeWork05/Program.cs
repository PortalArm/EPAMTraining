using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InputHandlerNS;
namespace VectorPolynomial
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task 1
            //double[] values = InputHandler.GetArrayInputFromConsole<double>("Введите три координаты первого вектора", expectedSize: 3);
            //Vector vec1 = new Vector(values[0], values[1], values[2]);
            //values = InputHandler.GetArrayInputFromConsole<double>("Введите три координаты второго вектора", expectedSize: 3);
            //Vector vec2 = new Vector(values[0], values[1], values[2]);
            //double num = InputHandler.GetInputFromConsole<double>("Введите одно число", d => d != 0, errorMessage: _ => "Вы ввели не число. Попробуйте еще раз.");

            //Console.WriteLine("Два вектора:\n{0}\n{1}", vec1, vec2);

            //Console.WriteLine("Сумма векторов: {0}", vec1 + vec2);
            //Console.WriteLine("Разность векторов: {0}", vec1 - vec2);
            //Console.WriteLine("Равенство векторов: {0}", vec1 == vec2);
            //Console.WriteLine("Неравенство векторов: {0}", vec1 != vec2);

            //Console.WriteLine("Умножение вектора {0} на число {1}: {2}", vec1, num, vec1 * num);
            //Console.WriteLine("Деление вектора {0} на число {1}: {2}", vec1, num, vec1 / num);
            //Console.WriteLine("Сложение вектора {0} с числом {1}: {2}", vec1, num, vec1 + num);
            #endregion
            Polynomial p1 = null, p2 = null;
            _ = InputHandler.GetArrayInputFromConsole<double>("Введите сколько угодно чисел для генерации первого полинома",
                constraints: d => !InputHandler.HasException<ArgumentNullException>(
                    _try: () => p1 = new Polynomial(d),
                    _catch: e => Console.WriteLine(e.Message)), 
                errorMessage: e => $"Произошла ошибка, попробуйте еще раз ({e.Message}).");
           
            _ = InputHandler.GetArrayInputFromConsole<double>("Введите сколько угодно чисел для генерации второго полинома", 
                constraints: d => !InputHandler.HasException<ArgumentNullException>(
                    _try: () => p2 = new Polynomial(d),
                    _catch: e => Console.WriteLine(e.Message)),
                errorMessage: e => $"Произошла ошибка, попробуйте еще раз ({e.Message}).");

            Console.WriteLine("Представлены следующие полиномы:\n{0}\n{1}", p1, p2);
            Console.WriteLine("Произведение полиномов: {0}", p1 * p2);
            Console.WriteLine("Сумма полиномов: {0}", p1 + p2);
            Console.WriteLine("Разность полиномов: {0}", p1 - p2);
            Console.Write("Деление полиномов: "); //Если делится нацело, то все нормально
            InputHandler.HasException<InvalidOperationException>(() => Console.WriteLine("{0}", p1 / p2), e => {
                Console.WriteLine(e.Message);
                foreach (string key in e.Data.Keys)
                    Console.WriteLine("{0} = {1}", key, e.Data[key]);
            });

            Console.ReadKey();
        }
    }
}
