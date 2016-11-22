using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    partial class Map : Object, IControlledLoopObject
    {
        private int _tileWidth;
        private int _tileHeight;
        private Object[,] _grid;

        public int TileWidth
        {
            get { return _tileWidth; }
            set { _tileWidth = value; }
        }

        public int TileHeight
        {
            get { return _tileHeight; }
            set { _tileHeight = value; }
        }

        public int Rows
        {
            get { return _grid.GetLength(1); }
        }

        public int Colums
        {
            get { return _grid.GetLength(0); }
        }

        Map(string id, string assetName) : base(id)
        {
            Load(assetName);
        }

        Object getTile(int x, int y)
        {
            return _grid[x, y];
        }

        public override void Reset()
        {
            base.Reset();
            foreach(Object o in _grid)
            {
                o.Reset();
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach(Object o in _grid)
            {
                o.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            foreach(Object o in _grid)
            {
                o.Draw(gameTime, spriteBatch);
            }
        }

        public virtual void HandleInput(GameTime gameTime)
        {
            foreach(Object o in _grid)
            {
                if(o is Pawn)
                {
                    Pawn pawn = o as Pawn;
                    pawn.HandleInput(gameTime);
                }
            }
        }


    }
}