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
            ChocolateCandy[] chocolCandies = {
                new ChocolateCandy("Заяц", 150, 100),
                new ChocolateCandy("Дед", 200, 120)
            };
            PlatedChocolateCandy[] platedCandies = {
                new PlatedChocolateCandy("Казахстан", 220, 120, 30),
                new PlatedChocolateCandy("Россия", 200, 110, 28),
                new PlatedChocolateCandy("Плитка Один", 250, 170, 32),
                new PlatedChocolateCandy("Плитка Два", 300, 190, 40),
            };
            CaramelCandy caramCandy = new CaramelCandy("Карамелька1", 23, 13);

            var Present = new Present("Прикольный", caramCandy, chocolCandies, platedCandies);
            Console.WriteLine(Present);

            //Отсортировать по 
            Present.Sort(w => w.SugarPercent);
            Console.WriteLine(Present);

            //Найти конфеты с процентным содержанием сахара >=40 и <=60%
            Console.WriteLine("Конфеты в подарке с процентным содержанием сахара >=40 и <=60%:");
            Present.Find(w => w.SugarPercent >= 0.4 && w.SugarPercent <= 0.6).ForEach(w => Console.WriteLine(w));

            Console.ReadLine();
        }
    }
}
