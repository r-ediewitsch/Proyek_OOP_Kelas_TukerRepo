using System;

public class Enemy
{
    public string Name { get; set; }
    public float Health { get; set; }
    public float Damage { get; set; }

    public Enemy(string name, float health, float damage)
    {
        Name = name;
        Health = health;
        Damage = damage;
    }

    public void Attack(Character player)
    {
        Console.WriteLine($"{Name} attacks {player.CharacterName} for {Damage} damage.");
        player.Health -= Damage;
        if (player.Health <= 0)
        {
            player.Health = 0;
        }
        Console.WriteLine($"{player.CharacterName} has {player.Health} health left.");
    }
}
