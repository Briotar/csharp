using System;
using System.Collections.Generic;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            string userInput = "";
            int newNumber;
            int sum = 0;

            while (userInput != "exit")
            {
                Console.Write("Enter number - ");
                userInput = Console.ReadLine();

                if (userInput == "sum")
                {
                    for (int i=0; i < numbers.Count; i++)
                    {
                        sum += numbers[i];
                    }
                    Console.WriteLine($"Sum - {sum}");
                }
                else
                {
                    newNumber = ConvertToInt(userInput);
                    numbers.Add(newNumber);
                }
            }
        }

        static int ConvertToInt(string userInput)
        {
            int number = 0;
            bool successfulConvert = false;

            successfulConvert = Int32.TryParse(userInput, out number);
            if (successfulConvert)
            {
                return number;
            }
            else
            {
                Console.WriteLine("It's not a number!");
            }
            return 0;
        }

    }
}
