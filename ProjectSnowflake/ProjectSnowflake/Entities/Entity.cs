using Microsoft.Xna.Framework;
using ProjectSnowflake.Entities.Components;
using ProjectSnowflake.Timing;
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

        public List<IComponent> components { get; set; }

        #endregion


        #region Constructors

        public Entity()
        {
            this.position = new Vector2();
            this.direction = new Vector2();
            this.components = new List<IComponent>();
        }

        #endregion


        #region Functions

        public void update()
        {
            foreach (var component in components)
                component.update(this);

            position += direction * Time.gameElapsedSeconds; 
        }

        public void draw()
        {
            foreach (var component in components)
                component.draw(this);
        }

        #endregion
    }
}
