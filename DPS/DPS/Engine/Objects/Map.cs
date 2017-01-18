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
        public Map(string id, ObjectGrid grid, int tileSize, Object parent) : base(id, parent)
        {
            grid.Parent = this;
            Add(grid);
            BoundingBox = grid.BoundingBox;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach(Object o in Objects)
            {
                o.Draw(gameTime, spriteBatch);
            }
        }

        public Point getPositionInGrid(Vector2 position)
        {
            return new Point((int)position.X / World.TileSize, (int)position.Y / World.TileSize);
        }
    }
}