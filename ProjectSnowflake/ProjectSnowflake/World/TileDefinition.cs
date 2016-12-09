using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.World
{
    class TileDefinition
    {
        #region Variables

        public Texture2D texture { get; set; }
        public bool walkable { get; set; }

        #endregion


        #region Constructors

        public TileDefinition(Texture2D texture, bool walkable)
        {
            this.texture = texture;
            this.walkable = walkable;
        }

        #endregion
    }
}
