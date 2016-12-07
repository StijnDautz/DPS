using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    class Pickup : TexturedObject
    {
        public Pickup(string id, string assetName) : base(id, assetName)
        {
        }

        //waarschijnlijk bug playerpos = null
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Parent is Map)
            {
                //Update position
                double t = gameTime.TotalGameTime.TotalSeconds * 3.0f;
                Position = new Vector2(Position.X, Position.Y + (float)Math.Sin(t) * 0.2f);

                Map map = Parent as Map;
                Character player = map.World.Player;
                if (CollisionHelper.CollidesWith(player, this))
                {
                    if (player.Inventory.AddPickup(this))
                    {
                        map.Remove(this);
                    }
                }
            }
        }
    }
}