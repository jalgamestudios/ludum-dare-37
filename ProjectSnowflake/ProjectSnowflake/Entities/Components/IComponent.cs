using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.Entities.Components
{
    interface IComponent
    {
        void update(Entity entity);
        void draw(Entity entity);
    }
}
