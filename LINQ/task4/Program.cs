using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>
            {
                new Player("Vova", 1, 2),
                new Player("Vlad", 5, 2000),
                new Player("Nikita", 9, 30),
                new Player("Petr", 2, 54),
                new Player("Mike", 22, 154),
                new Player("Mihail", 31, 21),
                new Player("Rick", 8, 3785),
                new Player("Ivan", 3, 111),
                new Player("Vladimir", 10, 9),
                new Player("Danya", 100, 258),
                new Player("Zin", 45, 769)
            };
            int maxTopPlayers = 3;
            int i = 1;

            var topLevelPlayers = players.OrderByDescending(player => player.Level).Take(maxTopPlayers);

            Console.WriteLine("Top level players:");
            foreach (var player in topLevelPlayers)
            {
                Console.Write(i + ")");
                player.ShowInfo();
                i++;
            }
            i = 1;

            var topPowerPlayers = players.OrderByDescending(player => player.Power).Take(maxTopPlayers);

            Console.WriteLine("Top power players:");
            foreach (var player in topPowerPlayers)
            {
                Console.Write(i + ")");
                player.ShowInfo();
                i++;
            }
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }

        public Player(string name, int level, int power)
        {
            Name = name;
            Level = level;
            Power = power;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name - {Name}, level - {Level}, power - {Power}");
        }
    }
}
