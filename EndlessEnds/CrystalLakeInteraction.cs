using System;

namespace EndlessEnds
{
    public class CrystalLakeInteraction
    {
        private Character player;
        private Battle battle;

        public CrystalLakeInteraction(Character player, Battle battle)
        {
            this.player = player;
            this.battle = battle;
        }

        public void Handle(string direction, string currentRoom, bool hasMetCompanion)
        {
            if (currentRoom == "Near Crystal Lake" && hasMetCompanion)
            {
                if (direction == "east")
                {
                    RestAndHeal();
                }
                else if (direction == "north")
                {
                    Console.WriteLine("You move further towards the end of Crystal Lake.");
                }
            }
            else if (currentRoom == "End of Crystal Lake" && hasMetCompanion)
            {
                StartDragonBattle();
            }
        }

        public bool CompanionAppears()
        {
            Console.WriteLine("\nAs you step closer to the shimmering water of Crystal Lake, you hear a soft rustle.");
            Console.WriteLine("A figure steps out from behind a crystal formation, revealing herself to be a fox girl.");
            Console.WriteLine("\"Greetings, traveler,\" she says with a gentle smile. \"I am Kayo, guardian of this lake.\"");
            Console.WriteLine("She looks at you with piercing eyes, \"I sense a great journey ahead of you. Allow me to accompany you,");
            Console.WriteLine("for the challenges you face are too great to conquer alone.\"");
            Console.WriteLine("With Kayo by your side, you feel a newfound sense of strength and determination.");
            return true;
        }

        private void StartDragonBattle()
        {
            Console.WriteLine("You have reached the end of Crystal Lake and encountered the Sapphire Dragon!");
            // Start battle with Sapphire Dragon
            Enemy dragon = new Enemy("Sapphire Dragon", 300, 50);
            battle.StartCombat(player, dragon);
        }

        private void RestAndHeal()
        {
            Console.WriteLine("You see a comfortable place to rest. You take a rest and heal for 30% of max health.");
            player.Health += player.Health * 0.3f;
            player.ResetMagicUses(); // Reset magic uses when resting
            Console.WriteLine($"Your health is now {player.Health}.");

            Console.WriteLine("\nKayo: \"Resting here brings back memories...\"");
            Console.WriteLine("Kayo: \"I've protected this lake for many years, and it has a calming effect on me.\"");
            Console.WriteLine("Kayo: \"Let's take this moment to gather our strength for the battles ahead.\"");
        }
    }
}
