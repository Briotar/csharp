using System;
using System.Collections.Generic;

namespace Task3OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            Random rand = new Random();
            bool isMenu = true;
            int userInput;
            string nickname;
            int numberPlayer;


            while(isMenu)
            {
                Console.WriteLine("Welcome!");
                Console.WriteLine("1 - add new player\n2 - ban player\n3 - unban player\n" +
                    "4 - delete player\n5 - exit");
                userInput = Convert.ToInt32(Console.ReadLine());

                switch(userInput)
                {
                    case 1:
                        Console.Write("Enter nickname - ");
                        nickname = Console.ReadLine();

                        database.AddNewPlayer(nickname, rand);
                        ShowDatabase(database);
                        break;

                    case 2:
                        ChangeStatus(database);
                        break;

                    case 3:
                        ChangeStatus(database);
                        break;

                    case 4:
                        database.ShowInfo();

                        Console.Write("Enter a number of player - ");
                        numberPlayer = Convert.ToInt32(Console.ReadLine());

                        database.DeletePlayer(numberPlayer);
                        ShowDatabase(database);
                        break;

                    case 5:
                        isMenu = false;
                        break;
                }

            }

            static void ChangeStatus(Database database)
            {
                int numberPlayer;

                database.ShowInfo();

                Console.Write("Enter a number of player- ");
                numberPlayer = Convert.ToInt32(Console.ReadLine());

                database.ChangeStatus(numberPlayer);
                ShowDatabase(database);
            }

            static void ShowDatabase(Database database)
            {
                database.ShowInfo();
                Console.ReadKey();
                Console.Clear();
            }

        }
    }

    class Player
    {
        private static int Ids;
        private string _nickname;
        private int _level;

        public bool IsBaned { get; private set; }
        public int Id { get; private set; }

        public Player(string nickname, Random rand)
        {
            Id = ++Ids;
            _nickname = nickname;
            _level = rand.Next(1,10);
            IsBaned = false;
        }

        public void ShowInfo()
        {
            Console.Write($"Player number - {Id}, nickname - {_nickname}, level - {_level}, status - ");
            if(IsBaned)
            {
                Console.WriteLine("vacban");
            }
            else
            {
                Console.WriteLine("active");
            }
        }

        public void BanPlayer()
        {
            IsBaned = true;
        }

        public void UnbanPlayer()
        {
            IsBaned = false;
        }


    }

    class Database
    {
        private List<Player> _players = new List<Player>();

        public void AddNewPlayer(string nickname, Random rand)
        {
            _players.Add(new Player(nickname, rand));
        }

        public void ShowInfo()
        {
            Console.WriteLine("\nDatabase:");

            for (int i = 0; i < _players.Count; i++)
            {
                _players[i].ShowInfo();
            }

            Console.WriteLine();
        }

        public void ChangeStatus(int numberPlayer)
        {
            for (int i = 0; i < _players.Count; i++)
            {
                if(_players[i].Id == numberPlayer)
                {
                    if(_players[i].IsBaned == false)
                    {
                        _players[i].BanPlayer();
                    }
                    else
                    {
                        _players[i].UnbanPlayer();
                    }
                }
            }
        }

        public void DeletePlayer(int numberPlayer)
        {
            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].Id == numberPlayer)
                {
                    _players.RemoveAt(i);
                }
            }
        }
    }

}
