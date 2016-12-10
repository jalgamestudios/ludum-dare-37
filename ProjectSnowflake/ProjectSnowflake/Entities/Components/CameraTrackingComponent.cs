using Microsoft.Xna.Framework;
using ProjectSnowflake.Camera;
using ProjectSnowflake.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.Entities.Components
{
    class CameraTrackingComponent : IComponent
    {
        #region Variables

        public int horizontalBorder { get; set; }
        public int verticalBorder { get; set; }

        #endregion


        #region Constructors

        public CameraTrackingComponent()
        {
            this.horizontalBorder = (int)(RenderingManager.screenDimensions.X * 0.35f);
            this.verticalBorder = (int)(RenderingManager.screenDimensions.Y * 0.35f);
        }

        #endregion


        #region Functions

        public void update(Entity entity)
        {
            Vector2 offset = CameraManager.offset;

            Rectangle ps = CameraManager.getScreenPosition(entity.position + entity.colliderSize / 2, new Vector2());

            if (ps.X < horizontalBorder)
                offset.X = (entity.position + entity.colliderSize / 2).X
                    - CameraManager.getWorldSize(horizontalBorder, 0).X;

            if (ps.X > RenderingManager.screenDimensions.X - horizontalBorder)
                offset.X = (entity.position + entity.colliderSize / 2).X
                    - CameraManager.getWorldSize(RenderingManager.screenDimensions.X - horizontalBorder, 0).X - (1 / 16f);

            if (ps.Y < verticalBorder)
                offset.Y = (entity.position + entity.colliderSize / 2).Y
                    - CameraManager.getWorldSize(0, verticalBorder).Y;

            if (ps.Y > RenderingManager.screenDimensions.Y - verticalBorder)
                offset.Y = (entity.position + entity.colliderSize / 2).Y
                    - CameraManager.getWorldSize(0, RenderingManager.screenDimensions.Y - verticalBorder).Y - (1 / 16f);

            CameraManager.offset = offset;
        }

        public void draw(Entity entity)
        {
        }

        #endregion
    }
}
