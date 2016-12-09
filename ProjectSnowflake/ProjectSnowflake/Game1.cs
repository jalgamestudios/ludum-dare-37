using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectSnowflake.Rendering;
using ProjectSnowflake.World;

namespace ProjectSnowflake
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferWidth = 1080;
            Content.RootDirectory = "Content";
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
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            WorldManager.update();

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            RenderingManager.startDraw();

            WorldManager.draw();

            RenderingManager.endDraw();
            base.Draw(gameTime);
        }
    }
}
