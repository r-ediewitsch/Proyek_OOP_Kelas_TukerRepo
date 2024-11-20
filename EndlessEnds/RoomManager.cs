public class RoomManager
{
    public Room DreamWorld { get; private set; }
    public Room AncientForest { get; private set; }
    public Room MainVillage { get; private set; }
    public Room ElderCavern { get; private set; }
    public Room CrystalLakeEntrance { get; private set; }
    public Room CrystalLakeNear { get; private set; }
    public Room CrystalLakeEnd { get; private set; }
    public Room CrystalLakeRest { get; private set; } // New room for resting

    public void InitializeRooms()
    {
        DreamWorld = new Room("Dream World", "World full of clouds, fog as thick as dreams alike.");
        AncientForest = new Room("Ancient Forest", "A vast forest where the ancient monsters dwell.");
        MainVillage = new Room("Main Village", "Home village where I live.");
        ElderCavern = new Room("Elder Cavern", "Cavern that emanates darkness around it.");
        CrystalLakeEntrance = new Room("Crystal Lake Entrance", "Entrance to Crystal Lake.");
        CrystalLakeNear = new Room("Near Crystal Lake", "Near Crystal Lake, a beautiful and peaceful place.");
        CrystalLakeEnd = new Room("End of Crystal Lake", "End of Crystal Lake, where the battle with the dragon takes place.");
        CrystalLakeRest = new Room("Crystal Lake Rest Area", "A tranquil spot to rest and rejuvenate.");

        MainVillage.SetExit("north", AncientForest);
        AncientForest.SetExit("south", MainVillage);
        AncientForest.SetExit("north", CrystalLakeEntrance);
        CrystalLakeEntrance.SetExit("south", AncientForest);
        CrystalLakeEntrance.SetExit("north", CrystalLakeNear);
        CrystalLakeNear.SetExit("south", CrystalLakeEntrance);
        CrystalLakeNear.SetExit("north", CrystalLakeEnd);
        CrystalLakeNear.SetExit("east", CrystalLakeRest); // Adding east exit for resting
        CrystalLakeEnd.SetExit("south", CrystalLakeNear);
        CrystalLakeEnd.SetExit("north", ElderCavern);
        ElderCavern.SetExit("south", CrystalLakeEnd);
    }
}
