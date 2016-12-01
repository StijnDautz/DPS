using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS.Engine.GameManagement.Objects
{
    interface ICharacter
    {
        string Name { get; }
        int Age { get; }
        bool Gender { get; }
        //Inventory Inventory { get; }
        int Happiness { get; }
    }
}
