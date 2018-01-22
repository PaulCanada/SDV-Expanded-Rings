using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewModdingAPI;
using StardewModdingAPI.Events;

using StardewValley;
using StardewValley.Menus;
using System;
using PyTK.Extensions;
using PyTK.Types;

namespace ExpandedRings
{
    class ModEntry : Mod
    {
        private ModConfig config;
        public static IModHelper helper;

        /**
         * Actions to perform once mod has loaded.
         **/
        public override void Entry(IModHelper help)
        {
            helper = help;
            config = Helper.ReadConfig<ModConfig>();

            RegenRing.ringTexture = Helper.Content.Load<Texture2D>("assets/ring.png");
            new InventoryItem(new RegenRing(), this.config.regenRingPrice).addToNPCShop("Marnie");
            GameEvents.OneSecondTick += GameEvents_OnSecondUpdate;
            InputEvents.ButtonPressed += InputButtons_ButtonPressed;
        }

        private void InputButtons_ButtonPressed(object sender, EventArgsInput key)
        {
            if (Context.IsPlayerFree)
            {
                if (Game1.activeClickableMenu != null || Game1.CurrentEvent != null)
                {
                    return;
                }

                if (key.Button.ToString().Equals("B"))
                {
                    Game1.player.health -= 20;
                }
            }
        }

        /**
         * Actions to perform every second in game.
         **/
        public void GameEvents_OnSecondUpdate(object sender, EventArgs args)
        {
            if (Context.IsPlayerFree)
            {
                StardewValley.Farmer player = Game1.player;

                // If both of rings are not present, return
                if (player.leftRing == null && player.rightRing == null)
                {
                    return;
                }

                if ((player.leftRing != null && player.leftRing.name.Equals("Ring of Regeneration")) || (player.rightRing != null && player.rightRing.name.Equals("Ring of Regeneration")))
                {
                    RegenRing.regenLogic(this.config.regenAmount);
                }
            }

        }

    }
}
