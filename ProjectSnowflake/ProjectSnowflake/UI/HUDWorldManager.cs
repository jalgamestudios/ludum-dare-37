using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectSnowflake.Camera;
using ProjectSnowflake.Entities;
using ProjectSnowflake.Rendering;
using ProjectSnowflake.Timing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.UI
{
    class HUDWorldManager
    {
        #region Variables

        public static bool takeSweetsEnabled {
            get { return takeSweetsEnabledTimed > Time.totalSeconds - 0.25f; }
            set { if (value) takeSweetsEnabledTimed = Time.totalSeconds; } }
        private static float takeSweetsEnabledTimed { get; set; }
        static Texture2D takeSweetsFloater { get; set; }

        #endregion


        #region Functions

        public static void init()
        {
            takeSweetsEnabled = true;
            takeSweetsFloater = RenderingManager.contentManager.Load<Texture2D>("ui/take-sweets-floater");
        }

        public static void update()
        {
        }

        public static void draw()
        {
            if (takeSweetsEnabled)
            {
                RenderingManager.spriteBatch.Draw(takeSweetsFloater,
                    CameraManager.getScreenPosition(GameEntityCreator.playerEntity.center + new Vector2(-1, -1.5f), new Vector2(6, 1)),
                    Color.White);
            }
        }

        #endregion
    }
}
