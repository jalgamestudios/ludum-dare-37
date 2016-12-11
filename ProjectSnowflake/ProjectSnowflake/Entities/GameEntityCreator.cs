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
        #region Variables

        public static Entity playerEntity { get; set; }
        public static Entity mommyEntity { get; set; }

        #endregion


        #region Functions

        public static void init()
        {
            createPlayer();
            createMommy();
        }

        private static void createPlayer()
        {
            playerEntity = new Entity();
            playerEntity.position = new Vector2(128, 111);
            playerEntity.components.Add(new WalkingTextureComponent(RenderingManager.contentManager.Load<Texture2D>("characters/jimmy")));
            playerEntity.components.Add(new PlayerControlledComponent(3));
            playerEntity.components.Add(new CameraTrackingComponent());
            playerEntity.components.Add(new TriggersEventsComponent());
            EntityManager.entities.Add(playerEntity);
        }
        private static void createMommy()
        {
            mommyEntity = new Entity();
            mommyEntity.position = new Vector2(130, 111);
            mommyEntity.components.Add(new WalkingTextureComponent(RenderingManager.contentManager.Load<Texture2D>("characters/mommy")));
            mommyEntity.components.Add(new PlayerControlledComponent(3));
            EntityManager.entities.Add(mommyEntity);
        }

        public static void update()
        {

        }

        #endregion
    }
}
