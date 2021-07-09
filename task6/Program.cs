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
            firstFighter = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("Choose second fighter: ");
            secondFighter = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.WriteLine("\nStart!");

            while ((fighters[firstFighter].Health > 0) && (fighters[secondFighter].Health > 0))
            {
                Console.WriteLine("Opponents attack each other");

                fighters[firstFighter].UniqueAttack(fighters[secondFighter]);
                fighters[secondFighter].UniqueAttack(fighters[firstFighter]);

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
    }
}

abstract class Fighter
{
    protected int _mana;
    protected int _armor;
    protected int _damage;

    public int Health { get; protected set; }
    public string Name { get; protected set; }

    public abstract void UniqueAttack(Fighter enemy);

    public void TakeDamage(int damage)
    {
        Health -= damage - _armor;
    }

    public void ShowStats()
    {
        Console.WriteLine($"Name - {Name}, health - {Health}, mana - {_mana}," +
            $" armor - {_armor}, damage - {_damage}");
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
        _mana = 0;
        _armor = 10;
        _damage = 50;
    }

    public override void UniqueAttack(Fighter enemy)
    {
        enemy.TakeDamage(_damage);
    }
}

class Mage : Fighter
{
    public Mage()
    {
        Name = "mage";
        Health = 100;
        _mana = 20;
        _armor = 3;
        _damage = 70;
    }

    public override void UniqueAttack(Fighter enemy)
    {
        int totalDamage = 0;

        if (_mana >= 10)
        {
            totalDamage = _damage + _mana;
            _mana -= 10;
        }
        else
        {
            totalDamage = _damage;
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
        _mana = 10;
        _armor = 4;
        _damage = 60;
    }

    public override void UniqueAttack(Fighter enemy)
    {
        int totalDamage = 0;

        if(enemy.Health < 100)
        {
            totalDamage = _damage * 2;
        }
        else
        {
            totalDamage = _damage;
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
        _mana = 999;
        _armor = 20;
        _damage = 999;
    }

    public override void UniqueAttack(Fighter enemy)
    {
        int totalDamage = _damage + _mana;
        _mana += 999;
        enemy.TakeDamage(totalDamage);
    }
}

class Weakest : Fighter
{
    public Weakest()
    {
        Name = "weakest";
        Health = 10;
        _mana = 0;
        _armor = 0;
        _damage = 5;
    }

    public override void UniqueAttack(Fighter enemy)
    {
        _damage++;
        enemy.TakeDamage(_damage);
    }
}

