using System;

public class Character
{
    public string CharacterName { get; set; }
    public float Health { get; set; }
    public Item Weapon { get; set; }
    public Item Potion { get; set; }

    public Character(string name, float health, Item weapon, Item potion)
    {
        CharacterName = name;
        Health = health;
        Weapon = weapon;
        Potion = potion;
    }

    public void Move(string direction)
    {
        Console.WriteLine($"{CharacterName} moves {direction}.");
    }

    public void SetHealth(float health)
    {
        Health = health;
    }

    public override string ToString()
    {
        return $"Name: {CharacterName}, Health: {Health}, Weapon: {Weapon.Name}, Potion: {Potion.Name}";
    }
}
