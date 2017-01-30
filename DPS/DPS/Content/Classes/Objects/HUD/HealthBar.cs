using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Content
{
    class HealthBar : Engine.ObjectList
    {
        public HealthBar(string id, Engine.Object parent) : base(id, parent)
        {
            Add(new Engine.TexturedObject("health", this, new SpriteSheetHealthBar("Textures/HUD/HealthFilling")));
            Add(new Engine.TexturedObject("frame", this, new Engine.SpriteSheet("Textures/HUD/HealthBorder")));
        }
    }
}
