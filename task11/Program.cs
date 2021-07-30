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
            Detail detailBolt = new Detail("bolt", 100, 1);
            Detail detailVint = new Detail("vint", 200, 1);
            Detail detailVal = new Detail("val", 1000, 1);
            bool isWorking = true;
            bool isHaveDetail = false;
            int numberMenu;
            int maxNumberMenu = 2;
            int detailIndex = 0;

            allDetails.Add(detailBolt);
            allDetails.Add(detailVint);
            allDetails.Add(detailVal);

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
                    Client client = new Client(allDetails);
                    client.ShowInfo();

                    for (int i = 0; i < service.Details.Count; i++)
                    {
                        if(service.Details[i].Name == client.Breakdown.Name)
                        {
                            detailIndex = i;
                            isHaveDetail = true;
                            Console.WriteLine("We have:");
                            service.Details[i].ShowInfo();
                        }
                    }

                    if(isHaveDetail)
                    {
                        Console.WriteLine("Replaced detail");

                        int serviceCost = service.CostCalculation(client.Breakdown);
                        Console.WriteLine($"Service cost - {serviceCost}");

                        service.GetMoney(client.Breakdown);
                        service.Details[detailIndex].DecreaseCountDetail();
                        service.Details[detailIndex].ShowInfo();
                    }
                    else
                    {
                        Console.WriteLine("We dont have such detail(");

                        int fineCost = service.FineCalculation(client.Breakdown);
                        Console.WriteLine($"Fine cost - {fineCost}");

                        service.PayMoney(client.Breakdown);
                    }

                    for (int i = 0; i < service.Details.Count; i++)
                    {
                        if(service.Details[i].Count == 0)
                        {
                            service.Details.RemoveAt(i);
                        }    
                    }

                    isHaveDetail = false;
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

        public Service(int money)
        {
            Details = new List<Detail>();
            _money = money;

            Detail detailBolt = new Detail("bolt", 100, 1);
            Detail detailVint = new Detail("vint", 200, 2);
            Detail detailVal = new Detail("val", 1000, 2);

            Details.Add(detailBolt);
            Details.Add(detailVint);
            Details.Add(detailVal);
        }

        public void PayMoney(Detail breakdown)
        {
            int moneyForPay = FineCalculation(breakdown);

            _money -= moneyForPay;
            Console.WriteLine($"Money now - {_money}");
        }

        public void GetMoney(Detail breakdown)
        {
            int moneyForPay = CostCalculation(breakdown);

            _money += moneyForPay;
            Console.WriteLine($"Money now - {_money}");
        }

        public int FineCalculation(Detail detail)
        {
            return (detail.Cost * 2);
        }

        public int CostCalculation(Detail detail)
        {
            return (detail.Cost * 2);
        }
    }

    class Detail
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

    class Client
    {
        private static Random _random;

        public Detail Breakdown { get; private set; }

        public Client(List<Detail> details)
        {
            _random = new Random();
            int randomBreakdown = _random.Next(0, details.Count);

            Breakdown = new Detail(details[randomBreakdown].Name, details[randomBreakdown].Cost, 1);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Client needs a replacement - {Breakdown.Name}");
        }
    }
}
