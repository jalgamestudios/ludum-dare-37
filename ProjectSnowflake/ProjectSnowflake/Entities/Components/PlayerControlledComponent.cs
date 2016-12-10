using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ProjectSnowflake.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.Entities.Components
{
    class PlayerControlledComponent : IComponent
    {
        #region Variables

        public float speed { get; set; }

        #endregion


        #region Constructors

        public PlayerControlledComponent(float speed)
        {
            this.speed = speed;
        }

        #endregion


        #region Functions

        public void draw(Entity entity)
        {
            Vector2 direction = new Vector2();
            if (InputManager.thisFrame.keyboardState.IsKeyDown(Keys.A))
                direction.X = -1;
            if (InputManager.thisFrame.keyboardState.IsKeyDown(Keys.D))
                direction.X = 1;
            if (InputManager.thisFrame.keyboardState.IsKeyDown(Keys.W))
                direction.Y = -1;
            if (InputManager.thisFrame.keyboardState.IsKeyDown(Keys.S))
                direction.Y = 1;

            entity.direction = direction * speed;
        }

        public void update(Entity entity)
        {
        }

        #endregion
    }
}
