using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork04
{
    public enum AngleType { Degrees, Radians }
    class Triangle
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

        private Dictionary<double, double> _angles = new Dictionary<double, double>();
        public double Perimeter { get; }
        public double Area { get; }
        public Triangle(double a, double b, double c)
        {
            if (a >= b + c || b >= a + c || c >= a + b || a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Треугольник с введенными длинами должен существовать");

            A = a; B = b; C = c;
            Perimeter = checked(A + B + C);

            //Нахождение площади
            double halfp = Perimeter / 2;
            Area = Math.Sqrt(checked(halfp * (halfp - A) * (halfp - B) * (halfp - C)));
            if (double.IsInfinity(Perimeter) || double.IsInfinity(Area))
                throw new OverflowException("Были введены слишком большие данные");

            //Отображение углов к соответствующим сторонам
            if (!_angles.ContainsKey(A))
                _angles.Add(A, GetAngle(A, B, C));

            if (!_angles.ContainsKey(B))
                _angles.Add(B, GetAngle(B, A, C));

            if (!_angles.ContainsKey(C))
                _angles.Add(C, GetAngle(C, B, A));
        }

        // Вспомогательный приватный метод, который возвращает значение угла (в радианах), противолежащего стороне mainSide, с другими сторонами a и b.
        private static double GetAngle(double mainSide, double a, double b) => Math.Acos(checked((a * a + b * b - mainSide * mainSide) / (2 * a * b)));

        //Возвращает значение угла, противолежащего стороне sideValue (в градусах/радианах, в зависимости от второго параметра).
        public double GetAngle(double sideValue, AngleType type = AngleType.Degrees)
        {
            if (!_angles.TryGetValue(sideValue, out double angle))
                throw new ArgumentException($"Не найдена сторона с длиной {sideValue}", "sideValue");

            switch (type)
            {
                //т.к. Math.Acos возвращает значение в радианах, для перевода в градусы достаточно умножить на 180 и разделить на Пи
                case AngleType.Degrees:
                    return angle * 180d / Math.PI;
                case AngleType.Radians:
                    return angle;
                default:
                    throw new ArgumentException($"Не найден тип угла", "type");
            }
        }
        public override string ToString() => string.Format(@"Треугольник со сторонами:                  {0,10} {1,10} {2,10}
Угол, противолежащий стороне (в радианах): {3,10:0.00000} {4,10:0.00000} {5,10:0.00000}
Угол, противолежащий стороне (в градусах): {6,10:0.00000} {7,10:0.00000} {8,10:0.00000}
Периметр: {9}
Площадь: {10}", A, B, C,
            GetAngle(A, AngleType.Radians), GetAngle(B, AngleType.Radians), GetAngle(C, AngleType.Radians),
            GetAngle(A), GetAngle(B), GetAngle(C),
            Perimeter, Area);
    }
}