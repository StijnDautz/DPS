using Engine;

namespace Content
{
    class SpriteSheetBullet : SpriteSheet
    {
        public SpriteSheetBullet() : base("Textures/Weapons/Bullet")
        {
            IsAnimated = true;
            Add("fire", 0, 1, 10000, 80, true);
            SwitchTo("fire");
        }

        protected override string UpdateAnimationState(Object o)
        {
            return "fire";
        }
    }
}
