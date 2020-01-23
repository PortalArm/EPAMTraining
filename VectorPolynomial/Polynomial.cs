using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorPolynomial
{
    [Serializable]
    class Polynomial : ILoggable
    {
        public double[] Values { get; }
        public bool SuppressLoggerInvoke { get; }
        public double this[int index]
        { get => Values[index]; }
        public int Degree { get => Values.Length; }
        public Action<string> Logger { get; set; } = Console.WriteLine;
        public Polynomial(double[] values, bool suppress = false)
        {
            SuppressLoggerInvoke = suppress;
            if ((values?.Length ?? 0) == 0)
                throw new ArgumentNullException("Многочлен не должен быть нулевой");
            int i = values.Length - 1;
            for (; i >= 0; --i)
                if (values[i] != 0)
                    break;
            if (i == -1)
                throw new ArgumentNullException("Многочлен не должен быть нулевой");
            if (i != values.Length - 1)
            {
                Values = values.Take(i + 1).ToArray();
                //Array.Copy(values, 0, Values, 0, i + 1);
                if(!SuppressLoggerInvoke) Logger("Степень создаваемого многочлена была урезана до " + i);
                return;
            }
            Values = values;
        }

        public static Polynomial operator -(Polynomial a, double b) => a + (-b);
        public static Polynomial operator +(Polynomial a, double b)
        {
            double[] vals = (double[])a.Values.Clone();
            for (int i = 0; i < a.Degree; ++i)
                vals[i] += b;
            return new Polynomial(vals);
        }
        public static Polynomial operator +(double a, Polynomial b) => b + a;
        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            double[] vals = new double[a.Degree > b.Degree ? a.Degree : b.Degree];

            for (int i = 0; i < a.Degree; ++i)
                vals[i] += a[i];
            for (int i = 0; i < b.Degree; ++i)
                vals[i] += b[i];

            return new Polynomial(vals);
        }

        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            double[] vals = new double[a.Degree + b.Degree - 1];

            for (int i = 0; i < a.Degree; ++i)
                for (int j = 0; j < b.Degree; ++j)
                    vals[i + j] += a[i] * b[j];

            return new Polynomial(vals);
        }

        public static Polynomial operator /(Polynomial a, Polynomial b)
        {
            var exc = new InvalidOperationException("Дробные полиномы не поддерживаются данным классом");

            if (a.Degree < b.Degree)
            {
                exc.Data["remainder"] = a;
                exc.Data["divisor"] = b;
                throw exc;
            }

            double[] vals = new double[a.Degree - b.Degree + 1];
            double[] dividend = (double[])a.Values.Reverse().ToArray().Clone();
            double[] divisor = b.Values.Reverse().ToArray();

            for (int i = 0; i < a.Degree - b.Degree + 1; ++i)
            {
                double divMult = dividend[i] / divisor[0];
                for (int j = 0; j < b.Degree; ++j)
                    dividend[i+j] -= divMult * divisor[j];
                vals[vals.Length - 1 - i] = divMult;
            }
            if (dividend.Where(v => v != 0).Any())
            {
                exc.Data["quotient"] = new Polynomial(vals, true);
                exc.Data["remainder"] = new Polynomial(dividend.Reverse().ToArray(),true);
                exc.Data["divisor"] = b;
                throw exc;
            }

            return new Polynomial(vals.ToArray());
        }

        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            double[] vals = new double[a.Degree > b.Degree ? a.Degree : b.Degree];

            for (int i = 0; i < a.Degree; ++i)
                vals[i] += a[i];
            for (int i = 0; i < b.Degree; ++i)
                vals[i] -= b[i];

            return new Polynomial(vals);
        }

        public override string ToString() => string.Join(" ", Values.Select(GetPowerRepresentation).Where(s => !string.IsNullOrWhiteSpace(s))).TrimStart('+', ' ');
        private static string GetPowerRepresentation(double val, int power)
        {
            if (val == 0)
                return "";

            if (power > 1 && val != -1 && val != 1)
                return $"{(val > 0 ? "+" : "") + val}*x^{power}";
            if (power == 0)
                return $"{(val > 0 ? "+" : "") + val}";
            if (power > 1 && (val == -1 || val == 1))
                return $"{(val > 0 ? "+" : "")}x^{power}";
            if ((val == 1 || val == -1) && power == 1)
                return $"{(val > 0 ? "+" : "")}x";
            if (power == 1)
                return $"{(val > 0 ? "+" : "") + val}*x";

            throw new Exception("Это не должно вызваться");
        }
    }
}
