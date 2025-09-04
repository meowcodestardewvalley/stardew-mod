using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.TerrainFeatures;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace AutoTreeChop
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.DayStarted += OnDayStarted;
        }

        private void OnDayStarted(object sender, DayStartedEventArgs e)
        {
            foreach (GameLocation location in Game1.locations)
            {
                List<Vector2> toRemove = new List<Vector2>();

                foreach (var pair in location.terrainFeatures.Pairs)
                {
                    if (pair.Value is Tree tree && tree.growthStage.Value >= Tree.treeStage)
                    {
                        toRemove.Add(pair.Key);
                    }
                }

                foreach (var pos in toRemove)
                    location.terrainFeatures.Remove(pos);
            }

            Monitor.Log("Đã tự động chặt cây!", LogLevel.Info);
        }
    }
}
