﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    partial class ObjectGrid : Object
    {
        private int _tileWidth;
        private int _tileHeight;
        private int _collums;
        private int _rows;
        private Object[,] _grid;

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

        public Object[,] Grid
        {
            get { return _grid; }
        }

        //Create ObjectGrid read from a file and already set Position as it may be needed to correctly position Characters
        public ObjectGrid(string id, Object parent, string assetName, int tileSize, Vector2 position) : base(id, parent)
        {
            _tileWidth = tileSize;
            _tileHeight = tileSize;
            Position = position;
            Load(assetName);
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Collums * tileSize, Rows * tileSize);
        }

        //Create ObjectGrid read from a file
        public ObjectGrid(string id, Object parent, string assetName, int tileSize) : base(id, parent)
        {
            _tileWidth = tileSize;
            _tileHeight = tileSize;
            Load(assetName);
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Collums * tileSize, Rows * tileSize);
        }

        //Create empty ObjectGrid
        public ObjectGrid(string id, Object parent, int collums, int rows, int tileWidth, int tileHeight) : base(id, parent)
        {
            _collums = collums;
            _rows = rows;
            _tileWidth = tileWidth;
            _tileHeight = tileHeight;
            _grid = new Object[collums, rows];
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, collums * tileWidth, rows * tileHeight);
        }

        public ObjectGrid(string id, Object parent, char[,] grid, int tileWidth, int tileHeight) : base(id, parent)
        {
            _collums = grid.GetLength(0);
            _rows = grid.GetLength(1);
            _tileWidth = tileWidth;
            _tileHeight = tileHeight;
            _grid = new Object[_collums, _rows];
            ReadTiles(grid);
        }

        /*Find the Point of an Object in the grid*/
        public Point GetPositionInGrid(Vector2 p)
        {
            Vector2 pos = p - GlobalPosition;
            return new Point((int)pos.X / _tileWidth, (int)pos.Y / _tileHeight);
        }

        private Point GetPositionInGrid(Object o)
        {
            return GetPositionInGrid(o.GlobalPosition);
        }

        /*Return a tile at a specific point in the grid*/
        public Object getTile(Vector2 p)
        {
            return GetTile(GetPositionInGrid(p));
        }

        public Object GetTile(Point p)
        {
            if(WithinBoudaries(p.X, p.Y))
            {
                return _grid[p.X, p.Y];
            }
            return null;
        }

        /*Check whether an object is within the objects boundaries or not*/
        public bool WithinBoudaries(int x, int y)
        {
            if(x < 0 || x > _collums -1 || y < 0 || y > _rows - 1)
            {
                return false;
            }
            return true;
        }

        public void RemoveObject(Object o)
        {
            Vector2 pos = o.Position - Position;
            removeTile(GetPositionInGrid(o.Position));
        }

        public void removeTile(Point p)
        {
            _grid[p.X, p.Y] = null;
        }

        public void setTile(int x, int y, Object o)
        {
            if (WithinBoudaries(x, y))
            {
                _grid[x, y] = o;
                o.Position = new Vector2(x * _tileWidth, y * _tileHeight);
            }
        }

        /*Find first free spot in _grid*/
        public bool AddToFirstFreeSpot(Object o)
        {
            //loop through grid and check if point is null, if so setTile and return true
            for (int x = 0; x < _collums; x++)
            {
                for (int y = 0; y < _rows; y++)
                {
                    if (_grid[x, y] == null)
                    {
                        setTile(x, y, o);
                        return true;
                    }
                }
            }
            return false;
        }

        public void SwapObjects(int x1, int y1, Object o1, int x2, int y2, Object o2)
        {
            setTile(x1, y1, o2);
            setTile(x2, y2, o1);
        }

        public override void SetupCollision(Object collider, float elapsedTime)
        {
            var newPos = collider.GlobalPosition + collider.Velocity * elapsedTime;
            Point p = GetPositionInGrid(newPos);
            int leftX = p.X;
            int rightX = GetPositionInGrid(new Vector2((newPos.X + collider.Width), newPos.Y)).X;
            int topY = p.Y;
            int bottomY = GetPositionInGrid(new Vector2(newPos.X, newPos.Y + collider.Height)).Y;

            for (int x = leftX; x < rightX + 1; x++)
            {
                for (int y = topY; y < bottomY + 1; y++)
                {
                    Object o = GetTile(new Point(x , y));
                    if (o != null && o.CanCollide && collider.CanCollide)
                    {
                        if(o is ObjectGrid)
                        {
                            o.SetupCollision(collider, elapsedTime);
                        }
                        else
                        {
                            o.CheckCollision(collider, elapsedTime);
                        }
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            Vector2 CameraPosition = World.CameraPosition;
            foreach (Object o in _grid)
            {
                if (o != null )
                {
                    if (!(o.GlobalPosition.X + o.Width < CameraPosition.X || o.GlobalPosition.X > CameraPosition.X + GameInstance.GraphicsDeviceManager.PreferredBackBufferWidth || o.GlobalPosition.Y + o.Height < CameraPosition.Y || o.GlobalPosition.Y > CameraPosition.Y + GameInstance.GraphicsDeviceManager.PreferredBackBufferHeight))
                    {
                        o.Draw(gameTime, spriteBatch);
                    }
                }
            }
        }
    }
}