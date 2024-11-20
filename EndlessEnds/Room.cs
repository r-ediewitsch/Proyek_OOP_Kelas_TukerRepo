public class Room
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Dictionary<string, Room> Exits { get; set; }

    public Room(string name, string description)
    {
        Name = name;
        Description = description;
        Exits = new Dictionary<string, Room>();
    }

    public void SetExit(string direction, Room room)
    {
        Exits[direction] = room;
    }

    public Room GetExit(string direction)
    {
        Exits.TryGetValue(direction, out Room nextRoom);
        return nextRoom;
    }

    public override string ToString()
    {
        return $"{Name}: {Description}";
    }
}

