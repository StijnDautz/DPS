namespace Content
{
    class Enemy : Engine.NPC
    {
        public Enemy(string id, Engine.Object parent, Engine.SpriteSheet spriteSheet) : base(id, parent, spriteSheet)
        {

        }

        public override void OnDamaged(int damage)
        {
            base.OnDamaged(damage);
            HighScoreManager.TotalDamageDealt += damage;
        }
    }
}
