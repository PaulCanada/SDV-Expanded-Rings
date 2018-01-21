using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace ExpandedRings
{
    class ModEntry : Mod
    {
        private ModConfig config;

        /**
         * Actions to perform once mod has loaded.
         **/
        public override void Entry(IModHelper helper)
        {
            this.config = (ModConfig)helper.ReadConfig<ModConfig>();
            GameEvents.OneSecondTick += GameEvents_OnSecondUpdate;

        }

        /**
         * Actions to perform every second in game.
         **/ 
        public void GameEvents_OnSecondUpdate(object sender, EventArgs args)
        {
            RegenRing.healthRegen(this.config.regenAmount, Game1.player);
        }


    }
}
