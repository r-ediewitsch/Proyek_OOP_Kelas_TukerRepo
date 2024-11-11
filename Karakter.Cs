using system;

public class Character
{
    public string CharacterName { get; set; }
    public float Health { get; set; }
    public string weapon { get; set; }
    public string potion {get; set; }
    public Character(string name, float health, string weapon, string potion)
    {
        CharacterName = name;
        Health = health;
        weapon = weapon;
        potion = potion
    }

    public void Move(string direction)
    {
        Console.WriteLine("Arah Gerak: ");
        //ntar oper ke movement
    }

    void setHealth(float health)
    {
        Health = health;
    }
}