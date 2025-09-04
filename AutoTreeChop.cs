using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.TerrainFeatures;
using Microsoft.Xna.Framework;

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
            var farm = Game1.getFarm();

            foreach (var pair in farm.terrainFeatures.Pairs)
            {
                if (pair.Value is Tree tree)
                {
                    // Kiểm tra nếu cây trưởng thành
                    if (tree.growthStage.Value >= 5)
                    {
                        tree.performUseToolAction(new Axe(), farm, pair.Key);
                        Monitor.Log($"Chặt cây tại {pair.Key}", LogLevel.Info);
                    }
                }
            }
        }
    }
}
