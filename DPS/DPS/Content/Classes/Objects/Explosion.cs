using Engine;

namespace Content
{
    class Explosion : TexturedObject
    {
        public Explosion(Object parent) : base("explosion", parent, new SpriteSheetExplosion())
        {
            SFXManager = new SFXExplosion(this); 
        }
    }
}
