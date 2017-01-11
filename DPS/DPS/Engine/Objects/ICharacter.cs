using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public enum movementState
    {
        IDLE, WALKING, RUNNING, JUMPING, FALLING, ATTACK, JUMPATTACK,
    }

    interface ICharacter
    {
        string Name { get; }
        movementState MovementState { get; }
        int Health { get; set; }
        //Inventory Inventory { get; }
    }
}
