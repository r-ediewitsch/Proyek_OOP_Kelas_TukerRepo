using System.ComponentModel;

public class Battle
{
    public void StartCombat(Character player, Enemy enemy, Character companion = null)
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
                    Console.WriteLine("Magic functionality here...");
                    
                    break;
                case "3":
                    Console.WriteLine("Defend functionality here...");
                    break;
                default:
                    Console.WriteLine("Invalid action.");
                    continue;
            }

            if (enemy.Health > 0)
            {
                Console.WriteLine($"{enemy.Name} attacks!");
                enemy.Attack(player);
            }

            // Companion attack
            if (companion != null && enemy.Health > 0)
            {
                Console.WriteLine($"{companion.CharacterName} attacks!");
                companion.Attack(enemy);
            }
        }

        if (enemy.Health <= 0)
        {
            Console.WriteLine("Enemy Defeated");
        }
        else
        {
            Console.WriteLine("You have been slain.");
            Console.WriteLine("Game Over");
            Environment.Exit(0);
        }
    }
}
