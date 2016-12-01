using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS.Engine.GameManagement
{
    abstract class AIScript
    {
        public AIScript()
        {

        }

        //returns true when script is done
        public bool Update()
        {
            return false;
        }
    }
}
