using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectSnowflake.Entities;
using ProjectSnowflake.Input;
using ProjectSnowflake.Rendering;
using ProjectSnowflake.Timing;
using ProjectSnowflake.UI;
using ProjectSnowflake.World;
using System;
using System.Collections.Generic;

namespace ProjectSnowflake
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1366;
            graphics.PreferredBackBufferWidth = 768;
            Content.RootDirectory = "Content";
            this.Window.AllowUserResizing = true;
            this.Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
        }
        void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            if (graphics.PreferredBackBufferWidth != Window.ClientBounds.Width
                || graphics.PreferredBackBufferHeight != Window.ClientBounds.Height)
            {
                graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
                graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
                graphics.ApplyChanges();
            }
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            RenderingManager.init(graphics, spriteBatch, Content);
            InputManager.init((x, y) => { });
            WorldManager.init();
            EntityManager.init();
            UIManager.init();
        }
        
        protected override void Update(GameTime gameTime)
        {
            Time.update((float)gameTime.ElapsedGameTime.TotalSeconds);
            Time.updateFps.frame((float)gameTime.ElapsedGameTime.TotalSeconds);

            updateInput();

            WorldManager.update();
            EntityManager.update();
            UIManager.update();

            base.Update(gameTime);
        }

        private void updateInput()
        {
            List<GamePadState> gamepads = new List<GamePadState>();
            gamepads.Add(GamePad.GetState(PlayerIndex.One));
            gamepads.Add(GamePad.GetState(PlayerIndex.Two));
            gamepads.Add(GamePad.GetState(PlayerIndex.Three));
            gamepads.Add(GamePad.GetState(PlayerIndex.Four));

            InputManager.update(Keyboard.GetState(), Mouse.GetState(), gamepads, IsActive);
        }

        protected override void Draw(GameTime gameTime)
        {
            RenderingManager.startDraw();

            Time.drawFps.frame((float)gameTime.ElapsedGameTime.TotalSeconds);

            WorldManager.draw();
            EntityManager.draw();
            UIManager.draw();

            RenderingManager.endDraw();
            base.Draw(gameTime);
        }
    }
}
