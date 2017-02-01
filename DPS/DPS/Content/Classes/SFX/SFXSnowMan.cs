namespace Content
{
    class SFXSnowMan : Engine.SFXManager
    {
        int _health;
        public SFXSnowMan(Engine.Object source) : base(source)
        {
            Add("attack", getSFX("Medium Enemy Attack"), false);
            Add("damaged", getSFX("Medium Enemy Hit"), false);
            Add("death", getSFX("Medium Enemy Death"), false);
            if(source is EnemySnowMan)
            {
                _health = (source as EnemySnowMan).Health;
            }
        }

        protected override string UpdateSFX()
        {
            base.UpdateSFX();
            if(Source is EnemySnowMan)
            {
                var snowMan = Source as EnemySnowMan;
                if(snowMan.Death)
                {
                    return "death";
                }
                else if(snowMan.Attacking)
                {
                    return "attack";
                }
                else if(_health > snowMan.Health)
                {
                    return "damaged";
                }
                _health = snowMan.Health;
            }
            return "";
        }
    }
}