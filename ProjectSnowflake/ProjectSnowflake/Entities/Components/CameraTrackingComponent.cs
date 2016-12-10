using ProjectSnowflake.Camera;
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



        #endregion


        #region Constructors

        #endregion


        #region Functions

        public void update(Entity entity)
        {
            CameraManager.offset = entity.position - CameraManager.worldFrameSize / 2;

        }

        public void draw(Entity entity)
        {
        }

        #endregion
    }
}
