using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Patient> patients = new List<Patient>
            {
                new Patient("Vova", 20, "alzheimer"),
                new Patient("Vlad", 25, "diabetes"),
                new Patient("Ivan", 40, "diabetes"),
                new Patient("Petr", 14, "migraine"),
                new Patient("Mike", 33, "alzheimer"),
                new Patient("Sanya", 18, "alzheimer"),
                new Patient("Andrew", 21, "migraine"),
                new Patient("Nikita", 57, "autism"),
                new Patient("Mihail", 60, "blindness"),
                new Patient("Kirill", 38, "asthma"),
                new Patient("Vladimir", 22, "alzheimer")
            };
            bool isMenu = true;
            int indexMenu;
            string inputDisease;

            while (isMenu)
            {
                Console.WriteLine("1)Sort by name \n2)Sort by age \n3)Search disease \n4)Exit");
                indexMenu = GetNumberMenu();

                switch(indexMenu)
                {
                    case 1:
                        var filtredPatientsName = patients.OrderBy(patient => patient.Name);
                        ShowInfo(filtredPatientsName);
                        break;

                    case 2:
                        var filtredPatientsAge = patients.OrderBy(patient => patient.Age);
                        ShowInfo(filtredPatientsAge);
                        break;

                    case 3:
                        Console.Write("Enter disease - ");
                        inputDisease = Console.ReadLine();

                        var filtredPatientsDisease = patients.Where(patient => patient.Disease == inputDisease);
                        ShowInfo(filtredPatientsDisease);
                        break;

                    case 4:
                        isMenu = false;
                        break;
                }

                Console.ReadKey();
            }
        }
        
        static void ShowInfo(IOrderedEnumerable<Patient> filtredPatients)
        {
            foreach (var patient in filtredPatients)
            {
                patient.ShowInfo();
            }
        }

        static void ShowInfo(IEnumerable<Patient> filtredPatients)
        {
            foreach (var patient in filtredPatients)
            {
                patient.ShowInfo();
            }
        }

        static int GetNumberMenu(int maxNumberMenu = 4)
        {
            string numberMenu;
            int numberMenuInt;
            bool successfulConvert;

            numberMenu = Console.ReadLine();
            successfulConvert = Int32.TryParse(numberMenu, out numberMenuInt);

            if (successfulConvert)
            {
                if (numberMenuInt < 1 || numberMenuInt > maxNumberMenu)
                {
                    Console.WriteLine($"Enter a number 1-{maxNumberMenu}! Default number - 1");
                    return 1;
                }
                else
                {
                    return numberMenuInt;
                }
            }
            else
            {
                Console.WriteLine("Enter a number! Default number - 1");
                return 1;
            }
        }
    }

    class Patient
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public Patient(string name, int age, string disease)
        {
            Name = name;
            Age = age;
            Disease = disease;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name - {Name}, age - {Age}, disease - {Disease}");
        }
    }
}
