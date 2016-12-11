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

        public float targetRotation { get; set; }

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
            Vector2 center = entity.position + entity.colliderSize / 2;
            Rectangle position = CameraManager.getScreenPosition(center, new Vector2(1, 1));
            float targetRotation = rotation;
            if (entity.direction.Length() > 0)
                targetRotation = (float)Math.Atan2(entity.actualDirection.Y, entity.actualDirection.X) + MathHelper.PiOver2;

            rotation = rotationStep(rotation, targetRotation, 6, Time.gameElapsedSeconds);

            RenderingManager.spriteBatch.Draw(texture, position, null, Color.White, rotation, new Vector2(8,8), SpriteEffects.None, 0);
        }


        private float rotationStep(float currentRotation, float wantedRotation, float speed, float time)
        {
            if (wantedRotation > MathHelper.Pi)
                wantedRotation -= MathHelper.TwoPi;
            if (wantedRotation <= -MathHelper.Pi)
                wantedRotation += MathHelper.TwoPi;

            if (currentRotation < wantedRotation && Math.Abs(wantedRotation - currentRotation) < MathHelper.Pi)
            {
                currentRotation += speed * time;
                if (currentRotation > wantedRotation)
                    currentRotation = wantedRotation;
            }
            else if (currentRotation < wantedRotation && Math.Abs(wantedRotation - currentRotation) >= MathHelper.Pi)
            {
                currentRotation -= speed * time;
                if (currentRotation > wantedRotation)
                    currentRotation = wantedRotation;
            }
            if (currentRotation > wantedRotation && Math.Abs(currentRotation - wantedRotation) < MathHelper.Pi)
            {
                currentRotation -= speed * time;
                if (currentRotation < wantedRotation)
                    currentRotation = wantedRotation;
            }
            else if (currentRotation > wantedRotation && Math.Abs(currentRotation - wantedRotation) >= MathHelper.Pi)
            {
                currentRotation += speed * time;
                if (currentRotation < wantedRotation)
                    currentRotation = wantedRotation;
            }
            if (currentRotation > MathHelper.Pi)
                currentRotation -= MathHelper.TwoPi;
            if (currentRotation <= -MathHelper.Pi)
                currentRotation += MathHelper.TwoPi;
            return currentRotation;
        }

        #endregion
    }
}
