using System;
using System.Collections.Generic;

namespace collection
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            string userInput;

            words.Add("hello", 1);
            words.Add("word", 2);
            words.Add("world", 3);

            Console.Write("Введите слово - ");
            userInput = Console.ReadLine();

            if (words.ContainsKey(userInput))
            {
                Console.WriteLine("Значение слова - " + words[userInput]);
            }
            else
            {
                Console.WriteLine("Такого слова нет!");
            }

        }
    }
}
