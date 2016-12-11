using Microsoft.Xna.Framework;
using ProjectSnowflake.Entities.Components;
using ProjectSnowflake.Timing;
using ProjectSnowflake.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.Entities
{
    class Entity
    {
        #region Variables

        public Vector2 position { get; set; }
        public Vector2 direction { get; set; }
        public Vector2 actualDirection { get; set; }
        public Vector2 colliderSize { get; set; }
        public Vector2 center { get { return position + colliderSize / 2; } }

        public List<IComponent> components { get; set; }

        #endregion


        #region Constructors

        public Entity()
        {
            this.position = new Vector2();
            this.direction = new Vector2();
            this.components = new List<IComponent>();
            this.colliderSize = new Vector2(0.6f, 0.6f);
        }

        #endregion


        #region Functions

        public void update()
        {
            foreach (var component in components)
                component.update(this);

            Vector2 positionBefore = position;
            tryMove(direction * Time.gameElapsedSeconds * new Vector2(1, 0));
            tryMove(direction * Time.gameElapsedSeconds * new Vector2(0, 1));
            if (positionBefore != position)
                actualDirection = position - positionBefore;
        }

        public void draw()
        {
            foreach (var component in components)
                component.draw(this);
        }

        public void tryMove(Vector2 offset)
        {
            position += offset;
            //if (WorldManager.collides(position, colliderSize))
            //    position -= offset;
        }

        #endregion
    }
}
