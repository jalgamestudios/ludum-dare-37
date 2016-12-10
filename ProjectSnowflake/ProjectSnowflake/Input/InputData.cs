using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ProjectSnowflake.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.Input
{
    class InputData
    {
        public KeyboardState keyboardState { get; private set; }

        public Vector2 mousePosition { get; private set; }
        public bool leftClick { get; private set; }
        public bool rightClick { get; private set; }
        public MouseState mouseState { get; private set; }

        public List<GamePadState> gamepads { get; set; }

        public InputData(KeyboardState keyboardState, MouseState mouseState, List<GamePadState> gamepads)
        {
            this.keyboardState = keyboardState;
            this.mouseState = mouseState;
            leftClick = (mouseState.LeftButton == ButtonState.Pressed);
            rightClick = (mouseState.RightButton == ButtonState.Pressed);
            mousePosition = new Vector2(
                (float)mouseState.Position.X / RenderingManager.graphicsDevice.Viewport.Width,
                (float)mouseState.Position.Y / RenderingManager.graphicsDevice.Viewport.Height);


            this.gamepads = gamepads;
        }
    }
}
