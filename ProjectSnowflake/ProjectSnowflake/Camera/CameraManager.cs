using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.Camera
{
    class CameraManager
    {
        public static Rectangle getScreenPosition(Vector2 position, Vector2 size)
        {
            return new Rectangle((int)(position.X * 16), (int)(position.Y * 16), (int)(size.X * 16), (int)(size.Y * 16));
        }
    }
}
