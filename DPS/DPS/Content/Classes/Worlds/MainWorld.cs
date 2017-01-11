using Engine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class MainWorld : World
    {
        public MainWorld(Character character) : base(character)
        {
            IsTopDown = false;
            Map m = new Map("MainMap", new MainObjectGrid("mainGrid", "MainMap", 60), TileSize);
            AddMap(m);
            m.Add(character);
            TexturedObject t = new TexturedObject("floor", "Textures/Tiles/spr_wall");
            t.CanCollide = true;
            t.canBlock = true;
            t.Position = new Vector2(0, 200);
            m.Add(t);
            TexturedObject t2 = new TexturedObject("floor", "Textures/Tiles/spr_wall");
            t2.Position = new Vector2(100, 200);
            t2.CanCollide = true;
            t2.canBlock = true;
            m.Add(t2);
            
        }
    }
}