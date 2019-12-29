using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPresent
{
    public class CaramelCandy : Candy
    {
        public CaramelCandy(string name, double weight, double sugarWeight) : base(name, weight, sugarWeight)
        {
        }
        public override void Eat() => Console.WriteLine("Вы скушали карамельку.");
        public override string ToString() => $"Карамель '{Name}'. {base.ToString()}";
    }
}
