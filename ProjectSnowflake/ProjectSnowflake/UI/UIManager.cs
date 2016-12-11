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
            HUDWorldManager.init();
            BottomBarManager.init();
            SweetShelfManager.init();
            ProgressIndicator.init();
            EatingManager.init();
        }

        public static void update()
        {
            HUDWorldManager.update();
            BottomBarManager.update();
            SweetShelfManager.update();
            EatingManager.update();
        }

        public static void draw()
        {
            HUDWorldManager.draw();
            BottomBarManager.draw();
            SweetShelfManager.draw();
            EatingManager.draw();
        }

        #endregion
    }
}
