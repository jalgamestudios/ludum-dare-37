using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.Sweets
{
    static class SweetsShelf
    {
        #region Variables

        public static List<SweetGrid> sweetGrids { get; set; }

        #endregion


        #region Functions

        public static void init()
        {
            sweetGrids = new List<SweetGrid>();
            for (int i = 0; i < 9; i++)
            {
                sweetGrids.Add(new SweetGrid());
                sweetGrids[i].addSweet(SweetType.Cane);
            }
        }


        public static void draw()
        {
            for (int i = 0; i < 9; i++)
            {
                sweetGrids[i].draw(sweetGridPosition(i));
            }
        }

        public static Point sweetGridPosition(int index)
        {
            int x = index % 3;
            int y = index / 3;
            return new Point(x * 70 + 70, y * 35 + 10);
        }

        #endregion
    }
}
