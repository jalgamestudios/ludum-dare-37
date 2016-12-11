using Microsoft.Xna.Framework;
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

        #endregion


        #region Constructors

        public MomAIComponent()
        {
            path = new List<Vector2>();
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
        }

        #endregion
    }
}
