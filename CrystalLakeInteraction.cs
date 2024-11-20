using System;

namespace EndlessEnds
{
    public class CrystalLakeInteraction
    {
        private Character player;
        private Battle battle;
        private bool hasMetCompanion = false;

        public CrystalLakeInteraction(Character player, Battle battle)
        {
            this.player = player;
            this.battle = battle;
        }

        public void Handle(string direction, string currentRoom)
        {
            if (currentRoom == "Crystal Lake")
            {
                if (!hasMetCompanion)
                {
                    CompanionAppears();
                    hasMetCompanion = true;
                }
                else if (currentRoom == "Crystal Lake" && direction == "north")
                {
                    StartDragonBattle();
                }
                else if (direction == "east")
                {
                    RestAndHeal();
                }
            }
        }

        private void CompanionAppears()
        {
            Console.WriteLine("\nAs you step closer to the shimmering water of Crystal Lake, you hear a soft rustle.");
            Console.WriteLine("A figure steps out from behind a crystal formation, revealing herself to be a hooded girl.");
            Console.WriteLine("\"Greetings, traveler,\" she says with a gentle smile. \"I am Kayo,I happen to be passing by.\"");
            Console.WriteLine("She looks at you with piercing eyes, \"Hm.. Hm.. I sense a great journey ahead of you. Allow me to accompany you,");
            Console.WriteLine("for the challenges you face are too great to conquer alone.\"");
            Console.WriteLine("With Kayo by your side, you feel a newfound sense of strength and determination.");
        }
        private void StartDragonBattle()
        {
            Console.WriteLine("You have reached the northern part of Crystal Lake and encountered the Sapphire Dragon!");
            // Start battle with Sapphire Dragon
            Enemy dragon = new Enemy("Sapphire Dragon", 300, 50);
            battle.StartCombat(player, dragon);
        }

        private void RestAndHeal()
        {
            Console.WriteLine("You see a comfortable place to rest. You take a rest and heal for 30% of max health.");
            player.Health += player.Health * 0.3f;
            Console.WriteLine($"Your health is now {player.Health}.");

            Console.WriteLine("\nKayo: \"Resting here brings back memories...\"");
            Console.WriteLine("Kayo: \"I've protected this lake for many years, and it has a calming effect on me.\"");
            Console.WriteLine("Kayo: \"Let's take this moment to gather our strength for the battles ahead.\"");
        }
    }
}
