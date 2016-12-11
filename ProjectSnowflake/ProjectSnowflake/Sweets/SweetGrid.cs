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

        public void addSweet(SweetType sweet)
        {
            if (sweets.Count == 0)
                sweets.Add(new Sweet(sweet, new Point(0, 0)));
            //else
            //{

            //}
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
