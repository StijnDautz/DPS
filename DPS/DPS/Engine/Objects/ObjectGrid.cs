using Microsoft.Xna.Framework;
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

        public int Colums
        {
            get { return _grid.GetLength(0); }
        }

        public Point Spacing
        {
            get { return _spacing; }
            set
            {
                for(int x = 0; x < Rows; x++)
                {
                    for(int y = 0; y < Colums; y++)
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
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Rows * tileSize, Colums * tileSize);
        }

        //Create empty ObjectGrid
        public ObjectGrid(string id, int rows, int collums, int tileSize) : base(id)
        {
            _tileSize = tileSize;
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, rows * tileSize, collums * tileSize);
            _grid = new Object[rows, collums];
        }

        public override void Reset()
        {
            base.Reset();
            _grid = new Object[Rows, Colums];
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

        public void AddObject(int x, int y, Object o)
        {
            _grid[x, y] = o;
            o.Position = new Vector2(Position.X + x * Spacing.X, Position.Y + y * Spacing.Y);
        }

        public void RemoveObject(int x, int y)
        {
            _grid[x, y] = null;
        }
    }
}