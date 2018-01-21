using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using StardewValley;
using StardewValley.Monsters;
using StardewValley.Objects;
using StardewValley.TerrainFeatures;

using System;
using System.Collections.Generic;

namespace ExpandedRings
{
    class RegenRing : Ring
    {

        /**
         * Logic to handle health regeneration.
         **/
        public static void healthRegen(float amount, StardewValley.Farmer player)
        {
            if (player.leftRing.name.Equals("Ring of Regen") || player.rightRing.name.Equals("Ring of Regen"))
            {
                if (player.health < player.maxHealth)
                {
                    player.health += (int)(player.maxHealth * amount);

                    if (player.health >= player.maxHealth)
                    {
                        player.health = player.maxHealth;
                    }
                }

            }
        }



    }
}
