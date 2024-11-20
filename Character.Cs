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
        Console.WriteLine("Arah Gerak: ");
        // Move logic here
    }

    public void SetHealth(float health)
    {
        Health = health;
    }

    public void Attack(Enemy enemy)
    {
        Console.WriteLine($"{CharacterName} attacks {enemy.Name} with {Weapon.Name} for {Weapon.Damage} damage.");
        enemy.Health -= Weapon.Damage;
        Console.WriteLine($"{enemy.Name} has {enemy.Health} health left.");
    }

    public void UseMagic(int choice, Enemy enemy)
    {
        Console.WriteLine($"{CharacterName} uses magic against {enemy.Name}.");
        // Add magic logic here
    }

    public void Defend()
    {
        Console.WriteLine($"{CharacterName} defends.");
        // Add defend logic here
    }
}
