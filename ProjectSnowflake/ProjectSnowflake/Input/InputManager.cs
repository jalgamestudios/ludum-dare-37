using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.Input
{
    class InputManager
    {
        public static InputData lastFrame { get; set; }
        public static InputData thisFrame { get; set; }
        public delegate void SetMousePositionHandler(int pixelX, int pixelY);
        private static SetMousePositionHandler setPixelMousePosition { get; set; }
        public static bool IsActive { get; private set; }

        public static void init(SetMousePositionHandler setPixelMousePosition)
        {
            IsActive = false;
            thisFrame = new InputData(new KeyboardState(), new MouseState(), new List<GamePadState>());
            lastFrame = new InputData(new KeyboardState(), new MouseState(), new List<GamePadState>());
            InputManager.setPixelMousePosition = setPixelMousePosition;
        }

        public static void update(KeyboardState keyboardState, MouseState mouseState, List<GamePadState> gamepads, bool IsActive)
        {
            InputManager.IsActive = IsActive;
            if (IsActive)
            {
                lastFrame = thisFrame;

                for (int i = 0; i < gamepads.Count; i++)
                    gamepads[i] = processGamepadState(gamepads[i]);

                thisFrame = new InputData(keyboardState, mouseState, gamepads);
            }
        }

        private static GamePadState processGamepadState(GamePadState rawState)
        {
            return rawState;
            GamePadState state = new GamePadState(
                new GamePadThumbSticks(rawState.ThumbSticks.Left, new Vector2(rawState.ThumbSticks.Right.X, rawState.Triggers.Left * 2 - 1)),
                new GamePadTriggers(rawState.ThumbSticks.Right.Y, rawState.Triggers.Right * 2 - 1),
                rawState.Buttons,
                rawState.DPad);
            return state;
        }

        public static bool wasKeyTapped(Keys key, bool onRelease = true)
        {
            if (onRelease)
                return (lastFrame.keyboardState.IsKeyDown(key) &&
                    thisFrame.keyboardState.IsKeyUp(key));

            return (lastFrame.keyboardState.IsKeyUp(key) &&
                thisFrame.keyboardState.IsKeyDown(key));
        }
    }
}
