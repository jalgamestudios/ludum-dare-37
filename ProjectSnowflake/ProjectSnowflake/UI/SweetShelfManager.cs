using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectSnowflake.Input;
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
    static class SweetShelfManager
    {
        #region Variables

        public static bool visible { get; set; }
        static Texture2D sweetsShelfImage { get; set; }

        static int currentIndexPressed { get; set; }
        static float timePressed { get; set; }

        #endregion


        #region Functions

        public static void init()
        {
            currentIndexPressed = -1;
            timePressed = 0;
            visible = false;
            sweetsShelfImage = RenderingManager.contentManager.Load<Texture2D>("ui/sweets-shelf");
            SweetsShelf.init();
        }

        public static void update()
        {
            if (InputManager.thisFrame.keyboardState.IsKeyDown(getKey(currentIndexPressed)))
                timePressed += Time.gameElapsedSeconds;
            else
            {
                timePressed = 0;
                for (int i = 0; i < 9; i++)
                {
                    if (InputManager.thisFrame.keyboardState.IsKeyDown(getKey(i)))
                    {
                        currentIndexPressed = i;
                        timePressed = Time.gameElapsedSeconds;
                        break;
                    }
                }
            }
            if (timePressed >= 1)
            {
                if (SweetsShelf.sweetGrids[currentIndexPressed].sweets.Count > 0)
                {
                    if (PlayerInventory.inventory.addSweet(SweetsShelf.sweetGrids[currentIndexPressed].sweets[0].type))
                        SweetsShelf.sweetGrids[currentIndexPressed].sweets.RemoveAt(0);
                }
                timePressed = -0.5f;
            }
        }

        private static Keys getKey(int index)
        {
            switch (index)
            {
                case 0: return Keys.D1;
                case 1: return Keys.D2;
                case 2: return Keys.D3;
                case 3: return Keys.D4;
                case 4: return Keys.D5;
                case 5: return Keys.D6;
                case 6: return Keys.D7;
                case 7: return Keys.D8;
                case 8: return Keys.D9;
            }
            return Keys.None;
        }

        public static void draw()
        {
            if (visible)
            {
                RenderingManager.spriteBatch.Draw(sweetsShelfImage,
                    new Rectangle(35, 0, 250, 150),
                    Color.White);

                SweetsShelf.draw();

                if (timePressed > 0)
                {
                    RenderingManager.spriteBatch.Draw(ProgressIndicator.progressTexture,
                        new Rectangle(SweetsShelf.sweetGridPosition(currentIndexPressed) + new Point(12, 24), new Point(16, 16)),
                        ProgressIndicator.getSourceRectangle(timePressed),
                        Color.White);
                }
            }
        }

        #endregion
    }
}
