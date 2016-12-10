using Microsoft.Xna.Framework;
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
        public Rectangle? sourceRectangle { get; set; }
        public bool walkable { get; set; }
        public bool draw { get; set; }

        public List<TileEvent> events { get; set; }

        #endregion


        #region Constructors

        public TileDefinition(bool draw)
        {
            this.draw = draw;
            this.walkable = true;
            this.events = new List<TileEvent>();
        }
        public TileDefinition(Texture2D texture, bool walkable)
        {
            this.texture = texture;
            this.walkable = walkable;
            this.draw = true;
            this.events = new List<TileEvent>();
        }

        #endregion
    }
}
