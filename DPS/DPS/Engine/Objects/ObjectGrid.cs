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
        private Object[,] _grid;
        private int _tileSize;
        private Point _spacing;

        public int Rows
        {
            get { return _grid.GetLength(1); }
        }

        public int Collums
        {
            get { return _grid.GetLength(0); }
        }

        public Object[,] Grid
        {
            get { return _grid; }
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
                        _grid[x, y].Position = new Vector2(x * (_tileSize + value.X), y * (_tileSize + value.Y));
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
        public ObjectGrid(string id, int rows, int collums, int tileSize) : base(id)
        {
            _tileSize = tileSize;
            _grid = new Object[rows, collums];
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, collums * tileSize, rows * tileSize);
        }

        public override void Reset()
        {
            base.Reset();
            _grid = new Object[Rows, Collums];
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach(Object o in _grid)
            {
                if(o != null && o.Visible)
                {
                    o.Update(gameTime);
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            foreach(Object o in _grid)
            {
                if(o != null && o.Visible)
                {
                    o.Draw(gameTime, spriteBatch);
                }
            }
        }

        public Object getTile(Point p)
        {
            return _grid[p.X, p.Y];
        }

        public Object getTile(Vector2 p)
        {
            return getTile(GetPositionInGrid(p));
        }

        public void AddObject(int x, int y, Object o)
        {
            _grid[x, y] = o;
            o.Position = new Vector2(x * (_tileSize + Spacing.X), y * (_tileSize + Spacing.Y));
            o.Parent = this;
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
            RemoveObject(GetPositionInGrid(o));
        }

        public void RemoveObject(Point p)
        {
            _grid[p.X, p.Y] = null;
        }

        public bool AddToFirstFreeSpot(Object o)
        {
            for (int y = 0; y < Rows; y++)
            {
                for(int x = 0; x < Collums; x++)
                {
                    if(_grid[x, y] == null)
                    {
                        AddObject(x, y, o);
                        return true;
                    }
                }
            }
            return false;
        }

        //BUG??????????????????????????????????????????????????????????????????????????
        public void SwapObjects(Point o, Point p)
        {
            Object temp = _grid[o.X, o.Y];
            Object temp2 = _grid[p.X, p.Y];
            _grid[o.X, o.Y] = temp2;
            _grid[p.X, p.Y] = temp;
        }
    }
}