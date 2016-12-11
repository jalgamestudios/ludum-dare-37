using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectSnowflake.Rendering;
using ProjectSnowflake.Sweets;
using ProjectSnowflake.Timing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.UI
{
    static class BottomBarManager
    {
        #region Variables

        static Texture2D underlay { get; set; }
        static Texture2D overlay { get; set; }

        static Texture2D energyActive { get; set; }

        static int minXValue { get { return 40; } }

        #endregion


        #region Functions

        public static void init()
        {
            underlay = RenderingManager.contentManager.Load<Texture2D>("ui/bottom-bar-underlay");
            overlay = RenderingManager.contentManager.Load<Texture2D>("ui/bottom-bar-overlay");
            energyActive = RenderingManager.contentManager.Load<Texture2D>("ui/energy-bar-active");

            PlayerInventory.init();
        }

        public static void update()
        {
            PlayerInventory.update();
        }

        public static void draw()
        {
            RenderingManager.spriteBatch.Draw(underlay,
                new Rectangle(minXValue, RenderingManager.screenDimensions.Y - 32, 240, 32),
                Color.White);

            float energyValue = (float)Math.Sin(Time.totalGameSeconds) * 0.5f + 0.5f;
            int energyPixelValue = (int)(energyValue * 90);

            RenderingManager.spriteBatch.Draw(energyActive,
                new Rectangle(minXValue, RenderingManager.screenDimensions.Y - 16, energyPixelValue, 16),
                new Rectangle(0, 0, energyPixelValue, 16),
                Color.White);

            RenderingManager.spriteBatch.Draw(overlay, 
                new Rectangle(minXValue, RenderingManager.screenDimensions.Y - 32, 240, 32),
                Color.White);

            PlayerInventory.inventory.draw(new Point(minXValue + 88, RenderingManager.screenDimensions.Y - 28));
        }

        #endregion
    }
}
