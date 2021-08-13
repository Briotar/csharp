using System;
using System.Collections.Generic;

namespace Task_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Service service = new Service(10000);
            bool isWorking = true;
            string numberMenu;
            string maxNumberMenu = "2";

            while (isWorking)
            {
                Console.WriteLine("1)New client \n2)Exit");
                numberMenu = Console.ReadLine();

                if(numberMenu == maxNumberMenu)
                {
                    isWorking = false;
                }
                else if(numberMenu == "1") 
                {
                    service.Repair();
                }
                else
                {
                    Console.WriteLine("Incorrect input!");
                }

                Console.ReadKey();
            }
        }
    }

    class Service
    {
        private int _money;
        private List<Detail> _details;

        public Service(int money)
        {
            _details = new List<Detail>();
            _money = money;

            Detail bolt = new Bolt("bolt", 100);
            Detail screw = new Screw("screw", 200);
            Detail shaft = new Shaft("shaft", 1000);

            _details.Add(bolt);
            _details.Add(bolt);
            _details.Add(screw);
            _details.Add(shaft);
        }

        public void Repair()
        {
            int detailIndex = 0;
            bool isHaveDetail = false;
            Client client = new Client();
            client.ShowInfo();

            for (int i = 0; i < _details.Count; i++)
            {
                if (_details[i].Name == client.Breakdown.Name)
                {
                    detailIndex = i;
                    isHaveDetail = true;
                    Console.WriteLine("We have:");
                    _details[i].ShowInfo();
                }
            }

            if (isHaveDetail)
            {
                Console.WriteLine("Replaced detail");

                int serviceCost = CostCalculation(client.Breakdown);
                Console.WriteLine($"Service cost - {serviceCost}");

                Payment(client.Breakdown);
                _details.RemoveAt(detailIndex);
            }
            else
            {
                Console.WriteLine("We dont have such detail(");

                int fineCost = CostCalculation(client.Breakdown);
                Console.WriteLine($"Fine cost - {fineCost}");

                PayMoney(client.Breakdown);
            }

            isHaveDetail = false;
        }

        public void PayMoney(Detail breakdown)
        {
            int moneyForPay = CostCalculation(breakdown);

            _money -= moneyForPay;
            Console.WriteLine($"Money now - {_money}");
        }

        public void Payment(Detail breakdown)
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

        public Detail(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Detail - {Name}, cost - {Cost}");
        }
    }

    class Screw : Detail
    {
        public Screw(string name, int cost) : base(name, cost) { }
    }

    class Bolt : Detail
    {
        public Bolt(string name, int cost) : base(name, cost) { }
    }

    class Shaft : Detail
    {
        public Shaft(string name, int cost) : base(name, cost) { }
    }

    class Client
    {
        private static Random _random;

        public Detail Breakdown { get; private set; }

        static Client()
        {
            _random = new Random();
        }

        public Client()
        {
            List<Detail> allDetails = new List<Detail>();

            Detail bolt = new Bolt("bolt", 100);
            Detail screw = new Screw("screw", 200);
            Detail shaft = new Shaft("shaft", 1000);

            allDetails.Add(bolt);
            allDetails.Add(screw);
            allDetails.Add(shaft);

            int randomBreakdown = _random.Next(0, allDetails.Count);

            Breakdown = new Bolt(allDetails[randomBreakdown].Name, allDetails[randomBreakdown].Cost);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Client needs a replacement - {Breakdown.Name}");
        }
    }
}
