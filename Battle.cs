public class Battle
{
    public void StartCombat(Player player, Enemy enemy)
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
                    if (player.Magic > 0)
                    {
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
                    }
                    else
                    {
                        Console.WriteLine("You are out of magic.");
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
