using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.Sweets
{
    class Sweet
    {
        #region Variables

        public SweetType type { get; set; }

        public Point position { get; set; }

        #endregion


        #region Constructors

        public Sweet(SweetType type)
        {
            this.type = type;
            this.position = position;
        }

        public Sweet(SweetType type, Point position)
        {
            this.type = type;
            this.position = position;
        }

        #endregion
    }
}
