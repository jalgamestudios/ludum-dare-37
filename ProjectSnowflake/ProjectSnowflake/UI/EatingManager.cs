using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ProjectSnowflake.Camera;
using ProjectSnowflake.Entities;
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
    static class EatingManager
    {
        #region Variables

        public static float eatingTimePassed { get; set; }

        public static float timeRequired { get { return 2.5f; } }

        #endregion


        #region Functions

        public static void init()
        {
            eatingTimePassed = 0;
        }

        public static void update()
        {
            if (InputManager.thisFrame.keyboardState.IsKeyDown(Keys.E)
                && PlayerInventory.inventory.sweets.Count > 0)
            {
                eatingTimePassed += Time.gameElapsedSeconds;
            }
            else
            {
                eatingTimePassed = 0;
            }

            if (eatingTimePassed >= timeRequired)
            {
                PlayerInventory.inventory.sweets.RemoveAt(0);
                eatingTimePassed = -0.5f;
            }
        }

        public static void draw()
        {
            if (eatingTimePassed > 0)
            {
                RenderingManager.spriteBatch.Draw(ProgressIndicator.progressTexture,
                    CameraManager.getScreenPosition(GameEntityCreator.playerEntity.center - new Vector2(0.5f, 0.5f), new Vector2(1, 1)),
                    ProgressIndicator.getSourceRectangle(eatingTimePassed / timeRequired),
                    Color.White);
            }
        }

        #endregion
    }
}
