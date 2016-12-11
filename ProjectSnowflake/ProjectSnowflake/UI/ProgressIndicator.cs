using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectSnowflake.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.UI
{
    class ProgressIndicator
    {
        #region Variables

        public static Texture2D progressTexture { get; set; }

        #endregion


        #region Functions

        public static void init()
        {
            progressTexture = RenderingManager.contentManager.Load<Texture2D>("ui/progress-indicator");
        }

        public static Rectangle getSourceRectangle(float progress)
        {
            if (progress < 0.2f)
                return new Rectangle(0, 0, 16, 16);
            if (progress < 0.4f)
                return new Rectangle(16, 0, 16, 16);
            if (progress < 0.6f)
                return new Rectangle(32, 0, 16, 16);
            if (progress < 0.8f)
                return new Rectangle(48, 0, 16, 16);

            return new Rectangle(64, 0, 16, 16);
        }

        #endregion
    }
}
