using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectSnowflake.Entities;
using ProjectSnowflake.Rendering;
using ProjectSnowflake.Timing;
using ProjectSnowflake.World;
using System;

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
            WorldManager.init();
            EntityManager.init();
        }
        
        protected override void Update(GameTime gameTime)
        {
            Time.update((float)gameTime.ElapsedGameTime.TotalSeconds);
            Time.updateFps.frame((float)gameTime.ElapsedGameTime.TotalSeconds);

            WorldManager.update();
            EntityManager.update();

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            RenderingManager.startDraw();

            Time.drawFps.frame((float)gameTime.ElapsedGameTime.TotalSeconds);

            WorldManager.draw();
            EntityManager.draw();

            RenderingManager.endDraw();
            base.Draw(gameTime);
        }
    }
}
