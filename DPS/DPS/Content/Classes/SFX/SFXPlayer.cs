using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class SFXPlayer : Engine.SFXManager
    {
        SFXPlayer(Engine.Object source) : base(source)
        {
            Add("attack", getSFX("playerAttack"), false);
            Add("damaged", getSFX("playerAttack"), false);
            Add("death", getSFX("playerDeath"), false);
        }
    }
}
