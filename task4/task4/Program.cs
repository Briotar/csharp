using System;
using System.Collections.Generic;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> dossier = new List<string[]>();
            int userInput;
            bool isMenu = true;

            while(isMenu)
            {
                Console.WriteLine("1)Add new dossier\n2)Show all dossier\n3)Delete dossier\n4)Exit");
                userInput = Convert.ToInt32(Console.ReadLine());

                switch(userInput)
                {
                    case 1:
                        AddDossier(dossier);            
                        break;
                    case 2:
                        PrintDossier(dossier);
                        break;
                    case 3:
                        DeleteDossier(dossier);
                        break;
                    case 4:
                        isMenu = false;
                        break;
                }
            }
        }

        static void AddDossier(List<string[]> dossier)
        {
            string[] addToList = new string[2]; 

            Console.Write("Enter full name - ");
            addToList[0] = Console.ReadLine();
            Console.Write("Enter position - ");
            addToList[1] = Console.ReadLine();

            dossier.Add(addToList);
        }

        static void PrintDossier(List<string[]> dossier)
        {
            for (int i = 0; i < dossier.Count; i++)
            {
                Console.Write($"-{i+1} {dossier[i][0]} {dossier[i][1]} ");
            }
            Console.WriteLine();
        }

        static void DeleteDossier(List<string[]> dossier)
        {
            int userInput;

            Console.WriteLine($"Enter index of doosier, from 1 to {dossier.Count}");
            userInput = Convert.ToInt32(Console.ReadLine());

            dossier.RemoveAt(userInput-1);
        }
    }
}
