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

            troopPakistan.AddToList(machineGunner);
            troopPakistan.AddToList(shooter);
            troopPakistan.AddToList(shooter1);

            troopIndia.AddToList(machineGunner1);
            troopIndia.AddToList(shooter2);

            Console.WriteLine("Pakistan troop:");
            troopPakistan.ShowInfo();
            Console.WriteLine("India troop:");
            troopIndia.ShowInfo();

            while(troopIndia.Solders.Count > 0 && troopPakistan.Solders.Count > 0)
            {
                Console.WriteLine("\nIndia attack!");
                troopIndia.Attack(troopPakistan);
                Console.WriteLine("Pakistan troop:");
                troopPakistan.ShowInfo();

                Console.WriteLine("\nPakistan attack!");
                troopPakistan.Attack(troopIndia);
                Console.WriteLine("India troop:");
                troopIndia.ShowInfo();

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
    }

    class Troop
    {
        public List<Solder> Solders { get; private set; }

        public Troop()
        {
            Solders = new List<Solder>();
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

        public void AddToList(Solder solder)
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
    }

    abstract class Solder
    {
        protected string name;
        protected int damage;
        protected int accuracy;
        protected Random random;

        public int Health { get; protected set; }

        public Solder(int health, int setDamage, int setAccuracy, string setName)
        {
            Health = health;
            name = setName;
            damage = setDamage;
            accuracy = setAccuracy;
            random = new Random();
        }

        public abstract void Attack(Troop troopEnemy);

        public void ShowInfo()
        {
            Console.WriteLine($"Name - {name}, hp - {Health}, dmg - {damage}, accuracy - {accuracy}");
        }

        public void TakeDamage(int damage, int accuracy)
        {
            int hitProbability = random.Next(1, 100);
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
                troopEnemy.Solders[i].TakeDamage(damage, accuracy);
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
            int targetAttack = random.Next(0, troopEnemy.Solders.Count);
            troopEnemy.Solders[targetAttack].TakeDamage(damage, accuracy);
        }
    }
}
