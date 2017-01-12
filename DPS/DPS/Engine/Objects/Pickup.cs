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
            if (ObjectList is Map)
            {
                //Update position
                double t = gameTime.TotalGameTime.TotalSeconds * 3.0f;
                Position = new Vector2(Position.X, Position.Y + (float)Math.Sin(t) * 0.2f);
            }
        }

        /*
         * if collision with player, check if object can be added to inventory, if so remove it from the ObjectList
         */
        public override void OnCollision(Object collider)
        {
            base.OnCollision(collider);
            Character player = ObjectList.World.Player;
            if(collider == player && player.Inventory.AddPickup(this))
            {
                ObjectList.Remove(this);
            }
        }

        public virtual void OnClicked()
        {

        }
    }
}