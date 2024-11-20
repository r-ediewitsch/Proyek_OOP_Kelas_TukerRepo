using System;
using System.Collections.Generic;

namespace EndlessEnds
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Welcome to Endless Ends ===");
            Console.Write("Enter your character name: ");
            string name = Console.ReadLine();

            // Inisialisasi player
            Character player = new Character(name, 100, "Rusty Sword", "Basic Potion");

            // Mulai game
            GameUI gameUI = new GameUI(player);
            gameUI.Start();
        }
    }

    public class Character
    {
        public string CharacterName { get; set; }
        public float Health { get; set; }
        public string Weapon { get; set; }
        public string Potion { get; set; }

        public Character(string name, float health, string weapon, string potion)
        {
            CharacterName = name;
            Health = health;
            Weapon = weapon;
            Potion = potion;
        }

        public void Attack(Enemy enemy)
        {
            Console.WriteLine($"You attacked the {enemy.Name} for 10 damage!");
            enemy.Health -= 10;
        }

        public void UseMagic(int choice, Enemy enemy)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("You used Arcane Blast! It dealt 15 damage.");
                    enemy.Health -= 15;
                    break;
                case 2:
                    Console.WriteLine("You used Mystic Coating! You feel protected.");
                    break;
                case 3:
                    Console.WriteLine("You used Rejuvenate! You restored 20 HP.");
                    Health += 20;
                    break;
                default:
                    Console.WriteLine("Invalid magic choice. You wasted a turn.");
                    break;
            }
        }

        public void Defend()
        {
            Console.WriteLine("You chose to defend. Damage will be reduced on the next attack.");
        }
    }

    public class Enemy
    {
        public string Name { get; set; }
        public float Health { get; set; }
        public int AttackPower { get; set; }

        public Enemy(string name, float health, int attackPower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
        }

        public void Attack(Character player)
        {
            Console.WriteLine($"The {Name} strikes back!");
            Console.WriteLine($"You took {AttackPower} damage.");
            player.Health -= AttackPower;
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }

        public Item(string name, ItemType type)
        {
            Name = name;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Name} ({Type})";
        }
    }

    public enum ItemType
    {
        Weapon,
        Potion
    }

    public class Battle
    {
        public void StartCombat(Character player, Enemy enemy)
        {
            while (enemy.Health > 0 && player.Health > 0)
            {
                Console.WriteLine("\nChoose your action:");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Magic");
                Console.WriteLine("3. Defend");

                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        player.Attack(enemy);
                        break;
                    case "2":
                        Console.WriteLine("Choose your magic:");
                        Console.WriteLine("1. Arcane Blast");
                        Console.WriteLine("2. Mystic Coating");
                        Console.WriteLine("3. Rejuvenate");

                        if (int.TryParse(Console.ReadLine(), out int magicChoice))
                        {
                            player.UseMagic(magicChoice, enemy);
                        }
                        else
                        {
                            Console.WriteLine("Invalid magic choice. You wasted a turn.");
                        }
                        break;
                    case "3":
                        player.Defend();
                        break;
                    default:
                        Console.WriteLine("Invalid action.");
                        continue;
                }

                if (enemy.Health > 0)
                {
                    enemy.Attack(player);
                }
            }

            if (enemy.Health <= 0)
            {
                Console.WriteLine("Enemy Defeated!");
            }
            else
            {
                Console.WriteLine("You have been slain.");
                Console.WriteLine("Game Over");
                Environment.Exit(0);
            }
        }
    }

    public class GameUI
    {
        private Character player;
        private List<Item> inventory = new List<Item>();
        private Battle battle;

        public GameUI(Character player)
        {
            this.player = player;
            this.battle = new Battle();

            // Menambahkan item dasar ke inventory
            inventory.Add(new Item("Basic Sword", ItemType.Weapon));
            inventory.Add(new Item("Health Potion", ItemType.Potion));
        }

        public void Start()
        {
            Console.WriteLine($"Welcome, {player.CharacterName}!");
            DisplayMainMenu();
        }

        private void DisplayMainMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Main Menu ---");
                Console.WriteLine("1. Explore World");
                Console.WriteLine("2. View Character Stats");
                Console.WriteLine("3. Open Inventory");
                Console.WriteLine("4. Quit Game");
                Console.Write("Choose an option (1-4): ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ExploreWorld();
                        break;
                    case "2":
                        DisplayCharacterStats();
                        break;
                    case "3":
                        OpenInventory();
                        break;
                    case "4":
                        Console.WriteLine("Thank you for playing Endless Ends!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void ExploreWorld()
        {
            Console.WriteLine("\nYou venture into the mysterious lands of Endless Ends...");
            Console.WriteLine("You encounter a hostile creature!");

            // Buat instance Enemy untuk bertarung
            Enemy enemy = new Enemy("Goblin", 30, 5);
            battle.StartCombat(player, enemy);

            // Jika player menang, beri loot
            if (enemy.Health <= 0)
            {
                Console.WriteLine("You found a loot!");
                var loot = new Item("Mystic Potion", ItemType.Potion);
                inventory.Add(loot);
                Console.WriteLine($"Added {loot} to inventory.");
            }
        }

        private void DisplayCharacterStats()
        {
            Console.WriteLine("\n--- Character Stats ---");
            Console.WriteLine($"Name: {player.CharacterName}");
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine($"Weapon: {player.Weapon}");
            Console.WriteLine($"Potion: {player.Potion}");
        }

        private void OpenInventory()
        {
            Console.WriteLine("\n--- Inventory ---");
            if (inventory.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
            }
            else
            {
                foreach (var item in inventory)
                {
                    Console.WriteLine("- " + item);
                }
            }
        }
    }
}
