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
            playerEntity.components.Add(new WalkingTextureComponent(RenderingManager.contentManager.Load<Texture2D>("characters/jimmy")));
            playerEntity.components.Add(new PlayerControlledComponent(3));
            EntityManager.entities.Add(playerEntity);
        }

        public static void update()
        {

        }

        #endregion
    }
}
