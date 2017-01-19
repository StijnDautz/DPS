using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class ExitButton : Engine.Button
    {
        public ExitButton(string id, Engine.Object parent, string assetName) : base(id, parent, assetName)
        {

        }

        protected override void ActionWhenPressed()
        {
            World.GameMode.Parent.GameInstance.Exit();

        }
    }
}
