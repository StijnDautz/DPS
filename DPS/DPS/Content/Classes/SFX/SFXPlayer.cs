namespace Content
{
    class SFXPlayer : Engine.SFXManager
    {
        int _health;

        public SFXPlayer(Engine.Object source) : base(source)
        {
            Add("attack", getSFX("Player Attack"), false);
            Add("damaged", getSFX("Player Hit"), false);
            Add("death", getSFX("Player Death"), false);
            _health = (source as Engine.Player).Health;
        }

        protected override string UpdateSFX()
        {
            base.UpdateSFX();
            if(Source is Engine.Player)
            {
                var player = Source as Engine.Player;
                if(player.Death)
                {
                    return "death";
                }
                if(player.Attacking)
                {
                    return "attack";
                }
                if(_health > player.Health)
                {
                    //update health of player, so damaged sfx wont play if it wasnt able to when the player was actually damaged
                    _health = player.Health;
                    SwitchTo("damaged");
                }
            }
            return "";
        }
    }
}