using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected override void UpdateSFX()
        {
            if(Source is EnemyZombie)
            {
                var zombie = Source as EnemyZombie;
                if (zombie.Attacking)
                {
                    SwitchTo("attack");
                }
                //if not attacking and zombie is damaged, play this sfx
                else if (_health > zombie.Health)
                {
                    SwitchTo("damaged");
                }
                //if not attacking or damaged, play scream, as attack sfx should not be interupted
                else if (zombie.Speed == zombie.WalkSpeed && PlayingSFX.name != "normalScream")
                {
                    SwitchTo("normalScream");
                }
                else if(zombie.Speed == zombie.SprintSpeed && PlayingSFX.name != "crazyScream")
                {
                    SwitchTo("crazyScream");
                }

                //update health of zombie, so damaged sfx wont play if it wasnt able to when the zombie was actually damaged
                _health = zombie.Health;
            }
        }
    }
}
