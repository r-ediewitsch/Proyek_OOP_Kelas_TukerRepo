public class Item
{
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public float Damage { get; set; }

    public Item(string name, ItemType type, float damage)
    {
        Name = name;
        Type = type;
        Damage = damage;
    }

    public override string ToString()
    {
        return $"{Name} ({Type}, Damage: {Damage})";
    }
}

public enum ItemType
{
    Weapon,
    Potion
}
