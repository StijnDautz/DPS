namespace Content
{
    class SFXZombie : Engine.SFXManager
    {
        int _health;

        public SFXZombie(Engine.Object source) : base(source)
        {
            Add("normalScream", getSFX("Zombie normal(" + Engine.GameInstance.RNG.Next(1, 5) + ")") , true);
            Add("crazyScream", getSFX("Zombie scream"), true);
            Add("damaged", getSFX("Small Enemy Hit"), false);
            Add("attack", getSFX("Small Enemy Attack"), false);
            if(source is EnemyZombie)
            {
                _health = (source as EnemyZombie).Health;
            }
        }

        protected override string UpdateSFX()
        {
            if(Source is EnemyZombie)
            {
                var zombie = Source as EnemyZombie;
                if (zombie.Attacking)
                {
                    return "attack";
                }
                //if not attacking and zombie is damaged, play this sfx
                if (_health > zombie.Health)
                {
                    //update health of zombie, so damaged sfx wont play if it wasnt able to when the zombie was actually damaged
                    _health = zombie.Health;
                    return "damaged";
                }
                //if not attacking or damaged, play scream, as attack sfx should not be interupted
                if (zombie.Speed == zombie.SprintSpeed)
                {
                    return "crazyScream";
                }
            }
            return "normalScream";
        }
    }
}