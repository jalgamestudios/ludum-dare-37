using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.Sweets
{
    static class PlayerInventory
    {
        #region Variables

        public static SweetGrid inventory { get; set; }

        #endregion


        #region Functions

        public static void init()
        {
            inventory = new SweetGrid();
            inventory.dimensions = new Point(4, 2);
        }

        public static void update()
        {

        }

        #endregion
    }
}
