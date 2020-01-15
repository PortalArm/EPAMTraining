using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public static class InputHandler
    {

        private static Action<string> _logger = Console.WriteLine;

        //Метод для установки действия, которое будет выполняться для текста
        public static void SetLogger(Action<string> logger) => _logger = logger;

        //Метод для "компактной" замены блока try-catch-finally
        public static bool Catch<T>(Action _try, Action<T> _catch = null, Action _finally = null) where T : Exception
        {
            bool error = false;

            try { _try(); }
            catch (T e)
            {
                error = true;
                _catch?.Invoke(e);
            }
            finally { _finally?.Invoke(); }

            return error;
        }
        public static bool CatchAny(Action _try, Action<Exception> _catch = null, Action _finally = null) => Catch(_try, _catch, _finally);

        //Метод для получения входных данных, которые представляют массив определенного типа T, из консоли.
        public static bool GetArrayInputFromConsoleOneLine<T>(string message, out T[] output, int expectedSize = 0, Func<Exception, string> errorMessage = null, char[] delimiter = null)
        {
            _logger(message);
            char[] realDelim = delimiter ?? new[] { ' ' };
            output = default;
            T[] outs = null;
            bool result = CatchAny(
                _try:   () => outs = Console.ReadLine().Split(realDelim).Select(w => (T)Convert.ChangeType(w, typeof(T))).ToArray(),
                _catch: (e) => _logger(errorMessage?.Invoke(e))
                );

            if (result)
                return false;

            if (expectedSize != 0 && outs.Length != expectedSize)
            {
                _logger(errorMessage?.Invoke(new InvalidOperationException($"Ожидалась размерность {expectedSize}")));
                return false;
            }

            output = outs;
            return true;
        }

        //Метод для получения входных данных, которые представляют значение типа T, из консоли.
        public static bool GetInputFromConsoleOneLine<T>(string message, out T output, Func<Exception, string> errorMessage = null)
        {
            _logger(message);
            output = default;
            T _out = default;

            bool result = CatchAny(
                _try:   () => _out = (T)Convert.ChangeType(Console.ReadLine(), typeof(T)),
                _catch: (e) => _logger(errorMessage?.Invoke(e))
                );

            if (result)
                return false;

            output = _out;
            return true;
        }
    }
}
