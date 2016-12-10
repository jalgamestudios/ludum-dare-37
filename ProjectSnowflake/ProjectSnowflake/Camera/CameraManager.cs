using Microsoft.Xna.Framework;
using ProjectSnowflake.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.Camera
{
    class CameraManager
    {
        #region Variables

        public static Vector2 offset { get; set; }
        public static Vector2 worldFrameSize { get { return RenderingManager.screenDimensions.ToVector2() / 16f; } }

        #endregion


        #region Functions

        public static Rectangle getScreenPosition(Vector2 position, Vector2 size)
        {
            Vector2 offsetPosition = position - offset;
            return new Rectangle((int)(offsetPosition.X * 16), (int)(offsetPosition.Y * 16), (int)(size.X * 16), (int)(size.Y * 16));
        }

        public static Vector2 getWorldPosition(int x, int y)
        {
            return new Vector2(x, y) / 16 + offset;
        }

        public static Vector2 getWorldPosition(Rectangle screenPosition)
        {
            return new Vector2(screenPosition.X, screenPosition.Y) / 16 + offset;
        }

        public static Vector2 getWorldSize(int x, int y)
        {
            return new Vector2(x, y) / 16;
        }

        public static Vector2 getWorldSize(Rectangle screenPosition)
        {
            return new Vector2(screenPosition.X, screenPosition.Y) / 16;
        }

        #endregion
    }
}
