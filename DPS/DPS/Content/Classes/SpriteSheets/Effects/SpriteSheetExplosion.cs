using Engine;

namespace Content
{
    class SpriteSheetExplosion : Engine.SpriteSheet
    {
        public SpriteSheetExplosion() : base("Textures/Effects/explosion")
        {
            IsAnimated = true;
            CanUpdate = false;
            Add("explosion", 0, 8, 40, 2000, false);
            SwitchTo("explosion");
        }

        protected override void AfterLastFrame(Object obj)
        {
            base.AfterLastFrame(obj);

            //at end of explosion remove the object from the world
            obj.World.Remove(obj);
        }
    }
}
