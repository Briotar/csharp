using System;
using System.Collections.Generic;

namespace Task_9_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            int numberMenu;
            int numberFishToAdd;
            int numberFishToDelete;
            int minMenuNumber = 1;
            int maxMenuNumber = 4;

            Console.Write("Enter max number of fish - ");
            int countFish = ConvertToInt();
            Aquarium aquarium = new Aquarium(countFish);

            while (isWorking)
            {
                aquarium.ShowInfo();

                Console.WriteLine("\n1)Add new fish \n2)Delete fish \n3)Show info \n4)Exit");
                numberMenu = GetNumberMenu(maxMenuNumber, minMenuNumber);

                switch (numberMenu)
                {
                    case 1:
                        aquarium.AddFish(countFish);
                        aquarium.ShowInfo();
                        break;

                    case 2:
                        if(aquarium.Fishes.Count == 0)
                        {
                            Console.WriteLine("There are no fish yet!");
                        }
                        else
                        {
                            Console.WriteLine("Choose fish to delete:");
                            aquarium.ShowInfo();

                            numberFishToDelete = ConvertToInt(1) - 1;
                            aquarium.Fishes.RemoveAt(numberFishToDelete);
                        }

                        aquarium.ShowInfo();
                        break;

                    case 3:
                        aquarium.ShowInfo();
                        break;

                    case 4:
                        isWorking = false;
                        break;
                }

                aquarium.CheckFishALive();

                Console.ReadKey();
                Console.Clear();
            }
        }

        static int ConvertToInt(int defaultSelect = 3)
        {
            string from;
            int to;
            bool isConverted;

            from = Console.ReadLine();
            isConverted = Int32.TryParse(from, out to);

            if (isConverted)
            {
                return to;
            }
            else
            {
                Console.WriteLine($"It's not a number! Default select - {defaultSelect}");
                return defaultSelect;
            }
        }

        static int GetNumberMenu(int maxMenuNumber, int minMenuNumber,int defaultSelect = 3)
        {
            int numberMenu = ConvertToInt();

            if(numberMenu < minMenuNumber || numberMenu > maxMenuNumber)
            {
                Console.WriteLine($"Enter 1-{maxMenuNumber}! Default select - {defaultSelect}");
                return defaultSelect;
            }

            return numberMenu;
        }

        class Aquarium
        {
            private int _maxFishes;

            public List<Fish> Fishes { get; private set; }
            public List<Fish> FishToAdd { get; private set; }

            public Aquarium(int fishes)
            {
                Fish carp = new Carp("carp", 7);
                Fish pike = new Pike("pike", 9);
                Fish zander = new Zander("zander", 5);
                Fishes = new List<Fish>();
                FishToAdd = new List<Fish>();

                FishToAdd.Add(carp);
                FishToAdd.Add(pike);
                FishToAdd.Add(zander);

                _maxFishes = fishes;
            }

            public void ShowInfo()
            {
                Console.WriteLine("Fish in aquarium:");

                if(Fishes.Count == 0)
                {
                    Console.WriteLine("There are no fish yet");
                }
                else
                {
                    for (int i = 0; i < Fishes.Count; i++)
                    {
                        Console.Write((i + 1) + ")");
                        Fishes[i].ShowInfo();
                    }
                }
            }

            public void DeleteFish(int fishNumber)
            {
                Fishes.RemoveAt(fishNumber);
            }

            public void AddFish(int countFish)
            {
                int numberFishToAdd;

                if (Fishes.Count >= countFish)
                {
                    Console.WriteLine("Too many fish!");
                }
                else
                {
                    Console.WriteLine("Choose fish to add:");

                    for (int i = 0; i < FishToAdd.Count; i++)
                    {
                        Console.Write((i + 1) + ")");
                        FishToAdd[i].ShowInfo();
                    }

                    numberFishToAdd = ConvertToInt();

                    switch (numberFishToAdd)
                    {
                        case 1:
                            Fish carp = new Carp("carp", 7);
                            Fishes.Add(carp);
                            break;

                        case 2:
                            Fish pike = new Pike("pike", 9);
                            Fishes.Add(pike);
                            break;

                        case 3:
                            Fish zander = new Zander("zander", 5);
                            Fishes.Add(zander);
                            break;

                        default:
                            Console.WriteLine("Default choose - 1");
                            Fish carp1 = new Carp("carp", 7);
                            Fishes.Add(carp1);
                            break;
                    }
                }
            }

            public void CheckFishALive()
            {
                for (int i = 0; i < Fishes.Count; i++)
                {
                    if (Fishes[i].IsAlive)
                    {
                        Fishes[i].TakeDamage();
                    }
                    else
                    {
                        Fishes.RemoveAt(i);
                    }
                }
            }
        }

        abstract class Fish
        {
            public bool IsAlive { get; private set; }

            public string Name { get; private set; }

            public int TurnsToDie { get; private set; }

            public Fish(string name, int age)
            {
                Name = name;
                TurnsToDie = age;
                IsAlive = true;
            }

            public void TakeDamage()
            {
                TurnsToDie--;

                if(TurnsToDie <= 0)
                {
                    IsAlive = false;
                }
            }

            public void ShowInfo()
            {
                Console.WriteLine($"Name  - {Name}, turns to die - {TurnsToDie}");
            }
        }

        class Carp : Fish
        {
            public Carp(string name, int age) : base(name, age) { }
        }

        class Pike : Fish
        {
            public Pike(string name, int age) : base(name, age) { }
        }

        class Zander : Fish
        {
            public Zander(string name, int age) : base(name, age) { }
        }
    }
}
