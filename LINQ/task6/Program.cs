using System;
using System.Collections.Generic;
using System.Linq;

namespace task6
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

            var filtredSolders = solders.Select(i => new { i.Name, i.Rank});

            foreach (var solder in filtredSolders)
            {
                Console.WriteLine($"Name - {solder.Name}, rank - {solder.Rank}");
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
    }
}
