using System;

public class Item
{
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public string Effect { get; set; } // Efek item (misalnya, heal, damage)

    public Item(string name, ItemType type, string effect = "")
    {
        Name = name;
        Type = type;
        Effect = effect;
    }

    public override string ToString()
    {
        return $"{Name} ({Type}) - Effect: {Effect}";
    }
}

public enum ItemType
{
    Weapon,
    Potion
}
