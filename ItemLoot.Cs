using system;
using system.collections.generic;

namespace ItemLoot
{

    public class Item
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }

        public Item(string name, ItemType type)
        {
            Name = name;
            Type = type;
        }
        
        public override string ToString()
        {
            return $"{Name} ({Type})";
        }
    }

    public enum ItemType
    {
        Weapon
        potion
    }
}