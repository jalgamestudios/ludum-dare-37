using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectSnowflake.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

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
            Texture2D tiles = RenderingManager.contentManager.Load<Texture2D>("tiles/spritesheet");
            tileDefinitions = new List<TileDefinition>();
            tileDefinitions.Add(new TileDefinition(false));
            for (int j = 0; j < 32; j++)
                for (int i = 0; i < 32; i++)
                    tileDefinitions.Add(new TileDefinition(tiles, true) { sourceRectangle = new Rectangle(i * 16, j * 16, 16, 16) });
            tileDefinitions.Add(new TileDefinition(RenderingManager.contentManager.Load<Texture2D>("tiles/floor/wooden-boards"), true));

            layers = new List<TileLayer>();

            loadLevel("content/maps/room-1.tmx");
        }

        public static void update()
        {

        }

        public static void draw()
        {
            foreach (var layer in layers)
                layer.draw();
        }

        public static void loadLevel(string levelFile)
        {
            layers.Clear();
            XElement fileElement = XDocument.Load(levelFile).Root;
            int width = (int)float.Parse(fileElement.Attribute("width").Value);
            int height = (int)float.Parse(fileElement.Attribute("height").Value);
            List<XElement> layerElements = fileElement.Elements("layer").ToList();
            for (int layerIndex = 0; layerIndex < layerElements.Count; layerIndex++)
            {
                XElement layerElement = layerElements[layerIndex];
                TileLayer layer = new TileLayer(width, height);
                //List<XElement> tiles = layerElement.Element("data").Elements("tile").ToList();

                string[] tiles = layerElement.Element("data").Value.Split(',');
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        //XElement tileElement = tiles[x + y * width];
                        long unsignedGid = long.Parse(tiles[x + y * width], CultureInfo.InvariantCulture);
                        string gidString = Convert.ToString(unsignedGid, 2).PadLeft(32, '0');
                        #region rotation
                        //In tmx files, the first 3 bits indicate if a tile has been flipped horizontally, vertically and / or diagonally
                        TileRotation rotation = TileRotation.None;
                        SpriteEffects flipping = SpriteEffects.None;
                        if (gidString[0] == '1' && gidString[1] == '0' && gidString[2] == '1')
                            rotation = TileRotation.QuarterRotation;
                        else if (gidString[1] == '1' && gidString[1] == '1' && gidString[2] == '0')
                            rotation = TileRotation.HalfRotation;
                        else if (gidString[0] == '0' && gidString[1] == '1' && gidString[2] == '1')
                            rotation = TileRotation.ThreeQuarterRotation;
                        else if (gidString[0] == '0' && gidString[1] == '0' && gidString[2] == '0')
                            rotation = TileRotation.None;
                        else if (gidString[0] == '1' && gidString[1] == '0' && gidString[2] == '0')
                            flipping = SpriteEffects.FlipHorizontally;

                        int gid = 0;
                        for (int i = 3; i < gidString.Length; i++)
                        {
                            int powerOfTwo = gidString.Length - i - 1;
                            if (gidString[i] == '1')
                                gid += (int)Math.Pow(2, powerOfTwo);
                        }
                        #endregion
                        layer.tiles[x, y] = new Tile(gid) { rotation = rotation, flipMode = flipping }; // = tileDefinitions[gid].getTileAt(gid, new Coordinate(x, y, layerIndex), rotation, flipping);
                    }
                }
                //if (layerElement.Element("properties") != null)
                //{
                //    List<XElement> properties = layerElement.Element("properties").Elements("property").ToList();
                //    for (int i = 0; i < properties.Count; i++)
                //    {
                //        if (properties[i].Attribute("name").Value == "Collision")
                //            if (properties[i].Attribute("value").Value == "false")
                //                layer.collision = false;
                //    }
                //}
                layers.Add(layer);
            }
        }

        #endregion
    }
}
