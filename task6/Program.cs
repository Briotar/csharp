using System;
using System.Collections.Generic;

namespace Task6_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Fighter> fighters = new List<Fighter>();
            Warrior warrior = new Warrior();
            Mage mage = new Mage();
            Thief thief = new Thief();
            Imba imba = new Imba();
            Weakest weakest = new Weakest();
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
            firstFighter = GetFighterNumber();
            Console.Write("Choose second fighter: ");
            secondFighter = GetFighterNumber();

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

        static int GetFighterNumber()
        {
            string fighterNumber;
            int fighterNumberInt;

            fighterNumber = Console.ReadLine();
            Int32.TryParse(fighterNumber, out fighterNumberInt);

            if (fighterNumberInt > 5 || fighterNumberInt < 1)
            {
                Console.WriteLine("Enter number 1-5! Вefault selection - 1");
                return 0;
            }
            else
            {
                return fighterNumberInt - 1;
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
    public Warrior()
    {
        Name = "warrior";
        Health = 250;
        mana = 0;
        armor = 10;
        damage = 50;
    }

    public override void Attack(Fighter enemy)
    {
        enemy.TakeDamage(damage);
    }
}

class Mage : Fighter
{
    public Mage()
    {
        Name = "mage";
        Health = 100;
        mana = 20;
        armor = 3;
        damage = 70;
    }

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
    public Thief()
    {
        Name = "thief";
        Health = 150;
        mana = 10;
        armor = 4;
        damage = 60;
    }

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
    public Imba()
    {
        Name = "imba";
        Health = 999;
        mana = 999;
        armor = 20;
        damage = 999;
    }

    public override void Attack(Fighter enemy)
    {
        int totalDamage = damage + mana;
        mana += 999;
        enemy.TakeDamage(totalDamage);
    }
}

class Weakest : Fighter
{
    public Weakest()
    {
        Name = "weakest";
        Health = 10;
        mana = 0;
        armor = 0;
        damage = 5;
    }

    public override void Attack(Fighter enemy)
    {
        damage++;
        enemy.TakeDamage(damage);
    }
}

