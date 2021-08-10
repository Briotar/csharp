using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Criminal> criminals = new List<Criminal>
            {
                new Criminal("Jon", false, 180, 83, "russian"),
                new Criminal("Bodler", true, 172, 50, "american"),
                new Criminal("Godler", false, 172, 50, "american"),
                new Criminal("Ivan", false, 190, 100, "russian")
            };
            int inputGrowth;
            int inputWeight;
            string inputNationality;

            Console.Write("Enter growth: ");
            inputGrowth = ConvertToInt();
            Console.Write("Enter weight: ");
            inputWeight = ConvertToInt();
            Console.Write("Enter nationality: ");
            inputNationality = Console.ReadLine();
            Console.WriteLine();

            var filtredCriminal = from Criminal criminal in criminals where (criminal.Growth == inputGrowth && criminal.Nationality == inputNationality.ToLower() && criminal.Weight == inputWeight && criminal.IsPrisoner == false) select criminal;

            foreach (var criminal in filtredCriminal)
            {
                criminal.ShowInfo();
            }
        }

        static int ConvertToInt()
        {
            string inputString;
            int convertedString;
            bool successfulConvert;

            inputString = Console.ReadLine();
            successfulConvert = Int32.TryParse(inputString, out convertedString);

            if (successfulConvert)
            {
                return convertedString;
            }
            else
            {
                Console.WriteLine("Enter a number! Default number - 1");
                return 1;
            }
        }
    }

    class Criminal
    {
        public bool IsPrisoner { get; private set; }
        public string Name { get; private set; }
        public int Growth { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }

        public Criminal(string name, bool isPrisoner, int growth, int weight, string nationality)
        {
            Name = name;
            IsPrisoner = isPrisoner;
            Growth = growth;
            Weight = weight;
            Nationality = nationality;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name - {Name}, nationality - {Nationality}, growth - {Growth}, weight - {Weight}");
        }
    }
}
