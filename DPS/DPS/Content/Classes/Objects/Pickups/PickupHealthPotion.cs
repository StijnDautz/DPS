using Engine;

namespace Content
{
    class PickupHealthPotion : Pickup
    {
        public PickupHealthPotion(Object parent) : base("healthPotion", parent, new SpriteSheet("Textures/Items/HealthPotion"), "This potion restores your health")
        {

        }

        /*
         * OnCollision heal player for 1000
         */
        public override void OnCollision(Object collider)
        {
            base.OnCollision(collider);
            var player = World.Player;
            if (collider == player)
            {
                player.Health = player.MaxHealth;
            }
        }
    }
}
