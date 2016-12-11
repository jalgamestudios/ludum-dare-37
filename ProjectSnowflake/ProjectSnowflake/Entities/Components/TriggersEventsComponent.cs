using Microsoft.Xna.Framework;
using ProjectSnowflake.Timing;
using ProjectSnowflake.UI;
using ProjectSnowflake.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.Entities.Components
{
    class TriggersEventsComponent : IComponent
    {
        #region Functions

        public void update(Entity entity)
        {
            int layerIndex = Time.frameCount % WorldManager.layers.Count;
            TileLayer layer = WorldManager.layers[layerIndex];
            for (int i = Math.Max(0, (int)entity.position.X - 12); i < Math.Min(layer.width, (int)entity.position.X + 12); i++)
            {
                for (int j = Math.Max(0, (int)entity.position.Y - 12); j < Math.Min(layer.height, (int)entity.position.Y + 12); j++)
                {
                    if (layer.tiles[i, j].definition.events.Count > 0)
                    {
                        Vector2 tileCenter = new Vector2(i + 0.5f, j + 0.5f);
                        Vector2 playerCenter = entity.position + entity.colliderSize / 2;
                        float distance = (tileCenter - playerCenter).Length();
                        foreach (var tileEvent in layer.tiles[i, j].definition.events)
                            if (tileEvent.triggerDistance >= distance)
                                triggerEvent(tileEvent.code);
                    }
                }
            }
        }

        public void draw(Entity entity)
        {
        }

        public void triggerEvent(string code)
        {
            switch (code)
            {
                case "CandyHint":  HUDWorldManager.takeSweetsEnabled = true; break;
            }
        }

        #endregion
    }
}
