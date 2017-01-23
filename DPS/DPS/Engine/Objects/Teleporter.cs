using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class Teleporter : Object
    {
        private string _world;
        private Vector2 _position;

        Teleporter(string id, Object parent, string world, Vector2 position) : base(id, parent)
        {
            _world = world;
            _position = position;
            CanCollide = true;
        }

        public override void OnCollision(Object collider)
        {
            base.OnCollision(collider);
            if(collider is Player)
            {
                World.GameMode.SwitchTo(_world);
                collider.Parent = World;
                collider.Position = _position;
            }
        }
    }
}
