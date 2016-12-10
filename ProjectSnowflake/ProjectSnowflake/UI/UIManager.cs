using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.UI
{
    class UIManager
    {
        #region Variables

        #endregion


        #region Functions

        public static void init()
        {
            BottomBarManager.init();
        }

        public static void update()
        {
            BottomBarManager.update();
        }

        public static void draw()
        {
            BottomBarManager.draw();
        }

        #endregion
    }
}
