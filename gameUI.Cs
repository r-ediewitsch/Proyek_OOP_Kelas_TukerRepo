using System;
using System.Collections.Generic;

namespace EndlessEnds
{
    public class GameUI
    {
        private Character player;
        private List<Item> inventory = new List<Item>();
        private Battle battle;
        private Character companion; // Companion untuk membantu di battle

        public GameUI(Character player)
        {
            this.player = player;
            this.battle = new Battle();

            // Menambahkan item dasar ke inventory
            inventory.Add(new Item("Basic Sword", ItemType.Weapon, "Basic attack boost"));
            inventory.Add(new Item("Health Potion", ItemType.Potion, "Restore 50 HP"));
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Endless Ends!");
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

            // Companion membantu di pertempuran tertentu
            if (companion != null)
            {
                Console.WriteLine($"{companion.CharacterName} joins the battle!");
                battle.StartCombat(player, enemy, companion);
            }
            else
            {
                battle.StartCombat(player, enemy);
            }

            // Jika player menang, beri loot
            if (enemy.Health <= 0)
            {
                Console.WriteLine("You found a loot!");
                var loot = new Item("Mystic Potion", ItemType.Potion, "Restore 100 HP");
                inventory.Add(loot);
                Console.WriteLine($"Added {loot} to inventory.");
            }
        }

        private void DisplayCharacterStats()
        {
            Console.WriteLine("\n--- Character Stats ---");
            Console.WriteLine(player.ToString());
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
