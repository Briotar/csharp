using System;
using System.Collections.Generic;

namespace Task7_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            Human human = new Human();
            int lenghtQueue;

            Console.Write("Enter number of people in queue - ");
            lenghtQueue = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < lenghtQueue; i++)
            {
                shop.AddHuman();
            }

            for (int i = 0; i < lenghtQueue; i++)
            {
                Console.Write($"\n\n{i+1} human has - ");

                human = shop.Queue.Dequeue();
                human.ShowMoney();

                Console.WriteLine("Basket:");
                human.ShowBasket();

                human.TryPay(human);
            }
        }
    }

    class Shop
    {
        public Queue<Human> Queue { get; private set; }

        public Shop()
        {
            Queue = new Queue<Human>();
        }

        public void AddHuman()
        {
            Human human = new Human();
            Queue.Enqueue(human);
        }
    }

    class Human
    {
        private int _money;
        private List<Product> _basket;
        static private Random _random;

        public Human()
        {
            Melon melon = new Melon();
            Cigarettes cigarettes = new Cigarettes();
            int countMelons;
            int countCigarettes;

            _random = new Random();
            _money = _random.Next(100, 200);
            _basket = new List<Product>();
            countMelons = _random.Next(1,4);
            countCigarettes = _random.Next(1, 2);

            FillBasket(melon, countMelons);
            FillBasket(cigarettes, countCigarettes);
        }

        private int CostCalculation()
        {
            int totalCost = 0;

            for (int i = 0; i < _basket.Count; i++)
            {
                totalCost += _basket[i].Cost;
            }

            return totalCost;
        }

        private void FillBasket(Product product, int productCount)
        {
            for (int i = 0; i < productCount; i++)
            {
                _basket.Add(product);
            }
        }

        private void DeleteProduct(Human human)
        {
            int productRemove = _random.Next(1,human._basket.Count);

            Console.WriteLine($"Product to remove - {productRemove}");

            human._basket.RemoveAt(productRemove - 1);
            human.ShowBasket();

            TryPay(human);
        }

        public void TryPay(Human human)
        {
            int totalCost = CostCalculation();

            if(_money > totalCost)
            {
                Console.WriteLine("\nClient successfully paid");
            }
            else
            {
                Console.WriteLine("\nNot exought money! Remove one product...");
                DeleteProduct(human);
            }
        }

        public void ShowBasket()
        {
            int totalCost;

            for (int i = 0; i < _basket.Count; i++)
            {
                Console.Write(i + 1 + ")");
                _basket[i].ShowInfo();
            }

            totalCost = CostCalculation();

            Console.WriteLine($"Total - {totalCost}");
        }

        public void ShowMoney()
        {
            Console.WriteLine($"{_money} money");
        }
    }

    abstract class Product
    {
        public string Name{ get; protected set;}
        public int Cost { get; protected set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Name - {Name}, cost - {Cost}");
        }
    }

    class Melon : Product
    {
        public Melon()
        {
            Name = "melon";
            Cost = 30;
        }
    }

    class Cigarettes : Product
    {
        public Cigarettes()
        {
            Name = "cigarettes";
            Cost = 80;
        }
    }


}
