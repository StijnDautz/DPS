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

        public int Rows
        {
            get { return dimensions.X; }
        }

        public int Collums
        {
            get { return dimensions.Y; }
        }

        //Create ObjectGrid read from a file
        public ObjectGrid(string id, string assetName, int tileSize) : base(id)
        {
            _tileSize = tileSize;
            Load(assetName);
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Collums * tileSize, Rows * tileSize);
        }

        //Create empty ObjectGrid
        public ObjectGrid(string id, int collums, int rows, int tileSize) : base(id, rows * collums)
        {
            dimensions = new Point(collums, rows);
            _tileSize = tileSize;
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, collums * tileSize, rows * tileSize);
        }

        public int GetPositionInGrid(Vector2 p)
        {
            Vector2 pos = p - GlobalPosition;
            return (int)pos.X / (_tileSize) + (int)pos.Y / (_tileSize) * Collums;
        }

        public int GetPositionInGrid(Object o)
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                if(Objects[i] == o)
                {
                    return i;
                }
            }
            return -1;
        }

        public Object getTile(Vector2 p)
        {
            return getTile(GetPositionInGrid(p));
        }

        //i is index of object in Objects
        public Object getTile(int i)
        {
            if (i < 0 || i > Objects.Count - 1)
            {
                return null;
            }
            else
            {
                return Objects[i];
            }
        }

        public void RemoveObject(Object o)
        {
            removeTile(GetPositionInGrid(o.Position));
        }

        public void removeTile(int i)
        {
            Objects[i] = null;
        }

        public void setTile(int x, int y, Object o)
        {
            Objects[x * dimensions.Y + y] = o;
        }

        public void setTile(int i, Object o)
        {
            Objects[i] = o;
            o.Position = new Vector2(i % Collums, i / Collums) * _tileSize;
        }

        public bool AddToFirstFreeSpot(Object o)
        {
            if(Objects.Count < Rows * Collums)
            {
                o.Parent = this;
                Objects.Add(o);
                o.Position = new Vector2((Objects.Count - 1) % Collums, (Objects.Count - 1) / Collums) * _tileSize;
                return true;
            }
            return false;
        }

        public void SwapObjects(Object i, Object j)
        {
            int temp = GetPositionInGrid(j);
            setTile(GetPositionInGrid(i), j);
            setTile(temp, i);
        }
    }
}