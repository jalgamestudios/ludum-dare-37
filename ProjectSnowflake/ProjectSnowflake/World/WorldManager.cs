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
            loadTileDefinitions(); tileDefinitions.Add(new TileDefinition(RenderingManager.contentManager.Load<Texture2D>("tiles/floor/wooden-boards"), true));

            layers = new List<TileLayer>();

            loadLevel("content/maps/room-1.tmx");
        }

        private static void loadTileDefinitions()
        {
            Texture2D tiles = RenderingManager.contentManager.Load<Texture2D>("tiles/spritesheet");
            tileDefinitions = new List<TileDefinition>();
            tileDefinitions.Add(new TileDefinition(false));
            for (int j = 0; j < 32; j++)
                for (int i = 0; i < 32; i++)
                    tileDefinitions.Add(new TileDefinition(tiles, true) { sourceRectangle = new Rectangle(i * 16, j * 16, 16, 16) });
            XElement tileDefinitionsRoot = XDocument.Load("content/tiles/definitions.xml").Root;
            foreach (var tileElement in tileDefinitionsRoot.Elements("Defintion"))
            {
                int x = int.Parse(tileElement.Attribute("X").Value);
                int y = int.Parse(tileElement.Attribute("Y").Value);
                TileDefinition definition = new TileDefinition(true);
                definition.texture = tileDefinitions[x + y * 32 + 1].texture;
                definition.sourceRectangle = tileDefinitions[x + y * 32 + 1].sourceRectangle;
                if (tileElement.Attribute("Walkable") != null)
                    definition.walkable = tileElement.Attribute("Walkable").Value == "True";
                if (tileElement.Element("Events") != null)
                {
                    foreach (var eventElement in tileElement.Element("Events").Elements("TileEvent"))
                    {
                        TileEvent tileEvent = new TileEvent(0, "");
                        tileEvent.triggerDistance = float.Parse(eventElement.Attribute("TriggerDistance").Value, CultureInfo.InvariantCulture);
                        tileEvent.code = eventElement.Attribute("Code").Value;
                        definition.events.Add(tileEvent);
                    }
                }
                tileDefinitions[x + y * 32 + 1] = definition;
            }
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
            int width = (int)float.Parse(fileElement.Attribute("width").Value, CultureInfo.InvariantCulture);
            int height = (int)float.Parse(fileElement.Attribute("height").Value, CultureInfo.InvariantCulture);
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

        public static bool collides(Vector2 position, Vector2 size)
        {
            int factor = 16;
            Rectangle colliderRectangle = new Rectangle(
                (int)(position.X * factor), (int)(position.Y * factor),
                (int)(size.X * factor), (int)(size.Y * factor));
            foreach (var layer in layers)
            {
                for (int x = Math.Max(0, (int)position.X - 2); x < Math.Min(layer.width, (int)(position.X + size.X + 2)); x++)
                {
                    for (int y = Math.Max(0, (int)position.Y - 2); y < Math.Min(layer.height, (int)(position.Y + size.Y + 2)); y++)
                    {
                        if (!layer.tiles[x, y].definition.walkable)
                        {
                            float colliderSize = 0.6f;
                            Rectangle tileRectangle = new Rectangle(
                                (int)((x + (0.5f - colliderSize / 2)) * factor), (int)((y + (0.5f - colliderSize / 2)) * factor),
                                (int)(factor * colliderSize), (int)(factor * colliderSize));
                            if (tileRectangle.Intersects(colliderRectangle))
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        #endregion
    }
}
