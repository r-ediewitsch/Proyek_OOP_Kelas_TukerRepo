using System;

namespace EndlessEnds
{
    public class main
    {
        public static void Main(string[] args)
        {
            // Create a character
            Character player = new Character("Hero", 100, new Item("Basic Sword", ItemType.Weapon, 10), new Item("Health Potion", ItemType.Potion, 0));

            // Initialize the game UI with the player character
            GameUI game = new GameUI(player);

            // Start the game
            game.Start();
        }
    }
}
