using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Engine
{
    class Pickup : TexturedObject
    {
        TextObject _discription;
        bool isPickupUp;
        bool blablabla;

        public bool IsPickupUp
        {
            get { return isPickupUp; }
        }

        double waitTime;

        public Pickup(string id, Object parent, SpriteSheet spriteSheet, string discription) : base(id, parent, spriteSheet)
        {
            _discription = new TextObject("discription", "Hud", World.Player.Inventory);
            _discription.Text = discription;
            SFXManager = new Content.SFXItem(this);
        }

        //waarschijnlijk bug playerpos = null
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //Update position
            double t = gameTime.TotalGameTime.TotalSeconds * 3.0f;
            Position = new Vector2(Position.X, Position.Y + (float)Math.Sin(t) * 0.2f);

            

            if (blablabla)
            {
                MediaPlayer.Volume = 1;
                waitTime = gameTime.TotalGameTime.TotalSeconds + (double)12;
                blablabla = false;
            }

            if (waitTime == gameTime.TotalGameTime.TotalSeconds)
            {
                MediaPlayer.Volume = 1;
                isPickupUp = true;
                World.Remove(this);
            }
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

                isPickupUp = true;
                blablabla = true;
            }
        }

        public virtual void OnClicked()
        {

        }
    }
}