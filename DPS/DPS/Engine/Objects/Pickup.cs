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
    /*
     * A Pickup has to be an ObjectList, as the 
     * Just adding the Pickup as ObjectList allows for adding it in such away that the discription will always be drawn over it
     */
    class Pickup : ObjectList
    {
        TexturedObject _pickup;
        Content.DescriptionBox _descriptionBox;
        bool isPickupUp;

        public bool IsPickupUp
        {
            get { return isPickupUp; }
        }

        public Pickup(string id, Object parent, SpriteSheet spriteSheet, string description) : base(id, parent)
        {
            //create pickup TexturedObject
            _pickup = new TexturedObject("pickup", this, spriteSheet);

            //Set collisionBox of this list to be equal to the one _pickup
            BoundingBox = _pickup.BoundingBox;

            //Create the pickups descriptionBox
            _descriptionBox = new Content.DescriptionBox(this, new SpriteSheet("HUD/TimerFrame"), description);

            //Add both objects in the correct order so they are drawn properly
            Add(_pickup);
            Add(_descriptionBox);

            //pickups have to collide to detect whether they have to be picked up or not
            CanCollide = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //Update position
            double t = gameTime.TotalGameTime.TotalSeconds * 3.0f;
            Position = new Vector2(Position.X, Position.Y + (float)Math.Sin(t) * 0.2f);

            //check if mouse is on top of pickup
            CheckMouseOn();
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
            }
        }

        /*
         * check if mouse in on top of pickup
         * if so, call OnHoverOver()
         */
        private void CheckMouseOn()
        {
            var mousePosRelativeToWorld = GameInstance.InputManager.MousePosition + World.CameraPosition;

            //check wheter the mouse collides with the mouse
            if (CollisionHelper.CollidesWith(this, mousePosRelativeToWorld))
            {
                OnHoverOver(mousePosRelativeToWorld);
            }
            else
            {
                _descriptionBox.Visible = false;
            }
        }

        /*
         * Call in mouse is on top of pickup
         */
        protected virtual void OnHoverOver(Vector2 mousePosRelativeToWorld)
        {
            //make sure discription is visible and it set to the mousePosition
            _descriptionBox.Visible = true;
            _descriptionBox.Position = mousePosRelativeToWorld - Position;
        }

        protected virtual void OnClicked()
        {

        }
    }
}