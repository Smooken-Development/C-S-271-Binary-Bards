using System;
using System.Collections.Generic;

public class Player
{
    public int Health { get; set; }
    public List<string> Inventory { get; set; }

    public Player()
    {
        Health = 100;
        Inventory = new List<string>();
    }

    public int Attack()
    {
        var random = new Random();
        int damage = random.Next(5, 16);            //random damage
        return damage;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Console.WriteLine("\n\nYou have been defeated!");
        }
    }

    public void DisplayInventory()
    {
        if (Inventory.Count > 0)
        {
            Console.WriteLine("Your inventory:");
            foreach (var item in Inventory)
            {
                Console.WriteLine($"- {item}");         //print each item on new line
            }
        }
        else
        {
            Console.WriteLine("Inventory is empty.");
        }
    }
}

public class Monster
{
    public string Name { get; set; }            // type of monster
    public int Health { get; set; }
    public int AttackPower { get; set; }

    public Monster(string name, int health, int attackPower)    // opps constructor
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
    }

    public int Attack()
    {
        var random = new Random();
        int damage = random.Next(AttackPower - 2, AttackPower + 3);     //+3/-2 range
        return damage;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Console.WriteLine($"\n\n{Name} has been defeated!");
        }
    }
}

public class Program
{
    public static void ExploreDungeon(Player player)
    {
        while (player.Health > 0)
        {
            Console.WriteLine("\nYou are in a dungeon.");
            Console.WriteLine("1. Go deeper");
            Console.WriteLine("2. Check inventory");
            Console.WriteLine("3. Exit area");

            string choice = Console.ReadLine();

            switch (choice)                                 //user input option
            {
                case "1":
                    Encounter(player);
                    break;
                case "2":
                    player.DisplayInventory();
                    break;
                case "3":
                    Console.WriteLine("\n\nYou exit the dungeon.");
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }

        if (player.Health <= 0)
        {
            Console.WriteLine("\nGame Over!");
        }
    }

    private static void Encounter(Player player)
    {
        var random = new Random();
        Monster monster;
        switch (random.Next(0, 3))                              //random monster choice          
        {
            case 0:
                monster = new Monster("Goblin", 10, 5);
                break;
            case 1:
                monster = new Monster("Orc", 15, 8);
                break;
            case 2:
                monster = new Monster("Troll", 30, 12);
                break;
            default:
                monster = null;
                break;
        }

        Console.WriteLine($"\nA wild {monster.Name} appears!");

        Battle(player, monster);

        if (player.Health > 0 && monster.Health <= 0)
        {
            Console.WriteLine($"\nYou defeated the {monster.Name}!");
            AddLoot(player);                                                    //inventory item
        }
    }


    private static void Battle(Player player, Monster monster)              //2 objects as args
    {
        while (player.Health > 0 && monster.Health > 0)
        {
            Console.WriteLine($"\nYour health: {player.Health}");
            Console.WriteLine($"{monster.Name}'s health: {monster.Health}");
            Console.WriteLine("\n1. Attack");
            Console.WriteLine("2. Flee");

            string action = Console.ReadLine();

            if (action == "1")
            {
                monster.TakeDamage(player.Attack());
                if (monster.Health > 0)
                {
                    player.TakeDamage(monster.Attack());
                }
            }
            else if (action == "2")
            {
                Console.WriteLine($"\nYou flee from the {monster.Name}! \nCoward...");
                break;
            }
            else
            {
                Console.WriteLine("Invalid action!");
            }
        }
    }

   private static void AddLoot(Player player)
   {
    var random = new Random();
    string loot;
    switch (random.Next(0, 3))  
    {
        case 0:
            loot = "Health Potion";
            break;
        case 1:
            loot = "Sword";
            break;
        case 2:
            loot = "Shield";
            break;
        default:
            loot = null;
            break;
    }

    player.Inventory.Add(loot);                     //add item to list
    Console.WriteLine($"\nYou found a {loot}!");
}

    public static void Main()
    {
        var player = new Player();
        ExploreDungeon(player);
    }
}

