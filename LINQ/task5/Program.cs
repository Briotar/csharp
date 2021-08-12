using System;
using System.Collections.Generic;
using System.Linq;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Stew> stews = new List<Stew>
            {
                new Stew("Stew common", 1950, 50),
                new Stew("Stew common", 1960, 50),
                new Stew("Stew epic", 1970, 60),
                new Stew("Stew common", 1955, 50),
                new Stew("Stew uncommon", 1950, 50),
                new Stew("Stew epic", 1900, 150),
                new Stew("Stew uncommon", 2000, 5),
            };
            int year = System.DateTime.Now.Year;

            var overdueStews = stews.Where(stew => stew.ProductionYear + stew.ShelfLife < year);

            foreach (var stew in overdueStews)
            {
                stew.ShowInfo();
            }
        }
    }

    class Stew
    {
        public string Name { get; private set; }
        public int ProductionYear { get; private set; }
        public int ShelfLife { get; private set; }

        public Stew(string name, int productionYear, int shelfLife)
        {
            Name = name;
            ProductionYear = productionYear;
            ShelfLife = shelfLife;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name - {Name}, production year - {ProductionYear}, shelf life - {ShelfLife}");
        }
    }
}
