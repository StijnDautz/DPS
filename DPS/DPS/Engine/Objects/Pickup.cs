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
        Pickup(string id, string assetName) : base(id, assetName)
        {
        }

        //waarschijnlijk bug playerpos = null
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Parent is Map && Parent.Pawns.Count > 0)
            {
                Character c;
                foreach (Pawn p in Parent.Pawns)
                {
                    if (p is Character)  //verandert in toekomst
                    {
                        c = p as Character;
                    }
                }
                if (CollisionHelper.CollidesWith(c, this))
                {
                    if (c.Inventory.AddPickup(this))
                    {
                        Parent.Remove(this);
                    }
                }
                double t = gameTime.TotalGameTime.TotalSeconds * 3.0f;
                Position = new Vector2(Position.X, Position.Y + (float)Math.Sin(t) * 0.2f);
            }
        }
    }
}