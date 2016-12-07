using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    partial class Map : ObjectList, IControlledLoopObject
    {
        private World _world;
        private int[,] _collisionMap;

        public World World
        {
            set { _world = value; }
            get { return _world; }
        }

        public int[,] CollisionMap
        {
            get { return _collisionMap; }
        }

        public Map(string id, ObjectGrid grid, int tileSize) : base(id)
        {
            Add(grid);
            _collisionMap = new int[grid.Rows, grid.Collums];
            BoundingBox = grid.BoundingBox;
        }

        public override void Add(Object o)
        {
            base.Add(o);
            if(o.CanCollide)
            {
                _collisionMap[(int)o.Position.X / World.TileSize, (int)o.Position.Y / World.TileSize]++;
            }
        }

        public void UpdateCollisionMap(Object o)
        {
            int modifier = -1;
            if(o.CanCollide)
            {
                modifier = 1;
            }
            _collisionMap[(int)o.Position.X / World.TileSize, (int)o.Position.Y / World.TileSize] += modifier;
        }

        public bool Collides(Point p)
        {
            if(_collisionMap[p.X, p.Y] > 1)
            { return true; }
            return false;
        }

        public Point getPositionInGrid(Vector2 position)
        {
            return new Point((int)position.X / World.TileSize, (int)position.Y / World.TileSize);
        }
    }
}