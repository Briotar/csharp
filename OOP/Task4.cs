using System;
using System.Collections.Generic;

namespace Task4_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            Player player = new Player(500);
            Product productToPlayer;
            bool isMenu = true;
            int userInput;
            int numberProduct;
            int moneyToPay;


            while(isMenu)
            {
                Console.WriteLine("Welcome to the menu!");
                Console.WriteLine("1 - show goods\n2 - buy a product\n3 - show inventory\n4 - exit");
                userInput = Convert.ToInt32(Console.ReadLine());

                switch(userInput)
                {
                    case 1:
                        shop.ShowInfo();
                        break;

                    case 2:
                        shop.ShowInfo();
                        Console.Write("Enter number - ");
                        numberProduct = Convert.ToInt32(Console.ReadLine());
                        numberProduct -= 1;

                        moneyToPay = shop.CheckCost(numberProduct);

                        if (player.TakeMoney(moneyToPay))
                        {
                            productToPlayer = shop.DeleteProduct(numberProduct);
                            player.AddToList(productToPlayer);
                            shop.TakeMoney(moneyToPay);
                        }
                        Console.WriteLine("");
                        break;

                    case 3:
                        player.ShowInfo();
                        break;

                    case 4:
                        isMenu = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Player
    {
        private int _money;
        private List<Product> _inventory = new List<Product>();

        public Player(int money)
        {
            _money = money;
        }

        public void ShowInfo()
        {
            for (int i = 0; i < _inventory.Count; i++)
            {
                Console.Write((i + 1) + ") ");
                _inventory[i].ShowInfo();
            }
        }

        public bool TakeMoney(int moneyToPay)
        {
            bool isSuccesful;

            if(moneyToPay > _money)
            {
                Console.WriteLine("You dont have enough money");
                isSuccesful = false;
            }
            else
            {
                _money -= moneyToPay;
                Console.WriteLine($"Your money now - {_money}");
                isSuccesful = true;
            }
            return isSuccesful;
        }

        public void AddToList(Product product)
        {
            _inventory.Add(product);
        }
    }

    class Product
    {
        private string _name;

        public int Price { get; private set; }

        public Product(int price, string name)
        {
            Price = price;
            _name = name;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name - {_name}, price - {Price}");
        }

    }

    class Shop
    {
        private int _money;
        private List<Product> _products = new List<Product>();

        public Shop()
        {
            _money = 0;
            _products.Add(new Product(100, "Melon"));
            _products.Add(new Product(8, "Berry"));
            _products.Add(new Product(121, "Water"));
            _products.Add(new Product(5000, "Kek"));
            _products.Add(new Product(1, "Lol"));
            _products.Add(new Product(20, "PopIt"));
        }

        public void ShowInfo()
        {
            for(int i = 0; i < _products.Count; i++)
            {
                Console.Write((i + 1) + ") ");
                _products[i].ShowInfo();
            }
        }

        public Product DeleteProduct(int numberProduct)
        {
            Product productToPlayer = _products[numberProduct];
            _products.RemoveAt(numberProduct);
            return productToPlayer;
        }

        public void TakeMoney(int moneyToPay)
        {
            _money += moneyToPay;
            Console.WriteLine($"Shop money - {_money}");
        }

        public int CheckCost(int numberProduct)
        {
            return _products[numberProduct].Price;
        }

    }
}
