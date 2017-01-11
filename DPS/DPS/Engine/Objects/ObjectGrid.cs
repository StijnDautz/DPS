using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    partial class ObjectGrid : ObjectList
    {
        private int _tileSize;
        private Point dimensions;
        private Point _spacing;

        public int Rows
        {
            get { return dimensions.X; }
        }

        public int Collums
        {
            get { return dimensions.Y; }
        }

        public Point Spacing
        {
            get { return _spacing; }
            set
            {
                for(int x = 0; x < Rows; x++)
                {
                    for(int y = 0; y < Collums; y++)
                    {
                        getTile(x, y).Position = new Vector2(x * (_tileSize + value.X), y * (_tileSize + value.Y));
                    }
                }
                _spacing = value;
            }
        }

        //Create ObjectGrid read from a file
        public ObjectGrid(string id, string assetName, int tileSize) : base(id)
        {
            _tileSize = tileSize;
            Load(assetName);
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Collums * tileSize, Rows * tileSize);
        }

        //Create empty ObjectGrid
        public ObjectGrid(string id, int rows, int collums, int tileSize) : base(id, rows * collums)
        {
            dimensions = new Point(rows, collums);
            _tileSize = tileSize;
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, collums * tileSize, rows * tileSize);
        }

        public Object getTile(Point p)
        {
            return Objects[p.X * dimensions.Y + p.Y];
        }

        public Object getTile(int x, int y)
        {
            return Objects[x * dimensions.Y + y];
        }

        public void setTile(int x, int y, Object o)
        {
            Objects[x * dimensions.Y + y] = o;
        }

        //TODO double func
        public void removeTile(Point p)
        {
            Objects[p.X * dimensions.Y + p.Y] = null;
        }

        public Object getTile(Vector2 p)
        {
            return getTile(GetPositionInGrid(p));
        }

        public Point GetPositionInGrid(Object o)
        {
            return new Point((int)o.Position.X / (_tileSize + _spacing.X), (int)o.Position.Y / (_tileSize + _spacing.Y));
        }

        public Point GetPositionInGrid(Vector2 p)
        {
            Vector2 pos = p - GlobalPosition;
            return new Point((int)pos.X / (_tileSize + _spacing.X), (int)pos.Y / (_tileSize + _spacing.Y));
        }

        public void RemoveObject(Object o)
        {
            removeTile(GetPositionInGrid(o));
        }

        public bool AddToFirstFreeSpot(Object o)
        {
            for (int y = 0; y < Rows; y++)
            {
                for(int x = 0; x < Collums; x++)
                {
                    if(getTile(x, y) == null)
                    {
                        setTile(x, y, o);
                        return true;
                    }
                }
            }
            return false;
        }

        //BUG??????????????????????????????????????????????????????????????????????????
        public void SwapObjects(Point o, Point p)
        {
            Object temp = getTile(o);
            Object temp2 = getTile(p);
            setTile(o.X, o.Y, temp2);
            setTile(p.X, p.Y, temp);
        }
    }
}