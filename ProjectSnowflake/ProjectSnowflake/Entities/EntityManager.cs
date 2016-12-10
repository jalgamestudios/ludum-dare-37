using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.Entities
{
    static class EntityManager
    {
        #region Variables

        public static List<Entity> entities { get; set; }

        #endregion


        #region Functions

        public static void init()
        {
            entities = new List<Entity>();
            GameEntityCreator.init();
        }

        public static void update()
        {
            foreach (var entity in entities)
                entity.update();

            GameEntityCreator.update();
        }

        public static void draw()
        {
            foreach (var entity in entities)
                entity.draw();
        }

        #endregion
    }
}
