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
                new Solder("Ivan", "lieutenant", "rifle", 14),
                new Solder("Mike", "sergeant", "gun", 15),
                new Solder("Nikita", "lieutenant", "machinegun", 16),
                new Solder("Danya", "major", "rifle", 17),
            };
            List<Solder> solders2 = new List<Solder>
            {
                new Solder("Vladimir", "major", "gun", 20)
            };

            var soldersNameV = solders.Where(solder => solder.Name.StartsWith("V")).ToList();

            for (int i = 0; i < soldersNameV.Count; i++)
            {
                solders2.Add(soldersNameV[i]);
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
