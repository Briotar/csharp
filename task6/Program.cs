using System;
using System.Collections.Generic;

namespace Task6_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Fighter> fighters = new List<Fighter>();
            Warrior warrior = new Warrior("warrior", 250, 0, 10, 50);
            Mage mage = new Mage("mage", 100, 20, 3, 70);
            Thief thief = new Thief("thief", 150, 10, 4, 60);
            Imba imba = new Imba("imba", 999, 999, 20, 999);
            Weakest weakest = new Weakest("weakest", 10, 0, 0, 5);
            int firstFighter;
            int secondFighter;

            fighters.Add(warrior);
            fighters.Add(mage);
            fighters.Add(thief);
            fighters.Add(imba);
            fighters.Add(weakest);

            for (int i = 0; i < fighters.Count; i++)
            {
                Console.Write((i + 1) + ")");
                fighters[i].ShowStats();
            }

            Console.Write("Choose first fighter: ");
            firstFighter = GetFighterNumber(fighters);
            Console.Write("Choose second fighter: ");
            secondFighter = GetFighterNumber(fighters);

            Console.WriteLine("\nStart!");

            while ((fighters[firstFighter].Health > 0) && (fighters[secondFighter].Health > 0))
            {
                Console.WriteLine("Opponents attack each other");

                fighters[firstFighter].Attack(fighters[secondFighter]);
                fighters[secondFighter].Attack(fighters[firstFighter]);

                fighters[firstFighter].ShowHealth();
                fighters[secondFighter].ShowHealth();

                Console.WriteLine();
                Console.ReadKey();
            }

            if((fighters[firstFighter].Health < 0) && (fighters[secondFighter].Health < 0))
            {
                Console.WriteLine("Draw!");
            }
            else if (fighters[firstFighter].Health > 0)
            {
                Console.WriteLine($"Winner - {fighters[firstFighter].Name}");
            }
            else
            {
                Console.WriteLine($"Winner - {fighters[secondFighter].Name}");
            }

            Console.ReadKey();
        }

        static int GetFighterNumber(List<Fighter> fighters)
        {
            string fighterNumber;
            int fighterNumberInt;
            bool isConverted;

            fighterNumber = Console.ReadLine();
            isConverted = Int32.TryParse(fighterNumber, out fighterNumberInt);

            if(isConverted)
            {
                if (fighterNumberInt > fighters.Count || fighterNumberInt < 1)
                {
                    Console.WriteLine($"Enter number 1-{fighters.Count}! Вefault selection - 1");
                    return 0;
                }
                else
                {
                    return fighterNumberInt - 1;
                }
            }
            else
            {
                Console.WriteLine("Enter number 1-5! Вefault selection - 1");
                return 0;
            }
        }
    }
}

abstract class Fighter
{
    protected int mana;
    protected int armor;
    protected int damage;

    public int Health { get; protected set; }
    public string Name { get; protected set; }

    public Fighter(string name, int health, int setMana, int setArmor, int setDamage)
    {
        Name = name;
        Health = health;
        mana = setMana;
        armor = setArmor;
        damage = setDamage;
    }

    public abstract void Attack(Fighter enemy);

    public void TakeDamage(int damage)
    {
        Health -= damage - armor;
    }

    public void ShowStats()
    {
        Console.WriteLine($"Name - {Name}, health - {Health}, mana - {mana}," +
            $" armor - {armor}, damage - {damage}");
    }

    public void ShowHealth()
    {
        Console.WriteLine($"{Name} has - {Health} HP!");
    }
}

class Warrior : Fighter
{
    public Warrior(string name, int health, int setMana, int setArmor, int setDamage)
        : base(name, health, setMana, setArmor, setDamage) { }


    public override void Attack(Fighter enemy)
    {
        enemy.TakeDamage(damage);
    }
}

class Mage : Fighter
{
    public Mage(string name, int health, int setMana, int setArmor, int setDamage)
        : base(name, health, setMana, setArmor, setDamage) { }

    public override void Attack(Fighter enemy)
    {
        int totalDamage = 0;

        if (mana >= 10)
        {
            totalDamage = damage + mana;
            mana -= 10;
        }
        else
        {
            totalDamage = damage;
        }

        enemy.TakeDamage(totalDamage);
    }
}

class Thief : Fighter
{
    public Thief(string name, int health, int setMana, int setArmor, int setDamage)
        : base(name, health, setMana, setArmor, setDamage) { }

    public override void Attack(Fighter enemy)
    {
        int totalDamage = 0;

        if(enemy.Health < 100)
        {
            totalDamage = damage * 2;
        }
        else
        {
            totalDamage = damage;
        }

        enemy.TakeDamage(totalDamage);
    }
}

class Imba : Fighter
{
    public Imba(string name, int health, int setMana, int setArmor, int setDamage)
        : base(name, health, setMana, setArmor, setDamage) { }

    public override void Attack(Fighter enemy)
    {
        int totalDamage = damage + mana;
        mana += 999;
        enemy.TakeDamage(totalDamage);
    }
}

class Weakest : Fighter
{
    public Weakest(string name, int health, int setMana, int setArmor, int setDamage)
        : base(name, health, setMana, setArmor, setDamage) { }

    public override void Attack(Fighter enemy)
    {
        damage++;
        enemy.TakeDamage(damage);
    }
}

