using System;
using System.Collections.Generic;

namespace EndlessEnds
{
    public class CrystalLakeInteraction
    {
        private Character player;
        private Battle battle;
        public List<Item> inventory;

        public CrystalLakeInteraction(Character player, Battle battle, List<Item> inventory)
        {
            this.player = player;
            this.battle = battle;
            this.inventory = inventory;
        }

        public void Handle(string direction, string currentRoom, bool hasMetCompanion)
        {            
            if (currentRoom == "Near Crystal Lake" && hasMetCompanion)
            {
                if (direction == "east")
                {
                    getRandomItem();
                    RestAndHeal();
                }
                else if (direction == "north")
                {
                    Console.WriteLine("You move further towards the end of Crystal Lake.");
                }
            }
            else if (currentRoom == "End of Crystal Lake" && hasMetCompanion)
            {
                if (direction == "north")
                {
                    StartDragonBattle();
                }
                else if (direction == "west")
                {
                    StartSecretNinjaBattle();
                }
            }
            else if (hasMetCompanion && (currentRoom == "Bandit Hideout" || currentRoom == "Bandit Lair"))
            {
                StartBanditBattle();
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

        private void StartBanditBattle()
        {
            Console.WriteLine("A bandit attempts to rob you!");
            // Start battle with Bandits
            Enemy bandit = new Enemy("Bandit 1", 50, 10);
            battle.StartCombat(player, bandit);
        }

        private void StartSecretNinjaBattle()
        {
            Console.WriteLine("A crazy ninja who has been hiding in the shadows jumps out and attacks you! He wants to take your soul!");
            // Start battle with Secret Ninja
            Enemy secretNinja = new Enemy("Secret Ninja", 1000, 500);
            battle.StartCombat(player, secretNinja);
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

        private void getRandomItem()
        {
            Random random = new Random();
            int itemIndex = random.Next(0, 3);
            Item? item = null;
            switch (itemIndex)
            {
                case 0:
                    item = new Item("Defense Potion", ItemType.Potion, 0);
                    break;
                case 1:
                    item = new Item("Old Scroll", ItemType.Scroll, 0);
                    break;
                case 2:
                    item = new Item("White Key", ItemType.Key, 0);
                    break;
            }
            if (item != null)
            {
                inventory.Add(item);
            }
            Console.WriteLine($"\nYou found a {item?.Name}!\n");
        }
    }
}
