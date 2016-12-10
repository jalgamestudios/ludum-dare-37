using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectSnowflake.Camera;
using ProjectSnowflake.Rendering;
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
            Rectangle position = CameraManager.getScreenPosition(entity.position, new Vector2(1, 1));
            RenderingManager.spriteBatch.Draw(texture, position, Color.White);
        }

        #endregion
    }
}
