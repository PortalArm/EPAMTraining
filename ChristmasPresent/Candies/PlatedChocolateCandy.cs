using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPresent
{
    public class PlatedChocolateCandy : Candy
    {
        public int PlateCount { get; set; }
        public PlatedChocolateCandy(string name, double weight, double sugarWeight, int plateCount) : base(name, weight, sugarWeight)
        {
            PlateCount = plateCount;
        }
        public override void Eat() => Console.WriteLine("Вы скушали шоколадную плитку.");
        public override string ToString() => $"Шоколадная плитка '{Name}'. {base.ToString()} Количество плиток: {PlateCount}.";
    }
}
