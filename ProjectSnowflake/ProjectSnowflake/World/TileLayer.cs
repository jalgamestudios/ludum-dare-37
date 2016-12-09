using Microsoft.Xna.Framework;
using ProjectSnowflake.Camera;
using ProjectSnowflake.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.World
{
    class TileLayer
    {
        #region Variables

        public int width { get { return tiles.GetLength(0); } }
        public int height { get { return tiles.GetLength(0); } }
        public Tile[,] tiles { get; set; }

        #endregion


        #region Constructors

        public TileLayer(int width, int height)
        {
            this.tiles = new Tile[width, height];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < width; j++)
                    tiles[i, j] = new Tile(0);
        }

        #endregion


        #region Functions

        public void draw()
        {
            for (int x = 0; x < width; x++)
                for (int y = 0; y < width; y++)
                    RenderingManager.spriteBatch.Draw(
                        tiles[x, y].definition.texture,
                        CameraManager.getScreenPosition(new Vector2(x, y), new Vector2(1, 1)),
                        Color.White);
        }

        #endregion
    }
}
