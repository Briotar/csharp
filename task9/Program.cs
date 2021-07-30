using System;
using System.Collections.Generic;

namespace Task_9_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Fish carp = new Fish("carp", 7);
            Fish pike = new Fish("pike", 9);
            Fish zander = new Fish("zander", 5);
            List<Fish> fishToAdd = new List<Fish>();
            bool isWorking = true;
            int numberMenu;
            int numberFishToAdd;
            int numberFishToDelete;
            int minMenuNumber = 1;
            int maxMenuNumber = 4;

            Console.Write("Enter max number of fish - ");
            int countFish = ConvertToInt();
            Aquarium aquarium = new Aquarium(countFish);

            fishToAdd.Add(carp);
            fishToAdd.Add(pike);
            fishToAdd.Add(zander);

            while (isWorking)
            {
                aquarium.ShowInfo();

                Console.WriteLine("\n1)Add new fish \n2)Delete fish \n3)Show info \n4)Exit");
                numberMenu = GetNumberMenu(maxMenuNumber, minMenuNumber);

                switch (numberMenu)
                {
                    case 1:
                        AddFishAquarium(aquarium, countFish, fishToAdd);
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

                CheckFishALive(aquarium);

                Console.ReadKey();
                Console.Clear();
            }

            static void AddFishAquarium(Aquarium aquarium, int countFish, List<Fish> fishToAdd)
            {
                int numberFishToAdd;

                if (aquarium.Fishes.Count >= countFish)
                {
                    Console.WriteLine("Too many fish!");
                }
                else
                {
                    Console.WriteLine("Choose fish to add:");

                    for (int i = 0; i < fishToAdd.Count; i++)
                    {
                        Console.Write((i + 1) + ")");
                        fishToAdd[i].ShowInfo();
                    }

                    numberFishToAdd = ConvertToInt();

                    switch (numberFishToAdd)
                    {
                        case 1:
                            Fish carp = new Fish("carp", 7);
                            aquarium.AddFish(carp);
                            break;

                        case 2:
                            Fish pike = new Fish("pike", 9);
                            aquarium.AddFish(pike);
                            break;

                        case 3:
                            Fish zander = new Fish("zander", 5);
                            aquarium.AddFish(zander);
                            break;

                        default:
                            Console.WriteLine("Default choose - 1");
                            Fish carp1 = new Fish("carp", 7);
                            aquarium.AddFish(carp1);
                            break;
                    }
                }
            }

            static void CheckFishALive(Aquarium aquarium)
            {
                for (int i = 0; i < aquarium.Fishes.Count; i++)
                {
                    if (aquarium.Fishes[i].Age <= 0)
                    {
                        aquarium.Fishes.RemoveAt(i);
                    }
                    else
                    {
                        aquarium.Fishes[i].TakeDamage();
                    }
                }
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

            public Aquarium(int fishes)
            {
                Fishes = new List<Fish>();
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

            public void AddFish(Fish fish)
            {
                Fishes.Add(fish);
            }
        }

        class Fish
        {
            public string Name { get; private set; }

            public int Age { get; private set; }

            public Fish(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public void TakeDamage()
            {
                Age--;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"Name  - {Name}, age - {Age}");
            }
        }
    }
}
