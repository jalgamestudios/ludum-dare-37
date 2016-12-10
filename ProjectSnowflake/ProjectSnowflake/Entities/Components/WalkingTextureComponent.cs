using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectSnowflake.Camera;
using ProjectSnowflake.Rendering;
using ProjectSnowflake.Timing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.Entities.Components
{
    class WalkingTextureComponent : IComponent
    {
        #region Variables

        public Texture2D texture { get; set; }

        public float rotation { get; set; }

        #endregion


        #region Constructors

        public WalkingTextureComponent(Texture2D texture)
        {
            this.texture = texture;
        }

        #endregion

        #region Functions

        public void update(Entity entity)
        {

        }

        public void draw(Entity entity)
        {
            Rectangle position = CameraManager.getScreenPosition(entity.position + new Vector2(0.5f, 0.5f), new Vector2(1, 1));
            if (entity.direction.Length() > 0)
                rotation = (float)Math.Atan2(entity.direction.Y, entity.direction.X) + MathHelper.PiOver2;
            RenderingManager.spriteBatch.Draw(texture, position, null, Color.White, rotation, new Vector2(8,8), SpriteEffects.None, 0);
        }

        #endregion
    }
}
