using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class Inventory : ObjectGrid
    {
        private Weapon _strongestWeapon;
        private Weapon _equipedWeapon;

        public Weapon EquipedWeapon
        {
            get { return _equipedWeapon; }
        }

        public Inventory(string id) : base(id, 2, 4, 109)
        {
            _strongestWeapon = FindStrongestWeapon();
            _equipedWeapon = _strongestWeapon;
        }

        public bool AddPickup(Pickup o)
        {
            if(o is Weapon)
            {
                Weapon w = o as Weapon;
                if(_strongestWeapon == null || w.Damage > _strongestWeapon.Damage)
                {
                    _strongestWeapon = w;
                }
            }
            if(AddToFirstFreeSpot(o))
            {
                o.Depth = 0;
                return true;
            }
            return false;
        }

        public void RemovePickup(Pickup o)
        {
            if (o is Weapon)
            {
                Weapon w = o as Weapon;
                if (w.Damage == _strongestWeapon.Damage)
                {
                    _strongestWeapon = FindStrongestWeapon();
                }
            }
            RemoveObject(o);
        }

        public void MovePickup(Pickup movingPickup, Vector2 MousePosition)
        {
            Point p = GetPositionInGrid(MousePosition);
            Pickup switchPickup = getTile(p) as Pickup;

            if(switchPickup == null)
            {
                setTile(p.X, p.Y, movingPickup);
            }
            else
            {
                SwapPickup(p, GetPositionInGrid(movingPickup));
            }
        }

        public void SwapPickup(Point o, Point swappickup)
        {
            SwapObjects(o, swappickup);
        }

        public Weapon FindStrongestWeapon()
        {
            Weapon strongest = null;
            foreach(Object o in Objects)
            {
                if(o is Weapon)
                {
                    Weapon w = o as Weapon;
                    if(strongest == null || w.Damage > strongest.Damage)
                    {
                        strongest = w;
                    }
                }
            }
            return strongest;
        }
    }
}