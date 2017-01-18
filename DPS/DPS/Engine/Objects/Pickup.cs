﻿using System;
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
        TextObject _discription;

        public Pickup(string id, Object parent, string assetName, string discription) : base(id, parent, assetName)
        {
            _discription = new TextObject("discription", "Hud", World.Player.Inventory);
            _discription.Text = discription;
        }

        //waarschijnlijk bug playerpos = null
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //Update position
            double t = gameTime.TotalGameTime.TotalSeconds * 3.0f;
            Position = new Vector2(Position.X, Position.Y + (float)Math.Sin(t) * 0.2f);
        }

        /*
         * if collision with player, check if object can be added to inventory, if so remove it from the ObjectList
         */
        public override void OnCollision(Object collider)
        {
            base.OnCollision(collider);
            Player player = World.Player;
            if(collider == player && player.Inventory.AddPickup(this))
            {
                World.Remove(this);
            }
        }

        public virtual void OnClicked()
        {

        }
    }
}