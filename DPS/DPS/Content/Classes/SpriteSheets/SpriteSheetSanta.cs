using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class SpriteSheetSanta : SpriteSheet
    {
        public SpriteSheetSanta() : base("Textures/Characters/SantaBoss1")
        {
            IsAnimated = true;
            Add("moving", 0, 1, 100000, 120, true);
            SwitchTo("moving");
        }

        public override void Update(GameTime gameTime, Object obj)
        {
            base.Update(gameTime, obj);
            Mirrored = obj.Velocity.X < 0 ? false : true;
        }

        protected override string UpdateAnimationState(Object o)
        {
            return "moving";
        }
    }
}
