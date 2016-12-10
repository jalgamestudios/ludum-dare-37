using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectSnowflake.Entities.Components;
using ProjectSnowflake.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.Entities
{
    class GameEntityCreator
    {
        #region Functions

        public static void init()
        {
            Entity playerEntity = new Entity();
            playerEntity.position = new Vector2(128, 111);
            playerEntity.components.Add(new WalkingTextureComponent(RenderingManager.contentManager.Load<Texture2D>("characters/jimmy")));
            playerEntity.components.Add(new PlayerControlledComponent(3));
            playerEntity.components.Add(new CameraTrackingComponent());
            playerEntity.components.Add(new TriggersEventsComponent());
            EntityManager.entities.Add(playerEntity);
        }

        public static void update()
        {

        }

        #endregion
    }
}
