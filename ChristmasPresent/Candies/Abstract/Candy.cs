using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPresent
{
    public abstract class Candy : IEatable
    {
        private double _sugarWeight;
        public string Name { get; set; }
        public double Weight { get; set; }
        public double SugarWeight
        {
            get => _sugarWeight;
            set
            {
                if (value > Weight)
                    throw new ArgumentOutOfRangeException("sugarWeight", value, "Масса сахара должен быть не больше веса конфеты.");

                _sugarWeight = value;
            }
        }
        public double SugarPercent { get => SugarWeight / Weight; }
        protected Candy(string name, double weight, double sugarWeight)
        {
            Name = name;
            Weight = weight;
            SugarWeight = sugarWeight;
        }
        public abstract void Eat();
        public override string ToString() => $"Масса: {Weight}, масса сахара: {SugarWeight}, доля сахара: {Math.Round(SugarPercent, 4)}.";
    }
}
