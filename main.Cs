using System;

namespace EndlessEnds
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Welcome to Endless Ends ===");
            Console.WriteLine("Enter your character name: ");
            string playerName = Console.ReadLine();

            // Inisialisasi karakter utama
            Character player = new Character(playerName, 100, "Rusty Sword", "Basic Potion");

            // Inisialisasi UI game
            GameUI gameUI = new GameUI(player);

            // Memulai game
            gameUI.Start();
        }
    }
}
