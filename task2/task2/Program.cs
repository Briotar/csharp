using System;
using System.Collections.Generic;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> purchaseAmount = new Queue<int>();
            int sum = 0;

            purchaseAmount.Enqueue(1);
            purchaseAmount.Enqueue(3);
            purchaseAmount.Enqueue(5);
            purchaseAmount.Enqueue(7);
            purchaseAmount.Enqueue(9);
            purchaseAmount.Enqueue(11);

            while (purchaseAmount.Count != 0)
            {
                sum += purchaseAmount.Dequeue();
                Console.WriteLine($"Your account = {sum}");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
