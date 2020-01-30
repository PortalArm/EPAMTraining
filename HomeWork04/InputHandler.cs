using System;
using System.Linq;

namespace InputHandlerNS
{

    public static class Extension
    {
        public static bool IsNumeric(this string t)
        {
            double d;
            return double.TryParse(t, out d);
        }
    }
    public static class InputHandler
    {
        private static Action<string> _logger = Console.WriteLine;

        //Метод для установки действия, которое будет выполняться для текста (по умолчанию Console.WriteLine)
        public static void SetLogger(Action<string> logger) => _logger = logger;

        //Метод для "компактной" замены блока try-catch-finally
        public static bool HasException<T>(Action _try, Action<T> _catch = null, Action _finally = null) where T : Exception
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
        public static bool HasException(Action _try, Action<Exception> _catch = null, Action _finally = null) => HasException<Exception>(_try, _catch, _finally);

        //TODO: Добавить метод для стопроцентного получения корректных данных из консоли (сделано)
        //      Добавить проверку элемента/ов при помощи анонимных методов (сделано / частично)

        //Метод для получения входных данных, которые представляют массив определенного типа T, из консоли.
        public static T[] GetArrayInputFromConsole<T>(string message, int expectedSize = 0, Func<T, bool> constraint = null, Func<T[], bool> constraints = null, Func<Exception, string> errorMessage = null, char[] delimiter = null)
        {
            T[] output;
            while (!GetArrayInputFromConsole(message, out output, expectedSize, constraint, constraints, errorMessage, delimiter)) ;
            return output;
        }

        public static bool GetArrayInputFromConsole<T>(string message, out T[] output, int expectedSize = 0, Func<T, bool> constraint = null, Func<T[], bool> constraints = null, Func<Exception, string> errorMessage = null, char[] delimiter = null)
        {
            bool isEnum = typeof(T).IsEnum;
            _logger(message);
            char[] realDelim = delimiter ?? new[] { ' ' };
            output = default;
            T[] outs = null;
            if (constraint == null)
                constraint = e => true;

            if (constraints == null)
                constraints = e => true;

            bool result = HasException(
                //Если выходной тип enum, то применяем Enum.Parse
                _try: () => outs = Console.ReadLine().Split(realDelim).Select(w => (T)(isEnum ? Enum.Parse(typeof(T), w.IsNumeric()?null:w, true) : Convert.ChangeType(w, typeof(T)))).ToArray(),
                _catch: (e) => _logger(errorMessage?.Invoke(e))
                );

            if (result)
                return false;

            if (expectedSize != 0 && outs.Length != expectedSize)
            {
                _logger(errorMessage?.Invoke(new InvalidOperationException($"Ожидалась размерность {expectedSize}")));
                return false;
            }

            //Если количество элементов, прошедших проверку, не равно общему количеству или не проходит частная проверка, то конец
            if (outs.Where(constraint).Count() != outs.Count() || !constraints(outs))
            {
                _logger("Входные данные не прошли внешнюю проверку");
                return false;
            }

            output = outs;
            return true;
        }


        public static T GetInputFromConsole<T>(string message, Func<T, bool> constraint = null, Func<Exception, string> errorMessage = null)
        {
            T output;
            while (!GetInputFromConsole(message, out output, constraint, errorMessage)) ;
            return output;
        }
        //Метод для получения входных данных, которые представляют значение типа T, из консоли.
        public static bool GetInputFromConsole<T>(string message, out T output, Func<T, bool> constraint = null, Func<Exception, string> errorMessage = null)
        {
            bool isEnum = typeof(T).IsEnum;
            _logger(message);
            output = default;
            T _out = default;

            if (constraint == null)
                constraint = e => true;

            string input = Console.ReadLine();
            bool result = HasException(
                //Если выходной тип enum, то применяем Enum.Parse
                _try: () => _out = (T)(isEnum ? Enum.Parse(typeof(T), input.IsNumeric() ? null : input, true) : Convert.ChangeType(input, typeof(T))),
                _catch: (e) => _logger(errorMessage?.Invoke(e))
                );

            if (result)
                return false;

            if (!constraint(_out))
            {
                _logger("Входные данные не прошли внешнюю проверку");
                return false;
            }

            output = _out;
            return true;
        }
    }
}
