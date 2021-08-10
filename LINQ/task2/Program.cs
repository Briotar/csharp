using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Prisoner> prisoners = new List<Prisoner>
            {
                new Prisoner("Vova", "anti-government"),
                new Prisoner("Vlad", "sheft"),
                new Prisoner("Vanya", "terrorism"),
                new Prisoner("Mike", "sheft"),
                new Prisoner("Kile", "anti-government")
            };

            var filtredPrisoners = from Prisoner prisoner in prisoners where prisoner.Crime != "anti-government" select prisoner;

            Console.WriteLine("Before the amnesty");
            foreach (var prisoner in prisoners)
            {
                prisoner.ShowInfo();
            }

            Console.WriteLine("After the amnesty");
            foreach (var citizen in filtredPrisoners)
            {
                citizen.ShowInfo();
            }

        }
    }

    class Prisoner
    {
        public string Name { get; private set; }
        public string Crime { get; private set; }

        public Prisoner(string name, string crime)
        {
            Name = name;
            Crime = crime;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name - {Name}, crime - {Crime}");
        }
    }
}
