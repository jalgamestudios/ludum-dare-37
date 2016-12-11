using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectSnowflake.Camera;
using ProjectSnowflake.Rendering;
using ProjectSnowflake.Timing;
using ProjectSnowflake.World.Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.Entities.Components
{
    class MomAIComponent : IComponent
    {
        #region Variables

        public List<Vector2> path { get; set; }

        private float speed = 0.5f;

        private Texture2D viewIndicator { get; set; }

        #endregion


        #region Constructors

        public MomAIComponent()
        {
            path = new List<Vector2>();
            viewIndicator = RenderingManager.contentManager.Load<Texture2D>("ui/view-indicator");
        }

        #endregion


        #region Functions

        public void update(Entity entity)
        {
            if (path.Count == 0)
            {
                path = Pathfinder.findPath(new Point((int)entity.position.X, (int)entity.position.Y), new Point(121, 107))
                    .Select(p => p.ToVector2() + new Vector2(0.2f, 0.2f)).ToList();
            }
            if (path.Count > 0)
            {
                Vector2 direction = path[0] - entity.position;
                if (direction.Length() < 0.01f)
                    path.RemoveAt(0);
                else
                {
                    Vector2 normDirection = direction / direction.Length() * speed;
                    entity.direction = normDirection;
                    if ( speed * Time.gameElapsedSeconds > direction.Length())
                    {
                        entity.direction = new Vector2();
                        entity.position = path[0];
                        path.RemoveAt(0);
                    }
                }
            }
        }

        public void draw(Entity entity)
        {
            float rotation = 0;

            WalkingTextureComponent walker = (WalkingTextureComponent)entity.components.First(comp => comp.GetType() == typeof(WalkingTextureComponent));
            rotation = walker.rotation;

            RenderingManager.spriteBatch.Draw(viewIndicator,
                CameraManager.getScreenPosition(entity.center, new Vector2(4, 2)),
                null,
                Color.White,
                rotation,
                new Vector2(32, 32),
                SpriteEffects.None,
                0);
        }

        #endregion
    }
}
