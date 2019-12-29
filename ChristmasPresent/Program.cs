using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPresent
{
    class Program
    {
        static void Main(string[] args)
        {
            ChocolateCandy chocolCandy1 = new ChocolateCandy("Заяц", 150, 100),
                chocolCandy2 = new ChocolateCandy("Дед", 200, 120);
            var caramCandy = new CaramelCandy("Карамелька1",23,13);

            var Present = new Present("Прикольный", chocolCandy1, chocolCandy2, caramCandy);
            Console.WriteLine(Present);
            Present.Sort(w => w.SugarPercent);
            Console.WriteLine(Present);

            //Найти конфеты с процентным содержанием сахара >=40 и <=60%
            Console.WriteLine("Конфеты в подарке с процентным содержанием сахара >=40 и <=60%:");
            Present.Find(w => w.SugarPercent >= 0.4 && w.SugarPercent <= 0.6).ForEach(w => Console.WriteLine(w));

            Console.ReadLine();
        }
    }
}
