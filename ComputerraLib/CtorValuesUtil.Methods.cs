using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraLib
{
    public static partial class CtorValuesUtil
    {
        private readonly static Random _random = new Random();

        public static string GetRandomName() => _names[_random.Next(_names.Length)];
        public static int GetRandomSalary() => _salaries[_random.Next(_salaries.Length)];
        public static bool GetRandomMood() => _random.NextDouble() >= 0.5;
        public static Point GetRandomPoint(int maxX, int maxY) => new Point(_random.Next(maxX), _random.Next(maxY));
        


    }
}
