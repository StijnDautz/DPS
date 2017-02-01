using Engine;

namespace Content
{
    class SFXExplosion : SFXManager
    {
        public SFXExplosion(Object source) : base(source)
        {
            Add("explosion", GameInstance.AssetManager.GetSoundEffect("Explosie 1"), false);
            SwitchTo("explosion");
        }

        protected override string UpdateSFX()
        {
            return "explosion";
        }

        protected override void AtEndSFX()
        {
            base.AtEndSFX();
            //after explosion sfx has ended remove the explosion object
            Source.World.Remove(Source);
        }
    }
}
