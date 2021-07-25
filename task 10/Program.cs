using System;
using System.Collections.Generic;

namespace Task_10_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Aviary> aviaries = new List<Aviary>();
            Aviary aviaryMonkey = new Aviary("Monkey aviary", "unga bunga", 6);
            Aviary aviaryPenguins = new Aviary("Penguins aviary", "pep pep", 4);
            Aviary aviaryElephants = new Aviary("Elephants aviary", "vjuh vjuh", 2);
            Aviary aviaryParrot = new Aviary("Parrot aviary", "privet privet", 10);
            Aviary aviaryWolf = new Aviary("Wolf aviary", "Uuuuuu UUuuuuu", 3);
            bool isWorking = true;
            int numberAviary;

            aviaries.Add(aviaryMonkey);
            aviaries.Add(aviaryPenguins);
            aviaries.Add(aviaryElephants);
            aviaries.Add(aviaryParrot);
            aviaries.Add(aviaryWolf);

            while (isWorking)
            {
                Console.WriteLine("Choose aviary:");

                for (int i = 0; i < aviaries.Count; i++)
                {
                    Console.Write((i+1) + ")");
                    aviaries[i].ShowName();
                }

                Console.WriteLine($"{aviaries.Count + 1})Exit " );

                Console.WriteLine($"Enter a number 1-{aviaries.Count + 1} ");
                numberAviary = GetNumberMenu(aviaries);

                if(numberAviary == (aviaries.Count))
                {
                    isWorking = false;
                }
                else
                {
                    aviaries[numberAviary].ShowInfo();
                }

                Console.ReadKey();
            }
        }

        static int GetNumberMenu(List<Aviary> aviaries)
        {
            string numberAviary;
            int numberAviaryInt;
            bool successfulConvert;

            numberAviary = Console.ReadLine();
            successfulConvert = Int32.TryParse(numberAviary, out numberAviaryInt);

            if (successfulConvert)
            {
                if(numberAviaryInt < 1 || numberAviaryInt > (aviaries.Count + 1))
                {
                    Console.WriteLine($"Enter a number 1-{aviaries.Count + 1}! Default number - 1");
                    return 0;
                }
                else
                {
                    return numberAviaryInt - 1;
                }
            }
            else
            {
                Console.WriteLine("Enter a number! Default number - 1");
                return 0;
            }
        }

    }

    class Aviary
    {
        private static Random _random;

        public List<Animal> Animals { get; private set; }
        public string Name { get; private set; }

        public Aviary(string name, string voice, int countAnimal)
        {
            Animals = new List<Animal>();
            Name = name;
            _random = new Random();

            int sex = _random.Next(1, 3);

            for (int i = 0; i < countAnimal; i++)
            {
                if(sex == 1)
                {
                    Animal animal = new Animal("male", voice);
                    Animals.Add(animal);
                }
                else
                {
                    Animal animal = new Animal("female", voice);
                    Animals.Add(animal);
                }
            }
        }

        public void ShowName()
        {
            Console.WriteLine(Name);
        }

        public void ShowInfo()
        {
            ShowName();

            Console.Write($"Number of animals - {Animals.Count} ");

            Animals[0].ShowInfo();
        }
    }

    class Animal
    {
        private string _sex;
        private string _voice;

        public Animal(string sex, string voice)
        {
            _sex = sex;
            _voice = voice;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Sex - {_sex}, voice - {_voice}");
        }
    }
}
