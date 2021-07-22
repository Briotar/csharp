using System;
using System.Collections.Generic;

namespace Task8_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Troop troopPakistan = new Troop();
            Troop troopIndia = new Troop();
            MachineGunner machineGunner = new MachineGunner(150, 20, 75, "Billy1");
            MachineGunner machineGunner1 = new MachineGunner(160, 22, 73, "Billy2");
            Shooter shooter = new Shooter(100, 50, 85, "John");
            Shooter shooter1 = new Shooter(110, 55, 86, "John1");
            Shooter shooter2 = new Shooter(115, 48, 90, "John2");

            troopPakistan.AddSolder(machineGunner);
            troopPakistan.AddSolder(shooter);
            troopPakistan.AddSolder(shooter1);

            troopIndia.AddSolder(machineGunner1);
            troopIndia.AddSolder(shooter2);

            ShowInfoTroop(troopIndia, troopPakistan, false);
            ShowInfoTroop(troopIndia, troopPakistan, true);

            while(troopIndia.Solders.Count > 0 && troopPakistan.Solders.Count > 0)
            {
                Console.WriteLine("\nIndia attack!");
                troopIndia.Attack(troopPakistan);
                ShowInfoTroop(troopIndia, troopPakistan, false);

                Console.WriteLine("\nPakistan attack!");
                troopPakistan.Attack(troopIndia);
                ShowInfoTroop(troopIndia, troopPakistan, true);

                Console.ReadKey();
            }

            if(troopIndia.Solders.Count > 0)
            {
                Console.WriteLine("\nIndia win!");
            }
            else
            {
                Console.WriteLine("\nPakistan win!");
            }
        }

        static void ShowInfoTroop(Troop troopIndia, Troop troopPakistan, bool isIndia = true)
        {
           if(isIndia)
           {
                Console.WriteLine("India troop:");
                troopIndia.ShowInfo();
           }
           else
           {
                Console.WriteLine("Pakistan troop:");
                troopPakistan.ShowInfo();
           }
        }
    }

    class Troop
    {
        public List<Solder> Solders { get; private set; }

        public Troop()
        {
            Solders = new List<Solder>();
        }

        public void AddSolder(Solder solder)
        {
            Solders.Add(solder);
        }

        public void ShowInfo()
        {
            for (int i = 0; i < Solders.Count; i++)
            {
                Console.Write((i + 1) + ")");
                Solders[i].ShowInfo();
            }
        }

        public void Attack(Troop troopEnemy)
        {
            for (int i = 0; i < Solders.Count; i++)
            {
                Solders[i].Attack(troopEnemy);
            }

            CheckSolderHealth(troopEnemy);
        }

        private void CheckSolderHealth(Troop troopEnemy)
        {
            for (int i = 0; i < troopEnemy.Solders.Count; i++)
            {
                if(troopEnemy.Solders[i].Health <= 0)
                {
                    troopEnemy.Solders.RemoveAt(i);
                }
            }
        }
    }

    abstract class Solder
    {
        protected string Name;
        protected int Damage;
        protected int Accuracy;
        protected static Random Random;

        public int Health { get; protected set; }

        public Solder(int health, int setDamage, int setAccuracy, string setName)
        {
            Health = health;
            Name = setName;
            Damage = setDamage;
            Accuracy = setAccuracy;
            Random = new Random();
        }

        public abstract void Attack(Troop troopEnemy);

        public void ShowInfo()
        {
            Console.WriteLine($"Name - {Name}, hp - {Health}, dmg - {Damage}, accuracy - {Accuracy}");
        }

        public void TakeDamage(int damage, int accuracy)
        {
            int hitProbability = Random.Next(1, 100);
            if(hitProbability <= accuracy)
            {
                Console.WriteLine("Hit!");
                Health -= damage;
            }
            else
            {
                Console.WriteLine("Miss!");
            }
        }
    }

    class MachineGunner : Solder
    {
        public MachineGunner(int health, int setDamage, int setAccuracy, string setName) 
            : base(health, setDamage, setAccuracy, setName) { }

        public override void Attack(Troop troopEnemy)
        {
            for (int i = 0; i < troopEnemy.Solders.Count; i++)
            {
                Console.WriteLine("Machinegunner attack!");
                AttackAllEnemy(troopEnemy, i);
                troopEnemy.Solders[i].TakeDamage(Damage, Accuracy);
            }
        }

        private void AttackAllEnemy(Troop troopEnemy, int solderIndex)
        {
            int shoot = Random.Next(1, 3);

            if(shoot == 1)
            {
                troopEnemy.Solders[solderIndex].TakeDamage(Damage, Accuracy);
            }
        }
    }

    class Shooter : Solder
    {
        public Shooter(int health, int setDamage, int setAccuracy, string setName)
            : base(health, setDamage, setAccuracy, setName) { }

        public override void Attack(Troop troopEnemy)
        {
            Console.WriteLine("Shooter attack!");
            int targetAttack = Random.Next(0, troopEnemy.Solders.Count);
            ShotEnemy(troopEnemy, targetAttack);
            troopEnemy.Solders[targetAttack].TakeDamage(Damage, Accuracy);
        }

        private void ShotEnemy(Troop troopEnemy, int solderIndex)
        {
            int shoot = Random.Next(1, 2);
            int accurancy = 100;
            int increasedDamage = Damage + 15;

            if (shoot == 1)
            {
                troopEnemy.Solders[solderIndex].TakeDamage(increasedDamage, accurancy);
            }
        }
    }
}
