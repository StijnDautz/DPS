using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class Character : TexturedObject
    {
        int _health, _damage, _speed;
        double _attackSpeed, _attackTime;
        bool _attacking;

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
        
        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        
        public double AttackSpeed
        {
            get { return _attackSpeed; }
            set { _attackSpeed = value; }
        }
           
        public Character(string id, Object parent, string assetName) : base(id, parent, assetName)
        {

        }

        public override void OnCollision(Object collider)
        {
            base.OnCollision(collider);
            if(collider is Character)
            {
                Character character = collider as Character;
                if(_attackTime == 0 && _attacking)
                {
                    
                }
            }
        }
    }
}
