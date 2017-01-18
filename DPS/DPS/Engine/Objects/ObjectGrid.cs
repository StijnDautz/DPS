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
        private int _collums;
        private int _rows;

        public int Rows
        {
            get { return _rows; }
        }

        public int Collums
        {
            get { return _collums; }
        }

        public int Size
        {
            get { return _collums * _rows; }
        }

        //Create ObjectGrid read from a file
        public ObjectGrid(string id, Object parent, string assetName, int tileSize) : base(id, parent)
        {
            _tileSize = tileSize;
            Load(assetName);
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Collums * tileSize, Rows * tileSize);
        }

        //Create empty ObjectGrid
        public ObjectGrid(string id, Object parent, int collums, int rows, int tileSize) : base(id, parent, rows * collums)
        {
            _collums = collums;
            _rows = rows;
            _tileSize = tileSize;
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, collums * tileSize, rows * tileSize);
        }

        public ObjectGrid(string id, Object parent, char[,] grid, int tileSize) : base(id, parent)
        {
            _collums = grid.GetLength(0);
            _rows = grid.GetLength(1);
            ReadTiles(grid);
        }

        public int GetPositionInGrid(Vector2 p)
        {
            Vector2 pos = p - GlobalPosition;
            return (int)pos.X / (_tileSize) + (int)pos.Y / (_tileSize) * Collums;
        }

        private Point GetPositionInGridAsPoint(Object o)
        {
            Vector2 pos = o.Position - Position;
            return new Point((int)pos.X / _tileSize, (int)pos.Y / _tileSize);
        }

        public int GetPositionInGrid(Object o)
        {
            return GetPositionInGrid(o.GlobalPosition);
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

        private Object getTile(int x, int y)
        {
            return getTile(x + y * Collums);
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
            Objects[x * _rows + y] = o;
        }

        public void setTile(int i, Object o)
        {
            Objects[i] = o;
            if (o != null)
            {
                o.Position = new Vector2(i % Collums, i / Collums) * _tileSize;
            }
        }

        public bool AddToFirstFreeSpot(Object o)
        {
            for (int i = 0; i < Size; i++)
            {
                if (Objects[i] == null)
                {
                    Objects[i] = o;
                    o.Position = new Vector2((i) % Collums, (i) / Collums) * _tileSize;
                    return true;
                }
            }
            return false;
        }

        public void SwapObjects(int index, Object i, int index2, Object j)
        {
            setTile(index2, i);
            setTile(index, j);
        }

        public override void SetupCollision(Object collider, float elapsedTime)
        {
            Point p = GetPositionInGridAsPoint(collider);

            //Check for out of bounds
            if(p.X < 1)
            {
                p.X = 1;
            }
            else if(p.X > 196)
            {
                p.X = 196;
            }
            if(p.Y < 1)
            {
                p.Y = 1;
            }
            else if(p.Y > 96)
            {
                p.Y= 96;
            }

            int xBoundary = p.X + 3;
            int yBoundary = p.Y + 3;

            for (int x = p.X - 1; x < xBoundary; x++)
            {
                for(int y = p.Y - 1; y < yBoundary; y++)
                {
                    Object o = getTile(x, y);
                    if(o.CanCollide)
                    { 
                        o.CheckCollision(collider, elapsedTime);
                    }
                }
            }
        }
    }
}