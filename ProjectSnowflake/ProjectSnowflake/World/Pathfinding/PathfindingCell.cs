using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.World.Pathfinding
{
    class PathfindingCell
    {
        #region Variables

        public Point predecessor { get; set; }
        public List<Point> connections { get; set; }
        public float cost { get; set; }
        public float estimatedDistance { get; set; }

        public enum State
        {
            Walked,

        }

        #endregion


        #region Constructors

        public PathfindingCell()
        {
            this.connections = new List<Point>();
            this.cost = 0;
            this.estimatedDistance = 0;
        }

        #endregion
    }
}
