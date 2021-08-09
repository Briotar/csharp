using System;
using System.Collections.Generic;

namespace Task_11
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Detail> allDetails = new List<Detail>();
            Service service = new Service(10000);
            bool isWorking = true;
            int numberMenu;
            int maxNumberMenu = 2;

            while (isWorking)
            {
                Console.WriteLine("1)New client \n2)Exit");
                numberMenu = GetNumberMenu(maxNumberMenu);

                if(numberMenu == maxNumberMenu)
                {
                    isWorking = false;
                }
                else
                {
                    service.ClientService();
                }

                Console.ReadKey();
            }
        }

        static int GetNumberMenu(int maxNumberMenu = 2)
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

    class Service
    {
        private int _money;

        public List<Detail> Details { get; private set; }

        public List<Detail> AllDetails { get; private set; } 

        public Service(int money)
        {
            Details = new List<Detail>();
            AllDetails = new List<Detail>();
            _money = money;

            Detail bolt = new Bolt("bolt", 100, 1);
            Detail screw = new Screw("screw", 200, 2);
            Detail shaft = new Shaft("shaft", 1000, 2);

            Details.Add(bolt);
            Details.Add(screw);
            Details.Add(shaft);

            AllDetails.Add(bolt);
            AllDetails.Add(screw);
            AllDetails.Add(shaft);
        }

        public void ClientService()
        {
            int detailIndex = 0;
            bool isHaveDetail = false;
            Client client = new Client();
            client.ShowInfo();

            for (int i = 0; i < Details.Count; i++)
            {
                if (Details[i].Name == client.Breakdown.Name)
                {
                    detailIndex = i;
                    isHaveDetail = true;
                    Console.WriteLine("We have:");
                    Details[i].ShowInfo();
                }
            }

            if (isHaveDetail)
            {
                Console.WriteLine("Replaced detail");

                int serviceCost = CostCalculation(client.Breakdown);
                Console.WriteLine($"Service cost - {serviceCost}");

                GetMoney(client.Breakdown);
                Details[detailIndex].DecreaseCountDetail();
                Details[detailIndex].ShowInfo();
            }
            else
            {
                Console.WriteLine("We dont have such detail(");

                int fineCost = CostCalculation(client.Breakdown);
                Console.WriteLine($"Fine cost - {fineCost}");

                PayMoney(client.Breakdown);
            }

            for (int i = 0; i < Details.Count; i++)
            {
                if (Details[i].Count == 0)
                {
                    Details.RemoveAt(i);
                }
            }

            isHaveDetail = false;
        }

        public void PayMoney(Detail breakdown)
        {
            int moneyForPay = CostCalculation(breakdown);

            _money -= moneyForPay;
            Console.WriteLine($"Money now - {_money}");
        }

        public void GetMoney(Detail breakdown)
        {
            int moneyForPay = CostCalculation(breakdown);

            _money += moneyForPay;
            Console.WriteLine($"Money now - {_money}");
        }

        public int CostCalculation(Detail detail)
        {
            return (detail.Cost * 2);
        }
    }

    abstract class Detail
    {
        public string Name { get; private set; }
        public int Cost { get; private set; }
        public int Count { get; private set; }

        public Detail(string name, int cost, int count)
        {
            Name = name;
            Cost = cost;
            Count = count;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Detail - {Name}, cost - {Cost}, count - {Count}");
        }

        public void DecreaseCountDetail()
        {
            Count -= 1;
        }
    }

    class Screw : Detail
    {
        public Screw(string name, int cost, int count) : base(name, cost, count) { }
    }

    class Bolt : Detail
    {
        public Bolt(string name, int cost, int count) : base(name, cost, count) { }
    }

    class Shaft : Detail
    {
        public Shaft(string name, int cost, int count) : base(name, cost, count) { }
    }

    class Client
    {
        private static Random _random;

        public Detail Breakdown { get; private set; }

        public List<Detail> AllDetails { get; private set; }

        static Client()
        {
            _random = new Random();
        }

        public Client()
        {
            AllDetails = new List<Detail>();
            Detail bolt = new Bolt("bolt", 100, 1);
            Detail screw = new Screw("screw", 200, 1);
            Detail shaft = new Shaft("shaft", 1000, 1);

            AllDetails.Add(bolt);
            AllDetails.Add(screw);
            AllDetails.Add(shaft);

            int randomBreakdown = _random.Next(0, AllDetails.Count);

            Breakdown = new Bolt(AllDetails[randomBreakdown].Name, AllDetails[randomBreakdown].Cost, 1);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Client needs a replacement - {Breakdown.Name}");
        }
    }
}
