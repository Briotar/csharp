using System;
using System.Collections.Generic;

namespace Task5_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Direction> directions = new List<Direction>();
            Train train = new Train();
            RailwayCarriageLarge railwaycarriagelarge = new RailwayCarriageLarge();
            RailwayCarriageMedium railwaycarriagemedium = new RailwayCarriageMedium();
            Random rand = new Random();
            string newDirection;
            int numberPassengers;

            while(true)
            {
                Console.SetCursorPosition(0, 10);
                Console.Write("Enter new direction - ");
                newDirection = Console.ReadLine();
                directions.Add(new Direction(newDirection));

                UpdateInfo(train);

                Console.SetCursorPosition(0, 12);
                Console.WriteLine("Sell tickets ? Press ane button.");
                Console.ReadKey();
                numberPassengers = rand.Next(80, 460);
                Console.WriteLine($"Passengers on direction - {numberPassengers}\n");

                while (numberPassengers > 0)
                {
                    if (numberPassengers / railwaycarriagelarge.Capacity >= 1)
                    {
                        train.AddToTrainLarge();
                        numberPassengers -= railwaycarriagelarge.Capacity;
                    }
                    else
                    {
                        train.AddToTrainMedium();
                        numberPassengers -= railwaycarriagemedium.Capacity;
                    }
                }

                UpdateInfo(train);
                train.ClearList();

                Console.WriteLine("Train leaves...\n\n");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void UpdateInfo(Train train)
        {
            Console.SetCursorPosition(0,0);
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

    class Direction
    {
        private string _name;

        public Direction(string name)
        {
            _name = name;
        }

        public void ShowInfo(int i)
        {
            Console.WriteLine($"{i+1}) direction - {_name}");
        }
    }

    class Train
    {
        private List<RailwayCarriage> _railwayCarriages = new List<RailwayCarriage>();

        public void AddToTrainLarge()
        {
            _railwayCarriages.Add(new RailwayCarriageLarge());
        }

        public void AddToTrainMedium()
        {
            _railwayCarriages.Add(new RailwayCarriageMedium());
        }

        public void ShowInfo()
        {
            int countRailwayCarriageLarge = 0;
            int countRailwayCarriageMedium = 0;

            for (int i = 0; i < _railwayCarriages.Count; i ++)
            {
                if(_railwayCarriages[i].Capacity == 100)
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
}
