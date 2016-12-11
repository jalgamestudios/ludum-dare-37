using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSnowflake.World.Pathfinding
{
    class Pathfinder
    {
        #region Variables

        private static PathfindingGrid grid { get; set; }

        private static Rectangle pathfindingArea { get; set; }

        static List<Point> closedList = new List<Point>();
        static List<Point> openList = new List<Point>();

        #endregion


        #region Functions

        public static List<Point> findPath(Point start, Point end)
        {
            if (grid == null)
                createGrid();

            start -= pathfindingArea.Location;
            end -= pathfindingArea.Location;

            grid.computeEstimations(end.X, end.Y);
            grid.clearCost();

            closedList = new List<Point>();
            openList = new List<Point>();

            closedList.Add(start);
            foreach (var adjacentTile in grid.getCell(start).connections)
            {
                grid.getCell(adjacentTile).predecessor = start;
                openList.Add(adjacentTile);
            }
            
            while (openList.Count > 0)
            {
                Point current = openList.OrderBy(
                    p => grid.getCell(p).cost + grid.getCell(p).estimatedDistance)
                    .First();
                closedList.Add(current);
                openList.Remove(current);

                if (closedList.Contains(end))
                {
                    List<Point> nodes = new List<Point>();
                    nodes.Add(end);
                    while (!nodes.Contains(start))
                        nodes.Add(grid.getCell(nodes.Last()).predecessor);
                    return nodes.Select(node => node + pathfindingArea.Location).Reverse().ToList();
                }

                foreach (var adjacent in grid.getCell(current).connections)
                {
                    if (closedList.Contains(adjacent))
                        continue;
                    var adjacentCell = grid.getCell(adjacent);
                    if (openList.Contains(adjacent))
                    {
                        float newCost = grid.getCell(current).cost +
                            (current - adjacent).ToVector2().Length();
                        if (newCost < adjacentCell.cost)
                        {
                            adjacentCell.cost = newCost;
                            adjacentCell.predecessor = current;
                        }
                    }
                    else
                    {
                        adjacentCell.cost = grid.getCell(current).cost +
                            (current - adjacent).ToVector2().Length();
                        adjacentCell.predecessor = current;
                        openList.Add(adjacent);
                    }
                }
            }

            return new List<Point>();
        }

        private static void createGrid()
        {
            pathfindingArea = new Rectangle(118, 104, 18, 15);

            grid = new PathfindingGrid(pathfindingArea.Width, pathfindingArea.Height);

            for (int i = 0; i < pathfindingArea.Width; i++)
            {
                for (int j = 0; j < pathfindingArea.Height; j++)
                {
                    if (walkable(i, j))
                    {
                        PathfindingCell cell = new PathfindingCell();
                        addPoint(cell, new Point(i - 1, j));
                        addPoint(cell, new Point(i + 1, j));
                        addPoint(cell, new Point(i, j - 1));
                        addPoint(cell, new Point(i, j + 1));
                        grid.cells[i, j] = cell;
                    }
                }
            }
        }

        private static void addPoint(PathfindingCell cell, Point point)
        {
            if (walkable(point.X, point.Y))
                cell.connections.Add(point);
            else
                ;
        }

        private static bool walkable(int x, int y)
        {
            if (x < 0 || y < 0 || x >= pathfindingArea.Width || y >= pathfindingArea.Height)
                return false;
            return !WorldManager.layers.Any(layer => !layer.tiles[x + pathfindingArea.X, y + pathfindingArea.Y].definition.walkable);
        }

        #endregion
    }
}
