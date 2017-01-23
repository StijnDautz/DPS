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

        public Teleporter(string id, Object parent, string world, Vector2 position) : base(id, parent)
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
                var player = collider as Player;
                //teleport player
                TeleportObject(collider);
                collider.Position = _position;

                //teleport its weapons
                TeleportObject(player.Weapon1);
                TeleportObject(player.Weapon2);
            }
        }
        
        private void TeleportObject(Object o)
        {
            World.GameMode.SwitchTo(_world);
            World.GameMode.World.Add(o);
            World.Remove(o);
        }
    }
}