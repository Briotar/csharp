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
            bool isWork = true;
            int userInput;
            string nickname;
            int numberPlayer;

            while(isWork)
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
                        ChangeBanStatus(database);
                        break;

                    case 3:
                        ChangeBanStatus(database);
                        break;

                    case 4:
                        database.ShowInfo();

                        Console.Write("Enter a number of player - ");
                        numberPlayer = Convert.ToInt32(Console.ReadLine());

                        database.DeletePlayer(numberPlayer);
                        ShowDatabase(database);
                        break;

                    case 5:
                        isWork = false;
                        break;
                }
            }

            static void ChangeBanStatus(Database database)
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
        private static int _ids;
        private string _nickname;
        private int _level;

        public bool IsBaned { get; private set; }
        public int Id { get; private set; }

        public Player(string nickname, Random rand)
        {
            Id = ++_ids;
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

        public void Ban()
        {
            IsBaned = true;
        }

        public void Unban()
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

        private int SearchPlayerI(int numberPlayer)
        {
            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].Id == numberPlayer)
                {
                    return i;
                }
            }

            Console.WriteLine("Player not found");
            return -1;
        }

        public void ChangeStatus(int numberPlayer)
        {
            int playerBanI;
            playerBanI = SearchPlayerI(numberPlayer);

            if(_players[playerBanI].IsBaned == false)
            {
                _players[playerBanI].Ban();
            }
            else
            {
                _players[playerBanI].Unban();
            }
        }

        public void DeletePlayer(int numberPlayer)
        {
            int playerRemoveI;
            playerRemoveI = SearchPlayerI(numberPlayer);

            _players.RemoveAt(playerRemoveI);
        }
    }
}
