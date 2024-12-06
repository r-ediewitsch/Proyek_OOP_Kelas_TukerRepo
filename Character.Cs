using System;

public class Character
{
    public string CharacterName { get; set; }
    public float Health { get; set; }
    public Item Weapon { get; set; }
    public Item Potion { get; set; }
    
    private int magicUses = 4; // Track number of times magic can be used per battle
    private bool isDefending = false;
    private bool hasMysticCoating = false;

    public Character(string name, float health, Item weapon, Item potion)
    {
        CharacterName = name;
        Health = health;
        Weapon = weapon;
        Potion = potion;
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
        if (magicUses > 0)
        {
            switch (choice)
            {
                case 1:
                    ArcaneBlast(enemy);
                    break;
                case 2:
                    MysticCoating();
                    break;
                case 3:
                    Rejuvenate();
                    break;
                default:
                    Console.WriteLine("Invalid magic choice.");
                    break;
            }
            magicUses--;
            Console.WriteLine($"Magic can be used {magicUses} more times in this battle.");
        }
        else
        {
            Console.WriteLine("You have used all your magic opportunities for this battle.");
        }
    }

    private void ArcaneBlast(Enemy enemy)
    {
        Console.WriteLine($"{CharacterName} casts Arcane Blast on {enemy.Name} for 80 damage.");
        enemy.Health -= 80;
        Console.WriteLine($"{enemy.Name} has {enemy.Health} health left.");
    }

    private void MysticCoating()
    {
        Console.WriteLine($"{CharacterName} casts Mystic Coating, reducing damage taken by 70% for the next turn.");
        hasMysticCoating = true;
    }

    private void Rejuvenate()
    {
        Console.WriteLine($"{CharacterName} casts Rejuvenate, restoring 70 health.");
        Health += 70;
        Console.WriteLine($"{CharacterName} has {Health} health now.");
    }

    public void Defend()
    {
        Console.WriteLine($"{CharacterName} defends, reducing damage taken by 30% for the next turn.");
        isDefending = true;
    }

    public void TakeDamage(float damage)
    {
        if (hasMysticCoating)
        {
            damage *= 0.3f; // 70% reduction
            hasMysticCoating = false; // Reset after use
        }
        else if (isDefending)
        {
            damage *= 0.7f; // 30% reduction
            isDefending = false; // Reset after use
        }

        Health -= damage;
        Console.WriteLine($"{CharacterName} takes {damage} damage and now has {Health} health left.");
    }

    public void ResetMagicUses()
    {
        magicUses = 4; // Reset the magic uses count
    }

    public void UseMagic()
    {
        magicUses--;
    }
}
