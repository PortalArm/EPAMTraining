using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPresent
{
    public class Present
    {
        public double SumWeight { get => Candies.Sum(candy => candy.Weight); }
        public List<Candy> Candies { get; set; } = new List<Candy>();
        public string Name { get; set; }
        public Present(string name, params object[] candies)
        {
            Name = name;
            AddCandies(candies);
        }

        public void AddCandy(Candy candy) => Candies.Add(candy);
        public void AddCandies(params object[] candies)
        {
            foreach (object candy in candies)
                switch (candy)
                {
                    case IEnumerable<Candy> manyCandies:
                        foreach (object c in manyCandies)
                            AddCandies(c);
                        break;
                    case Candy singleCandy when singleCandy != null:
                        AddCandy(singleCandy);
                        break;
                    default:
                        throw new InvalidOperationException("В подарок можно добавить только конфеты, либо списки конфет.");
                }
        }

        public void Sort<TProp>(Func<Candy, TProp> func) => Candies = Candies.OrderBy(func).ToList();
        public List<Candy> Find(Func<Candy, bool> func) => Candies.Where(func).ToList();
        public List<Candy> FindBySugarPercent(double minPercent, double maxPercent) => Find(w => w.SugarPercent >= minPercent && w.SugarPercent <= maxPercent);
        public List<Candy> FindBySugarWeight(double minWeight, double maxWeight) => Find(w => w.SugarWeight >= minWeight && w.SugarWeight <= maxWeight);
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"Подарок '{Name}', общий вес: {SumWeight}:{Environment.NewLine}");
            Candies.ForEach(w => sb.Append(w + Environment.NewLine));
            return sb.ToString();
        }
    }

}
