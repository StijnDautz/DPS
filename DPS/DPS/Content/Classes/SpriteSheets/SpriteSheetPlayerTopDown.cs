using Engine;

namespace Content
{ 
    class SpriteSheetPlayerTopDown : SpriteSheet
    {
        public SpriteSheetPlayerTopDown(string assetName) : base(assetName)
        {
            IsAnimated = true;
            Add("idle", 0, 2, 320, 128, true);
            Add("walking", 1, 16, 40, 1024, true);
            SwitchTo("idle");
        }

        protected override string UpdateAnimationState(Object o)
        {
            string anim = "idle";
            if(o.Velocity.Length() != 0)
            {
                anim = "walking";
            }
            return anim;
        }
    }
}
