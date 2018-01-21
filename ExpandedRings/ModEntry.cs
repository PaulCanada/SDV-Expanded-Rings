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
        }

        /**
         * Actions to perform every second in game.
         **/ 
        public void GameEvents_OnSecondUpdate(object sender, EventArgs args)
        {
            
        }



    }
}
