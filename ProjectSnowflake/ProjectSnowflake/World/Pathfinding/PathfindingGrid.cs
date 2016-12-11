using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.World.Pathfinding
{
    class PathfindingGrid
    {
        #region Variables

        public PathfindingCell[,] cells { get; set; }
        public int width { get { return cells.GetLength(0); } }
        public int height { get { return cells.GetLength(1); } }

        #endregion

        #region Constructors

        public PathfindingGrid(int width, int height)
        {
            this.cells = new PathfindingCell[width, height];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    cells[i,j] = new PathfindingCell();
        }

        #endregion


        #region Functions

        public void clearCost()
        {
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    cells[i, j].cost = -1;
        }

        public void computeEstimations(int x, int y)
        {
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    cells[i, j].estimatedDistance = (float)Math.Sqrt((i - x) * (i - x) + (j - y) * (j - y));
        }

        public PathfindingCell getCell(Point point)
        {
            return cells[point.X, point.Y];
        }

        #endregion
    }
}
