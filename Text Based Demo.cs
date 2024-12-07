// CS 271 - Text Based RPG
/* ChatGPT Use:

                ___Full_Disclaimer___

                ChatGPT was used to help me significantly condense parts of the
                Text-Based demo that I made for the Binary Bards program and to
                help me finish the the combat system. ChatGPT was also used to
                help me finish some functionality that was proposed for the
                group final project.

                This program is based around the Text-Based demo I made for the
                final group project, but since we aren't using it; I decided to
                rework it for the extra credit assignment since I was the one
                who programmed it.
*/
using System;
using System.Collections.Generic;

// Start Program
public class Program
{
    static void Main(string[] args)
    {
        Game.StartAdventure();
    }
}
// End Program

// Game Classes
public static class Game
{
    // Starts a new adventure for the player.
    public static void StartAdventure()
    {
        Console.WriteLine("Welcome to Binary Bards: Unleashed!");
        Console.WriteLine("You find yourself in a mysterious forest.");
        // Create a new player with a name, health, attack power, and defense
        Player player = new Player("Hero", 100, 10, 5);

        bool isPlaying = true;
        while (isPlaying)
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Explore the forest");
            Console.WriteLine("2. Check your stats");
            Console.WriteLine("3. Exit the game");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                // Explore the forest, which may result in a combat encounter
                case "1":
                    Encounter(player);
                    break;
                // Display the player's current stats
                case "2":
                    player.DisplayStats();
                    break;
                // Exit the game
                case "3":
                    isPlaying = false;
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Thanks for playing!");
                    break;
                // Handle invalid input
                default:
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    public static void Encounter(Player player)
    {
        Random random = new Random();
        int encounterType = random.Next(1, 4);

        // 1. Treasure chest with a healing potion
        if (encounterType == 1)
        {
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("You found a treasure chest! Inside, you find a healing potion.");
            player.Heal(20);
        }
        // 2. Combat with a goblin
        else if (encounterType == 2)
        {
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Enemy goblin = new Enemy("Goblin", 30, 8);
            Console.WriteLine($"A wild {goblin.Name} appears!");
            Combat(player, goblin);
        }
        // 3. Nothing happens
        else
        {
            Console.WriteLine("The forest is eerily quiet. Nothing happens...");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            
        }
    }
    public static void Combat(Player player, Enemy enemy)
    {
        // Continue combat until one participant's health drops to zero or below
        while (player.Health > 0 && enemy.Health > 0)
        {
            Console.WriteLine("\nYour turn:");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Defend");
            Console.Write("Choose an action: ");
            string choice = Console.ReadLine();

            // Execute player's chosen action
            if (choice == "1")
            {
                player.Attack(enemy);
            }
            else if (choice == "2")
            {
                Console.WriteLine($"{player.Name} defends, reducing incoming damage.");
                player.Defend(enemy);
            }
            else
            {
                Console.WriteLine("Invalid action. Turn skipped.");
            }

            // Enemy's turn to attack if still alive
            if (enemy.Health > 0)
            {
                Console.WriteLine($"\n{enemy.Name}'s turn:");
                enemy.Attack(player);
            }
        }

        // Determine combat outcome
        if (player.Health <= 0)
        {
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("You have been defeated. Game over.");
            Environment.Exit(0); // Exit the game if the player is defeated
        }
        else
        {
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine($"You defeated the {enemy.Name}!");
            player.GainExperience(20); // Reward player with experience points
        }
    }
}

// Character Classes
public class Player
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public int Defense { get; set; }
    public int Experience { get; set; }
    public int Level { get; set; }

    public Player(string name, int health, int attackPower, int defense)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
        Defense = defense;
        Experience = 0;
        Level = 1;
    }

    public void Attack(Enemy target)
    {
        System.Threading.Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine($"{Name} attacks {target.Name} for {AttackPower} damage.");
        target.TakeDamage(AttackPower);
    }

    public void Defend(Enemy attacker)
    {
        // Calculate the reduced damage by subtracting defense from the attacker's attack power
        int reducedDamage = Math.Max(0, attacker.AttackPower - Defense);
        
        // Subtract the reduced damage from the player's health
        Health -= reducedDamage;
        
        // Output the result of the defense
        Console.WriteLine($"{Name} takes {reducedDamage} reduced damage. Health is now {Health}.");
    }

    public void Heal(int amount)
    {
        Health += amount;
        Console.WriteLine($"{Name} heals for {amount} points. Health is now {Health}.");
    }

    public void GainExperience(int amount)
    {
        Experience += amount;
        Console.WriteLine($"{Name} gains {amount} experience points.");
        if (Experience >= Level * 50)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        Level++;
        Experience = 0;
        AttackPower += 5;
        Defense += 2;
        Health += 20;
        System.Threading.Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine($"{Name} leveled up to level {Level}!");
        Console.WriteLine($"Stats increased: Health: {Health}, Attack: {AttackPower}, Defense: {Defense}");
    }

    public void DisplayStats()
    {
        System.Threading.Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Health: {Health}");
        Console.WriteLine($"Attack: {AttackPower}");
        Console.WriteLine($"Defense: {Defense}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine($"Experience: {Experience}");
    }
}

public class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }

    public Enemy(string name, int health, int attackPower)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
    }

    public void Attack(Player target)
    {
        System.Threading.Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine($"{Name} attacks {target.Name} for {AttackPower} damage.");
        target.Health -= AttackPower;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        System.Threading.Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine($"{Name} takes {damage} damage. Health is now {Health}.");
    }
}
