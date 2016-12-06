using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    static class PathFinder
    {
        public struct Tile
        {
            public Point point;
            public int dTotal;

            public Tile(Point start, Point end, Point current)
            {
                //dStart + dEnd
                dTotal = Math.Abs(start.X - current.X) + Math.Abs(start.Y - current.Y) + Math.Abs(end.X - current.X) + Math.Abs(start.Y - current.Y);
                point = current;
            }
        }

        public static List<Tile> FindPath(Map map, Vector2 start, Point end, World world)
        {
            List<Tile> tiles = new List<Tile>();
            List<Tile> path = new List<Tile>();
            Point[] points = new Point[4];  
            bool pathFound = false;

            //create startingPoint and add it to the path
            Point startPoint = map.getPositionInGrid(start);
            path.Add(new Tile(startPoint, end, startPoint));

            while(pathFound == false)
            {
                //calculate tiles
                Point pathPoint = path[path.Count].point;
                points[0] =  new Point(pathPoint.X + 1, pathPoint.Y);
                points[1] = new Point(pathPoint.X - 1, pathPoint.Y);
                points[2] = new Point(pathPoint.X, pathPoint.Y + 1);
                points[3] = new Point(pathPoint.X, pathPoint.Y - 1);

                //check if new Point should be added
                foreach(Point p in points)
                {
                    if (!map.Collides(p))
                    {
                        Tile adjecentTile = new Tile(startPoint, end, p);
                        if (!tiles.Contains(adjecentTile))
                        {
                            tiles.Add(adjecentTile);
                        }
                    }
                }

                //loop through all tiles
                int dTotalMin = tiles.Min(t => t.dTotal);
                foreach(Tile t in tiles)
                {
                    if(t.dTotal == dTotalMin)
                    {
                        path.Add(t);
                        break;
                    }
                }
            }

            //track path from end to start
            //start at the starting tile
            int pathPointIndex = 0;
            while (pathPointIndex != path.Count)
            {
                Point pathPoint = path[pathPointIndex].point;
                for (int i = path.Count - 1; i > pathPointIndex; i--)
                {
                    //when a adjecent tile is found, remove all tiles with a smaller index
                    if (pathPoint.X - 1 == path[i].point.X || pathPoint.X + 1 == path[i].point.X || pathPoint.Y - 1 == path[i].point.Y || pathPoint.Y + 1 == path[i].point.Y)
                    {
                        //pathPointIndex++ - do not remove the the tile with index pathPointIndex, as this is part of the path
                        pathPointIndex++;
                        while(i > pathPointIndex)
                        {
                            path.Remove(path[pathPointIndex]);
                            pathPointIndex++;
                        }
                        break;
                    }
                }
            }
            return path;
        }
    }
}