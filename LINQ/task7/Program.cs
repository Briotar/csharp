using System;
using System.Collections.Generic;
using System.Linq;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Solder> solders = new List<Solder>
            {
                new Solder("Vova", "sergeant", "gun", 12),
                new Solder("Vlad", "sergeant", "machinegun", 13),
                new Solder("Boris", "lieutenant", "rifle", 14),
                new Solder("Mike", "sergeant", "gun", 15),
                new Solder("Nikita", "lieutenant", "machinegun", 16),
                new Solder("Danya", "major", "rifle", 17),
            };
            List<Solder> solders2 = new List<Solder>
            {
                new Solder("Bivor", "major", "gun", 20)
            };

            var soldersNameB = solders.Where(solder => solder.Name.StartsWith("B")).ToList();

            for (int i = 0; i < soldersNameB.Count; i++)
            {
                solders2.Add(soldersNameB[i]);
            }

            for (int i = 0; i < solders2.Count; i++)
            {
                solders2[i].ShowInfo();
            }
        }
    }
    class Solder
    {
        public string Name { get; private set; }
        public string Rank { get; private set; }
        public string Armament { get; private set; }
        public int Hitch { get; private set; }

        public Solder(string name, string rank, string armament, int hitch)
        {
            Name = name;
            Rank = rank;
            Armament = armament;
            Hitch = hitch;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name - {Name}, rank - {Rank}");
        }
    }
}
