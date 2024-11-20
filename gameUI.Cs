using System;
using System.Collections.Generic;

namespace EndlessEnds
{
    public class GameUI
    {
        private Character player;
        private List<Item> inventory = new List<Item>();
        private Battle battle;

        private Room mainVillage;
        private Room ancientForest;
        private Room crystalLake;
        private Room elderCavern;
        private Room dreamWorld;

        private CrystalLakeInteraction crystalLakeInteraction;

        public GameUI(Character player)
        {
            this.player = player;
            this.battle = new Battle();
            InitializeRooms();

            crystalLakeInteraction = new CrystalLakeInteraction(player, battle);

            // Adding basic items to inventory
            inventory.Add(new Item("Basic Sword", ItemType.Weapon, 10));
            inventory.Add(new Item("Health Potion", ItemType.Potion, 0));
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

            Room currentRoom = mainVillage;

            while (true)
            {
                Console.WriteLine($"\nYou are in {currentRoom.Name}.");
                Console.WriteLine(currentRoom.Description);
                Console.WriteLine("Exits: " + string.Join(", ", currentRoom.Exits.Keys));

                Console.WriteLine("\nChoose your action:");
                Console.WriteLine("1. Move");
                Console.WriteLine("2. Look around");
                Console.WriteLine("3. Quit exploring");

                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        Console.Write("Enter direction (north, east, south, west): ");
                        string direction = Console.ReadLine();
                        Room nextRoom = currentRoom.GetExit(direction);
                        if (nextRoom != null)
                        {
                            currentRoom = nextRoom;
                            crystalLakeInteraction.Handle(direction, currentRoom.Name);
                        }
                        else
                        {
                            Console.WriteLine("There is no door in that direction!");
                        }
                        break;
                    case "2":
                        Console.WriteLine("You look around the room. It's calm and peaceful.");
                        // You can add more interactions here
                        break;
                    case "3":
                        Console.WriteLine("You stop exploring and return to the main menu.");
                        return;
                    default:
                        Console.WriteLine("Invalid action. Please try again.");
                        break;
                }
            }
        }

        private void DisplayCharacterStats()
        {
            Console.WriteLine("\n--- Character Stats ---");
            Console.WriteLine($"Name: {player.CharacterName}");
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine($"Weapon: {player.Weapon.Name} (Damage: {player.Weapon.Damage})");
            Console.WriteLine($"Potion: {player.Potion.Name}");
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

        private void InitializeRooms()
        {
            dreamWorld = new Room("Dream World", "world full of clouds, fog as thick as dreams alike.");
            ancientForest = new Room("Ancient Forest", "A vast forest where the ancient monsters dwell.");
            mainVillage = new Room("Main Village", "Home village where I live.");
            elderCavern = new Room("Elder Cavern", "Cavern that eminates darkness around it.");
            crystalLake = new Room("Crystal Lake", "A lake full of magical crystals.");

            mainVillage.SetExit("north", ancientForest);
            ancientForest.SetExit("south", mainVillage);
            ancientForest.SetExit("north", crystalLake);
            crystalLake.SetExit("south", ancientForest);
            crystalLake.SetExit("north", elderCavern);
            elderCavern.SetExit("south", crystalLake);
            crystalLake.SetExit("east", crystalLake); // To allow resting and dialogue
        }
    }
}
