using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.World
{
    class Tile
    {
        #region Variables

        public int type { get; }
        public TileDefinition definition { get { return WorldManager.tileDefinitions[type]; } }

        public TileRotation rotation { get; set; }
        public SpriteEffects flipMode { get; set; }

        #endregion


        #region Constructors

        public Tile(int type)
        {
            this.type = type;
        }

        #endregion
    }
}
