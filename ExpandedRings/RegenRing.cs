using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PyTK.CustomElementHandler;
using StardewValley;
using StardewValley.Objects;

using System;
using System.Collections.Generic;

namespace ExpandedRings
{
    public class RegenRing : Ring, ISaveElement
    {

        public static Texture2D ringTexture;

        public RegenRing()
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

        public override void drawInMenu(SpriteBatch spriteBatch, Vector2 location, float scaleSize, float transparency, float layerDepth, bool drawStackNumber)
        {
            spriteBatch.Draw(ringTexture, location + new Vector2((float)(Game1.tileSize / 2), (float)(Game1.tileSize / 2)) * scaleSize, new Rectangle?(Game1.getSourceRectForStandardTileSheet(ringTexture, 0, 16, 16)), Color.White * transparency, 0.0f, new Vector2(8f, 8f) * scaleSize, scaleSize * (float)Game1.pixelZoom, SpriteEffects.None, layerDepth);
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

        public static void regenLogic(float amount)
        {
            if (Game1.player.health < Game1.player.maxHealth)
            {
                Game1.player.health += (int)(Game1.player.maxHealth * amount);

                if (Game1.player.health >= Game1.player.maxHealth)
                {
                    Game1.player.health = Game1.player.maxHealth;
                }

            }
        }


    }
}
