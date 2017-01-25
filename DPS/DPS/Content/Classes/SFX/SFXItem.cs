using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class SFXItem : Engine.SFXManager
    {
        bool picked;

        public SFXItem(Engine.Object source) : base(source)
        {
            Add("itemPickup", getSFX("Item Pickup"), false);
        }

        protected override void UpdateSFX()
        {
            base.UpdateSFX();
            if (Source is Pickup)
            {
                if ((Source as Pickup).IsPickupUp && !picked)
                {
                    SwitchTo("itemPickup");
                    picked = true;
                }
            }
        }

    }
}
