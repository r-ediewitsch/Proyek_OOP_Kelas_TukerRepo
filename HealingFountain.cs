public class HealingFountain
{
    public Character Player {get; private set;}

    public HealingFountain(Character player)
    {
        this.Player = player;
    }

    public void Encounter()
    {
        Console.WriteLine("After some time wandering, you found a fountain.");
        Console.WriteLine("\nPeople said that the water could heal you if you use magic.");
        Console.WriteLine("\nChoose your action:");
        Console.WriteLine("1. Interact");
        Console.WriteLine("2. Ignore");

        string action = Console.ReadLine();

        switch(action)
        {
            case "1":
                Interact();
                break;
            case "2":
                Console.WriteLine("You continue to wander the room.");
                break;
            default:
                break;
        }
    }

    public void Interact()
    {
        Console.WriteLine("You casted magic to the water and drink the water.");
        Player.Health += 100;
        Player.UseMagic();
        Console.WriteLine("You’re feeling rejuvenated (+100 HP)");
    }
}