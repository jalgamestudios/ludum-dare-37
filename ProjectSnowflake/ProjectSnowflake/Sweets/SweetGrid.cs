using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectSnowflake.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.Sweets
{
    class SweetGrid
    {
        #region Variables

        public List<Sweet> sweets { get; set; }
        public Point dimensions { get; set; }

        public static Texture2D sweetsSpritesheet { get; set; }

        #endregion


        #region Constructors

        public SweetGrid()
        {
            sweets = new List<Sweet>();
            dimensions = new Point(2, 2);
            if (sweetsSpritesheet == null)
                sweetsSpritesheet = RenderingManager.contentManager.Load<Texture2D>("sweets/spritesheet");
        }

        #endregion


        #region Functions

        public bool addSweet(SweetType sweet)
        {
            if (sweet.getDimensions().Y == 1)
            {
                int x = dimensions.X - 1;
                while (x >= 0)
                {
                    int y = 0;
                    while (y < dimensions.Y)
                    {
                        Rectangle sweetRect = new Rectangle(x, y, sweet.getDimensions().X, sweet.getDimensions().Y);
                        bool intersects = false;
                        foreach (var otherSweet in sweets)
                            if (sweetRect.Intersects(new Rectangle(otherSweet.position, otherSweet.type.getDimensions())))
                                intersects = true;

                        if (!intersects)
                        {
                            sweets.Add(new Sweet(sweet, new Point(x, y)));
                            return true;
                        }
                        y++;
                    }
                    x--;
                }
            }
            else
            {
                int x = 0;
                while (x < dimensions.X)
                {
                    Rectangle sweetRect = new Rectangle(x, 0, sweet.getDimensions().X, sweet.getDimensions().Y);
                    bool intersects = false;
                    foreach (var otherSweet in sweets)
                        if (sweetRect.Intersects(new Rectangle(otherSweet.position, otherSweet.type.getDimensions())))
                            intersects = true;

                    if (!intersects)
                    {
                        sweets.Add(new Sweet(sweet, new Point(x, 0)));
                        return true;
                    }
                    x++;
                }
            }
            return false;
        }

        public void draw(Point position)
        {
            foreach (var sweet in sweets)
            {
                RenderingManager.spriteBatch.Draw(sweetsSpritesheet,
                    new Rectangle(position + sweet.position * new Point(16, 16), sweet.type.getDimensions() * new Point(16, 16)),
                    sweet.type.getSourceRectangle(),
                    Color.White);
            }
        }

        #endregion
    }
}
