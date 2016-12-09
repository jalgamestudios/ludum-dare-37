using Microsoft.Xna.Framework.Graphics;
using ProjectSnowflake.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.World
{
    static class WorldManager
    {
        #region Variables

        public static List<TileDefinition> tileDefinitions { get; set; }

        public static List<TileLayer> layers { get; set; }

        #endregion


        #region Functions

        public static void init()
        {
            tileDefinitions = new List<TileDefinition>();
            tileDefinitions.Add(new TileDefinition(RenderingManager.contentManager.Load<Texture2D>("tiles/floor/wooden-boards"), true));

            layers = new List<TileLayer>();
            layers.Add(new TileLayer(16, 16));
        }

        public static void update()
        {

        }

        public static void draw()
        {
            foreach (var layer in layers)
                layer.draw();
        }

        #endregion
    }
}
