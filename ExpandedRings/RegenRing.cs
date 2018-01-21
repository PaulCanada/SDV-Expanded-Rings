using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PyTK.CustomElementHandler;
using StardewValley;
using StardewValley.Objects;

using System;
using System.Collections.Generic;

namespace ExpandedRings
{
    class RegenRing : Ring, ISaveElement
    {

        public static Texture2D ringTexture;

        public RegenRing()
    :       base(517)
        {
            build();
        }

        public override Item getOne()
        {
            return this;
        }

        public override string getDescription()
        {
            return description;
        }

        public override string DisplayName {
            get => name;
            set => displayName = value;
        }

        public void build()
        {
            name = "Ring of Regeneration";
            displayName = "Ring of Regeneration";
            description = "You feel healthier when wearing this ring.";
        }

        public Dictionary<string, string> getAdditionalSaveData()
        {
            Dictionary<string, string> savedata = new Dictionary<string, string>();
            savedata.Add("name", name);
            return savedata;
        }

        public object getReplacement()
        {
            if (Game1.player.leftRing == this || Game1.player.rightRing == this)
            {
                return new Ring(517);
            } else
            {
                return new Chest(true);
            }
        }

        public void rebuild(Dictionary<string, string> additionalSaveData, object replacement)
        {
            string[] strArray = Game1.objectInformation[517].Split('/');
            category = -96;
            name = strArray[0];
            price = Convert.ToInt32(strArray[1]);
            indexInTileSheet = 517;
            uniqueID = 3001;
            ModEntry.helper.Reflection.GetMethod(this, "loadDisplayFields").Invoke();
            build();
        }


    }
}
