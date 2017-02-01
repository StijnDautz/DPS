using Engine;

namespace Content
{
    class PickupHealthPotion : Pickup
    {
        public PickupHealthPotion(Object parent) : base("healthPotion", parent, new SpriteSheet("Textures/Items/HealthPotion"), "This potion restores your health")
        {

        }

        public override void OnCollision(Object collider)
        {
            base.OnCollision(collider);
            World.Player.Health = World.Player.MaxHealth;
        }
    }
}
