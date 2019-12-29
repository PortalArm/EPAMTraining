using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPresent
{
    public class ChocolateCandy : Candy
    {
        public ChocolateCandy(string name, double weight, double sugarWeight) : base(name, weight, sugarWeight)
        {
        }
        public override void Eat() => Console.WriteLine("Вы скушали шоколад.");
        public override string ToString() => $"Шоколад '{Name}'. {base.ToString()}";
    }
}
