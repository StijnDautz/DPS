using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    abstract partial class Map : ObjectList, IControlledLoopObject
    {
        private int _tileWidth;
        private int _tileHeight;
        private Object[,] _grid;
        private List<Pawn> _pawns;
        private World _world;

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

        public World World
        {
            set { _world = value; }
        }

        public Map(string id, string assetName) : base(id)
        {
            _tileWidth = 72;
            _tileHeight = 55;
            Load(assetName);
        }

        public Object getTile(Point p)
        {
            return _grid[p.X, p.Y];
        }

        public Point getPositionInGrid(Vector2 position)
        {
            return new Point((int)Math.Floor(position.X / _tileWidth), (int)Math.Floor(position.Y / TileHeight));
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
                if (o.Visible)
                { o.Draw(gameTime, spriteBatch); }
            }
        }

        public override void HandleInput(GameTime gameTime)
        {
            foreach(Pawn p in _pawns)
            {
                p.HandleInput(gameTime);
            }
        }

        public override void Add(Object o)
        {
            base.Add(o);

            //if object is Pawn add it to list of pawns, which is used to prevent unnecessary calls of HandleInput(gameTime)
            if(o is Pawn)
            {
                Pawn p = o as Pawn;
                _pawns.Add(p);
            }
        }
    }
}