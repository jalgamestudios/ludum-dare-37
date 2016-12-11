using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.Sweets
{
    static class SweetTypeHelper
    {
        public static Rectangle getSourceRectangle(this SweetType sweetType)
        {
            switch (sweetType)
            {
                case SweetType.Cane: return new Rectangle(0, 0, 16, 32);
                case SweetType.Bombon: return new Rectangle(16, 0, 16, 16);
                case SweetType.CircleSugar: return new Rectangle(16, 16, 16, 16);
                case SweetType.Donut: return new Rectangle(32, 0, 32, 32);
            }
            return new Rectangle();
        }

        public static Point getDimensions(this SweetType sweetType)
        {
            switch (sweetType)
            {
                case SweetType.Cane: return new Point(1, 2);
                case SweetType.Bombon: return new Point(1, 1);
                case SweetType.CircleSugar: return new Point(1, 1);
                case SweetType.Donut: return new Point(2, 2);
            }
            return new Point(0,0);
        }
    }
}
