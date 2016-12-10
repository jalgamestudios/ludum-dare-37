using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.World
{
    class TileEvent
    {
        #region Variables

        public float triggerDistance { get; set; }
        public string code { get; set; }

        #endregion


        #region Constructors

        public TileEvent(float triggerDistance, string code)
        {
            this.triggerDistance = triggerDistance;
            this.code = code;
        }

        #endregion
    }
}
