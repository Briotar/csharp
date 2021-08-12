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

            var topLevelPlayers = players.OrderByDescending(player => player.Level).Take(maxTopPlayers).ToList();

            Console.WriteLine("Top level players:");
            for (int i = 0; i < maxTopPlayers; i ++)
            {
                Console.Write((i + 1) + ")");
                topLevelPlayers[i].ShowInfo();
            }

            var topPowerPlayers = players.OrderByDescending(player => player.Power).Take(maxTopPlayers).ToList();

            Console.WriteLine("Top power players:");
            for (int i = 0; i < maxTopPlayers; i++)
            {
                Console.Write((i + 1) + ")");
                topPowerPlayers[i].ShowInfo();
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
