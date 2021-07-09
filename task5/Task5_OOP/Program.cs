using System;
using System.Collections.Generic;

namespace Task5_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Trip trip = new Trip();
            bool isWork = true;
            string userInput;

            while(isWork)
            {
                trip.DepartureTrip();

                Console.SetCursorPosition(0, 16);
                Console.Write("Enter 1 to exit or any other symbol to continue - ");
                userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    isWork = false;
                }

                Console.Clear();
            }
        }
    }

    class Direction
    {
        private string _from;
        private string _to;

        public Direction(string from, string to)
        {
            _from = from;
            _to = to;
        }

        public void ShowInfo(int i)
        {
            Console.WriteLine($"{i+1}) direction - {_from}-{_to}");
        }
    }

    class Train
    {
        private List<RailwayCarriage> _railwayCarriages;

        public Train()
        {
            _railwayCarriages = new List<RailwayCarriage>();
        }

        public void AddLargeCarriage()
        {
            _railwayCarriages.Add(new RailwayCarriageLarge());
        }

        public void AddMediumCarriage()
        {
            _railwayCarriages.Add(new RailwayCarriageMedium());
        }

        public void ShowInfo()
        {
            int countRailwayCarriageLarge = 0;
            int countRailwayCarriageMedium = 0;

            for (int i = 0; i < _railwayCarriages.Count; i ++)
            {
                if(_railwayCarriages[i] is RailwayCarriageLarge)
                {
                    countRailwayCarriageLarge++;
                }
                else
                {
                    countRailwayCarriageMedium++;
                }
            }

            Console.WriteLine($"Train has {countRailwayCarriageLarge} large and {countRailwayCarriageMedium} medium railwaycarriage");
        }

        public bool CheckExist()
        {
            if(_railwayCarriages.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ClearList()
        {
            _railwayCarriages.Clear();
        }
    }

    abstract class RailwayCarriage
    {
        public int Capacity { get; protected set; }
    }

    class RailwayCarriageMedium : RailwayCarriage
    {
        public RailwayCarriageMedium()
        {
            Capacity = 50;
        }
    }

    class RailwayCarriageLarge : RailwayCarriage
    {
        public RailwayCarriageLarge()
        {
            Capacity = 100;
        }
    }

    class Trip
    {
        private int _numberPassengers;
        private static Random _random;

        public Trip()
        {
            _random = new Random();
        }

        public void DepartureTrip()
        {
            List<Direction> directions = new List<Direction>();
            Train train = new Train();
            RailwayCarriageLarge railwayCarriageLarge = new RailwayCarriageLarge();
            RailwayCarriageMedium railwayCarriageMedium = new RailwayCarriageMedium();
            string directionFrom;
            string directionTo;

            Console.SetCursorPosition(0, 10);
            Console.Write("Where does the train go - ");
            directionTo = Console.ReadLine();
            Console.Write("where the train departs from - ");
            directionFrom = Console.ReadLine();

            directions.Add(new Direction(directionFrom, directionTo));

            UpdateInfo(train);

            Console.SetCursorPosition(0, 12);
            Console.WriteLine("Sell tickets ? Press ane button.");
            Console.ReadKey();
            _numberPassengers = _random.Next(80, 460);
            Console.WriteLine($"Passengers on direction - {_numberPassengers}\n");

            while (_numberPassengers > 0)
            {
                if (_numberPassengers / railwayCarriageLarge.Capacity >= 1)
                {
                    train.AddLargeCarriage();
                    _numberPassengers -= railwayCarriageLarge.Capacity;
                }
                else
                {
                    train.AddMediumCarriage();
                    _numberPassengers -= railwayCarriageMedium.Capacity;
                }
            }

            UpdateInfo(train);
            train.ClearList();

            Console.WriteLine("Train leaves...\n\n");
        }

        private void UpdateInfo(Train train)
        {
            Console.SetCursorPosition(0, 0);

            if (train.CheckExist())
            {
                train.ShowInfo();
            }
            else
            {
                Console.WriteLine("Train not exist!");
            }
        }
    }
}
