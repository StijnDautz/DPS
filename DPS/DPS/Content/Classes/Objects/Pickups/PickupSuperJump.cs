using Engine;

namespace Content
{
    class PickupSuperJump : Pickup
    {
        public PickupSuperJump(Object parent) : base("pickupSuperJump", parent, new SpriteSheet("Textures/Items/Rocketcape"), "This cape migth make you fly.\nDo not press R!")
        {
                
        }

        public override void OnCollision(Object collider)
        {
            base.OnCollision(collider);
            World.Player.CanSuperJump = true;
        }
    }
}
